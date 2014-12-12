using UnityEngine;
using System.Collections;

public class CharacterController : MonoBehaviour {

	float rotationSpeed = .5f,
		  forwardSpeed = .1f,
		  sideSpeed = .1f;

	bool movingForward = false,
		 movingBackward = false,
		 movingRight = false,
		 movingLeft = false;

	bool canMove = true;

	[SerializeField] protected Animator babyAnimator;

	public bool CanMove{
		get { return canMove; }
		set { canMove = value;}
	}

	// Update is called once per frame
	void Update () {

		if (canMove){
			Vector3 position = transform.localPosition;

			// Left
			if (Input.GetKeyDown(KeyCode.A)){
				movingLeft = true;
				movingRight = false;
				babyAnimator.SetBool("walking", true);
			}
			// Up
			else if (Input.GetKeyDown(KeyCode.W)){
				movingBackward = false;
				movingForward = true;
				babyAnimator.SetBool("walking", true);
			}
			// Down
			else if (Input.GetKeyDown(KeyCode.S)){
				movingBackward = true;
				movingForward = false;
				babyAnimator.SetBool("walking", true);
			}
			//Right
			else if (Input.GetKeyDown(KeyCode.D)){
				movingLeft = false;
				movingRight = true;
				babyAnimator.SetBool("walking", true);
			}

			// Left
			if (Input.GetKeyUp(KeyCode.A)){
				movingLeft = false;
				babyAnimator.SetBool("walking", false);
			}
			// Up
			else if (Input.GetKeyUp(KeyCode.W)){
				movingForward = false;
				babyAnimator.SetBool("walking", false);
			}
			// Down
			else if (Input.GetKeyUp(KeyCode.S)){
				movingBackward = false;
				babyAnimator.SetBool("walking", false);
			}
			//Right
			else if (Input.GetKeyUp(KeyCode.D)){
				movingRight = false;
				babyAnimator.SetBool("walking", false);
			}

			if (movingForward){
				position.z += sideSpeed;
			}
			else if (movingBackward){
				position.z -= sideSpeed;
			}
			else if (movingRight){
				position.x += forwardSpeed;
			}
			else if (movingLeft){
				position.x -= forwardSpeed;
			}

			float rotation = Input.GetAxis("Mouse X") * rotationSpeed;
			transform.Rotate(0, rotation, 0);

			transform.localPosition = position;
		}
	}
}
