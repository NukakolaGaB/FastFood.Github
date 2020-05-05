using UnityEngine;
using System.Collections;

public class PlayerSprite : MonoBehaviour {


	[SerializeField] int numPLayer;

	string [] carpetaNumNinnos = new string[] {"", 
		"Bocas/UnNinno/",
		"Bocas/DosNinnos/",
		"Bocas/TresNinnos/",
		"Bocas/CuatroNinnos/"};

	string [] carpetaNinno = new string[] {
		"0CM",
		"1CaR",
		"2CA",
		"3CP",
		"4CN",
		"5CR",
		"6CAs",
		"7CaN"};


	// Use this for initialization
	void Awake () {

		string rutaAcceso = carpetaNumNinnos [Cantidades.numJugadores] + carpetaNinno [Accesos.ninno[numPLayer]];
		gameObject.GetComponent<SpriteRenderer> ().sprite = Resources.Load <Sprite> (rutaAcceso) as Sprite;
		//Debug.Log (rutaAcceso);
	}

}