using UnityEngine;
using System.Collections;

public class LightMesser : MonoBehaviour {

	Light light;

	// Use this for initialization
	void Start () {
		light = GetComponent<Light>();
		StartCoroutine(LightLol());
	}

	IEnumerator LightLol(){
		float lightMin = 0f,
			  lightMax = .9f,
			  lightCurrent = light.color.r;

		bool increment = true;

		while (true){
			Color col = light.color;
			if (increment){
				lightCurrent+=.05f;
			}
			else{
				lightCurrent-=.05f;
			}

			if (lightCurrent > lightMax || lightCurrent < lightMin){
				increment = !increment;
			}

			col.r = lightCurrent;

			light.color = col;
			Debug.Log(light.color.r);
			yield return null;
		}
	}

}
