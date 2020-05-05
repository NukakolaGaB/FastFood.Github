using UnityEngine;
using System.Collections;

public class GestionEscenarios : MonoBehaviour {

	[SerializeField] GameObject comedor;
	[SerializeField] GameObject piratas;

	// Use this for initialization
	void Awake () {
	
		if (Escenas.ronda == 0) {
		
			comedor.SetActive (true);
			piratas.SetActive (false);
		
		
		} else if (Escenas.ronda == 1) {
		
			comedor.SetActive (false);
			piratas.SetActive (true);
		
		}
		else {
		
			comedor.SetActive(true);
			piratas.SetActive(false);
		
		
		}


	}

}
