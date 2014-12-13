using UnityEngine;
using System.Collections;
using System.Linq;

public class EndGame : MonoBehaviour {

	[SerializeField] protected GameObject[] fireObjects;

	[SerializeField] protected bool enableIt = false;

	// Use this for initialization
	void Start () {

	}

	bool didIt = false;
	// Update is called once per frame
	void Update () {
		if (enableIt && !didIt){
			didIt = true;
			StartCoroutine(TurnOnFire());
		}
	}

	void OnTriggerEnter(Collider other){
		if (other.name.Equals("Baby Parent")){
			StartCoroutine(TurnOnFire());
		}
	}

	IEnumerator TurnOnFire(){

		while (fireObjects.Any(x => !x.activeSelf)){
			var flames = fireObjects.Where(x => !x.activeSelf).ToList();
			flames[Random.Range(0,flames.Count-1)].SetActive(true);

			yield return new WaitForSeconds(.2f);
		}



		yield return new WaitForSeconds(5);

		Application.LoadLevel("Title");
	}
}
