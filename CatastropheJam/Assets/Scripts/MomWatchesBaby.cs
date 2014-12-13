using UnityEngine;
using System.Collections;

public class MomWatchesBaby : MonoBehaviour {

	[SerializeField] protected Transform playerTransform;

	void Start () {

	}

	// Update is called once per frame
	void Update () {
		transform.LookAt(playerTransform);
	}
}
