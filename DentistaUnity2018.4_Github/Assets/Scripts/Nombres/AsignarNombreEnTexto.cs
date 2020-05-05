using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class AsignarNombreEnTexto : MonoBehaviour {

	[SerializeField] int numJugador;

	// Use this for initialization
	void Start () {
		GetComponent<Text> ().text = Cantidades.nombreJug [numJugador];
	}
	
	// Update is called once per frame
	public void Asignar () {
		GetComponent<Text> ().text = Cantidades.nombreJug [numJugador];
	}
}
