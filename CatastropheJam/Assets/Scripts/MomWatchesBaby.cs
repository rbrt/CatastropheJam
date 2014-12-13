using UnityEngine;
using System.Collections;

public class MomWatchesBaby : MonoBehaviour {

	[SerializeField] protected Transform playerTransform;

	[SerializeField] protected AudioSource source1,
										   source2;

	public void PlayClips(){
		source1.Play();
		source2.Play();
	}

	// Update is called once per frame
	void Update () {
		transform.LookAt(playerTransform);
	}
}
