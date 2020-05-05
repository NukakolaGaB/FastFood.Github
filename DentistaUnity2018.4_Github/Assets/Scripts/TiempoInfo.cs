using UnityEngine;
using System.Collections;

public class TiempoInfo : MonoBehaviour {


	[SerializeField] float tiempo = 3f;
	public CambioMusica cambioMusica;
	public GameObject siguienteActivar;
	//public GameObject siguienteActivar2;

	// Use this for initialization
	void OnEnable () {

		Invoke ("Desactivar", tiempo);

	}
	
	// Update is called once per frame
	void Desactivar () {
	
		cambioMusica.MusicaJugadores ();	
		gameObject.SetActive (false);
		siguienteActivar.SetActive (true);
		//siguienteActivar2.SetActive (true);

	}
}
