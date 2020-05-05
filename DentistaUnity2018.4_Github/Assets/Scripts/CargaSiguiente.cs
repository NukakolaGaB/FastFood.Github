using UnityEngine;
using System.Collections;

public class CargaSiguiente : MonoBehaviour {

	[SerializeField] GameObject explicaLanza;
	[SerializeField] GameObject explicaDentista;

	// Use this for initialization
	void Start () {

		if (Escenas.escenaCargada == Escenas.escenaLanzar) {
			explicaLanza.SetActive (true);
			explicaDentista.SetActive (false);
		} else {
			explicaLanza.SetActive (false);
			explicaDentista.SetActive (true);
		}
		Invoke ("CargaEscena",2f);
	}

	void CargaEscena(){


		Application.LoadLevelAsync (Escenas.escenaCargada);



	}
}
