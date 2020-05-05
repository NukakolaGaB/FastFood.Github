using UnityEngine;
using System.Collections;

public class CambioAnalogicoDigital : MonoBehaviour {

	[SerializeField] Transform relojA;
	[SerializeField] Transform relojD;

	bool analogico;

	// Use this for initialization
	void Start () {
		relojA.gameObject.SetActive (analogico);
		relojD.gameObject.SetActive (!analogico);
	}

	public void Cambiar () {
		analogico = !analogico;
		relojA.gameObject.SetActive (analogico);
		relojD.gameObject.SetActive (!analogico);
	}
}
