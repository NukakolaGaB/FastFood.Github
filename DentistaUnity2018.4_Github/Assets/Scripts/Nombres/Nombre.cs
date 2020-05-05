using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Nombre : MonoBehaviour {

	[SerializeField] int numJugador;
	[SerializeField] Text [] letras;
	[SerializeField] string nombre = "";
	[SerializeField] Nombres nombres;

	[SerializeField] AsignarNombreEnTexto asignarNombreEnTexto;

	// Use this for initialization
	void Start () {
	
		if (Escenas.ronda != 0) {
			gameObject.SetActive (false);
		}
	}
	

	public void Nombrar () {

		if (Escenas.ronda == 0) {

			nombre = "";

			foreach (Text letra in letras) {
				nombre += letra.text;
			}
			Cantidades.nombreJug [numJugador] = nombre;
			asignarNombreEnTexto.Asignar ();
//			nombres.MeteNombre ();
		}
	}
}
