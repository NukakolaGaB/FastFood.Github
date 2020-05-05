using UnityEngine;
using System.Collections;

public class Empezar : MonoBehaviour {


	public CambioMusica musica;
	public GameObject activarNumPlayers;
	// Use this for initialization
	void Start () {


		if (Escenas.ronda == 0) {
			musica.MusicaStart();
			Escenas.escenaCargada = Escenas.escenaLanzar;
			Cantidades.retrasoHambre = new float[] {0, 0, 0, 0 ,0 ,0 ,0 ,0};
			Cantidades.numJugadores = 0;
			Cantidades.alimentado = new int[] {0, 0, 0, 0, 0};
			Cantidades.sucio = new int[] {0, 0, 0, 0, 0};
			Cantidades.puntos = new int[] {0, 0, 0, 0, 0};

		} else {
		
			musica.MusicaJuego();
			activarNumPlayers.SetActive(true);
			gameObject.SetActive(false);
		
		}
	}
	
//	public void Comenzar () {
//		Escenas.escenaCargada = Escenas.escenaLanzar;
//		Application.LoadLevel (Escenas.escenaIntermedia);
//	}
}
