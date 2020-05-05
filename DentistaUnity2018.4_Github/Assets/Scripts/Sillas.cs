using UnityEngine;
using System.Collections;

public class Sillas : MonoBehaviour {

	public Transform[] posiciones;
	public bool [] ocupadas;
	
	// Use this for initialization
	void Awake () {
		Accesos.sillas = this;
		ocupadas = new bool[posiciones.Length];
		for (int i = 0; i < posiciones.Length; i++) {
			ocupadas [i] = false;
		}
	}
	
}
