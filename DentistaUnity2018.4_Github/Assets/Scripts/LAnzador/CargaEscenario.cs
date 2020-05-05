using UnityEngine;
using System.Collections;

public class CargaEscenario : MonoBehaviour {


	// Use this for initialization
	void Awake () {

		if (Escenas.ronda == 0) {

			GameObject escenario = Instantiate (Resources.Load ("escenarios/Escenario1", typeof(GameObject))) as GameObject;


		} else if (Escenas.ronda == 1) {

			GameObject escenario = Instantiate (Resources.Load ("escenarios/Escenario2", typeof(GameObject))) as GameObject;

		}
		else {

			GameObject escenario = Instantiate (Resources.Load ("escenarios/Escenario1", typeof(GameObject))) as GameObject;


		}


	}
}
