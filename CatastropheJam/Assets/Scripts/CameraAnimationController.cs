using UnityEngine;
using System.Collections;

public class CameraAnimationController : MonoBehaviour {

	protected Quaternion originalRotation;
	protected Vector3 originalPosition;

	[SerializeField] protected Animator animator;
	[SerializeField] protected Transform playerTransform;

	protected bool animating;

	float idleTime = 5,
		  lastIdle;

	void Awake(){
		originalPosition = transform.localPosition;
		originalRotation = transform.localRotation;
		animating = false;
		lastIdle = Time.time;
	}

	public IEnumerator ToggleAnimation(bool toggle){
		animating = toggle;

		// lerp to original stuff and enable animation
		if (toggle){
			yield return StartCoroutine(ReturnToOriginalPosition());
		}
		// cancel animation
		else{
			animating = false;
			animator.enabled = false;
		}

		yield break;
	}

	void Update(){
		if (animating){
			//transform.LookAt(playerTransform, Vector3.up);
		}
	}

	IEnumerator ReturnToOriginalPosition(){
		float distanceThreshold = .1f;
		float angleThreshold = 5;
		float angleStep = 2;
		float translationStep = .1f;

		Vector3 basePos = transform.localPosition;
		float progress = .01f;
		while (Vector3.Distance(originalPosition, transform.localPosition) > distanceThreshold ||
			   Quaternion.Angle(originalRotation, transform.localRotation) > angleThreshold){

				transform.localRotation = Quaternion.RotateTowards(transform.localRotation, originalRotation, angleStep);
				transform.localPosition = Vector3.Lerp(basePos, originalPosition, progress);

				progress += translationStep;
				yield return null;
		}


	}
}
