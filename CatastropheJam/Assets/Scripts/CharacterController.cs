using UnityEngine;
using System.Collections;

public class CharacterController : MonoBehaviour {

	float rotationSpeed = 1f,
		  forwardSpeed = .05f,
		  sideSpeed = .05f,
		  minVertAngle = 0.5f,
		  maxVertAngle = 25;

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
			Vector3 position = transform.position;

			// Left
			if (Input.GetKeyDown(KeyCode.A)){
				movingLeft = true;
				movingRight = false;

			}
			// Up
			else if (Input.GetKeyDown(KeyCode.W)){
				movingBackward = false;
				movingForward = true;
			}
			// Down
			else if (Input.GetKeyDown(KeyCode.S)){
				movingBackward = true;
				movingForward = false;
			}
			//Right
			else if (Input.GetKeyDown(KeyCode.D)){
				movingLeft = false;
				movingRight = true;
			}

			// Left
			if (Input.GetKeyUp(KeyCode.A)){
				movingLeft = false;
			}
			// Up
			else if (Input.GetKeyUp(KeyCode.W)){
				movingForward = false;
			}
			// Down
			else if (Input.GetKeyUp(KeyCode.S)){
				movingBackward = false;
			}
			//Right
			else if (Input.GetKeyUp(KeyCode.D)){
				movingRight = false;

			}

			if (movingForward){
				position += transform.forward * forwardSpeed;
			}
			else if (movingBackward){
				position -= transform.forward * forwardSpeed;
			}

			if (movingRight){
				position += transform.right * sideSpeed;
			}
			else if (movingLeft){
				position -= transform.right * sideSpeed;
			}

			if (movingForward || movingBackward || movingLeft || movingRight){
				babyAnimator.SetBool("walking", true);
			}
			else{
				babyAnimator.SetBool("walking", false);
			}

			float rotation = Input.GetAxis("Mouse X") * rotationSpeed;

			transform.Rotate(0, rotation, 0);


			transform.position = position;
		}
	}
}
