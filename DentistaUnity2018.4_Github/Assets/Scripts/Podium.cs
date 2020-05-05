using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Podium : MonoBehaviour {
	

	[SerializeField] Image [] imagenes;

	[SerializeField] Text [] puntos;


	
	string [] carpetaNinno = new string[] {
		"Podio/0",
		"Podio/1",
		"Podio/2",
		"Podio/3",
		"Podio/4",
		"Podio/5",
		"Podio/6",
		"Podio/7"};

	int [] podium = new int[] {1, 2, 3, 4};

	// Use this for initialization
	void Start () {
		for (int i = 0; i < Cantidades.numJugadores; i++) {
			for (int j = i+1; j < Cantidades.numJugadores; j++) {
				if (Cantidades.puntos [ podium [i]] < Cantidades.puntos [ podium [j]]) {
					Intercambiar (i, j);
				}
			}
		}

		for (int i = 0; i < Cantidades.numJugadores; i++) {
			puntos [i].text = Cantidades.nombreJug [podium [i]] +" : " + Cantidades.puntos [ podium [i]].ToString();
			string rutaAcceso = carpetaNinno [Accesos.ninno[podium [i]]];
			imagenes [i].sprite = Resources.Load <Sprite> (rutaAcceso) as Sprite;
		}

	}


	void Intercambiar (int a, int b) {
		int valorA = podium [a];
		podium [a] = podium [b];
		podium [b] = valorA;
	}

	public void Volver () {
		Application.LoadLevel (Escenas.escenaLanzar);
	}
}
