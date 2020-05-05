using UnityEngine;
using System.Collections;

public class CambioMusica : MonoBehaviour {

	public AudioSource seleccionPersonaje;

	public AudioClip start;
	public AudioClip info;
	public AudioClip clipSeleccionPersonaje;
	public AudioClip juego;


	public void MusicaJugadores(){

		seleccionPersonaje.Stop ();
//		seleccionPersonaje.PlayOneShot (clipSeleccionPersonaje);
		seleccionPersonaje.clip = clipSeleccionPersonaje;
		seleccionPersonaje.Play ();

	}
	public void MusicaJuego(){
		
		seleccionPersonaje.Stop ();
//		seleccionPersonaje.PlayOneShot (juego);
		seleccionPersonaje.clip = juego;
		seleccionPersonaje.Play ();
		
	}
	public void MusicaStart(){
		
		seleccionPersonaje.Stop ();
//		seleccionPersonaje.PlayOneShot (start);
		seleccionPersonaje.clip = start;
		seleccionPersonaje.Play ();
		
	}
	public void MusicaInfo(){
		
		seleccionPersonaje.Stop ();
//		seleccionPersonaje.PlayOneShot (info);
		seleccionPersonaje.clip = info;
		seleccionPersonaje.Play ();
		
	}
}
