using UnityEngine;
using System.Collections;

public class ResolucionPantalla : MonoBehaviour {
	int anchuraPantalla;
	// Use this for initialization
	void Start () {
	
		anchuraPantalla = Screen.currentResolution.width;
		//print(Screen.currentResolution);
		if (anchuraPantalla == 1280) {
			gameObject.GetComponent<Camera> ().orthographicSize = 5.47f;
		}
        else
        {
            gameObject.GetComponent<Camera>().orthographicSize = 5f;
        }
	}

}
