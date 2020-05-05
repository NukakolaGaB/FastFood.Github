using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class NumJugadores : MonoBehaviour {

	 [Tooltip ("posiciones donde colocar los tirachinas")]
	 [SerializeField] Transform pos1;
	 [Tooltip ("posiciones donde colocar los tirachinas")]
	 [SerializeField] Transform pos2;
	 [Tooltip ("posiciones donde colocar los tirachinas")]
	 [SerializeField] Transform pos3;
	 [Tooltip ("posiciones donde colocar los tirachinas")]
	 [SerializeField] Transform pos4;
	 [Tooltip ("posiciones donde colocar los tirachinas")]
	 [SerializeField] Transform pos5;
	 [Tooltip ("posiciones donde colocar los tirachinas")]
	 [SerializeField] Transform pos6;
	 [Tooltip ("posiciones donde colocar los tirachinas")]
	 [SerializeField] Transform pos7;


	[SerializeField] Transform tirachinas1;
	[SerializeField] Transform tirachinas2;
	[SerializeField] Transform tirachinas3;
	[SerializeField] Transform tirachinas4;

	[SerializeField] Transform apuntador1;
	[SerializeField] Transform apuntador2;
	[SerializeField] Transform apuntador3;
	[SerializeField] Transform apuntador4;

	[SerializeField] Transform player1Panel;
	[SerializeField] Transform player2Panel;
	[SerializeField] Transform player3Panel;
	[SerializeField] Transform player4Panel;

	[SerializeField] Transform Panelplayer1;
	[SerializeField] Transform Panelplayer2;
	[SerializeField] Transform Panelplayer3;
	[SerializeField] Transform Panelplayer4;

//	[SerializeField] Transform asignaNombre1;
//	[SerializeField] Transform asignaNombre2;
//	[SerializeField] Transform asignaNombre3;
//	[SerializeField] Transform asignaNombre4;

//	public GameObject nombres;
	[SerializeField] GameObject activaFichasPadrePlayer;


	// Use this for initialization
	void Start () {

		if (Cantidades.numJugadores == 4) {
			FourPlayer ();
			gameObject.SetActive (false);
		} else if (Cantidades.numJugadores == 3) {
			ThreePlayer ();
			gameObject.SetActive (false);
		} else if (Cantidades.numJugadores == 2) {
			TwoPlayer ();
			gameObject.SetActive (false);
		} else if (Cantidades.numJugadores == 1) {
			OnePlayer ();
			gameObject.SetActive (false);
		}
	}

	public void OnePlayer () {

		activaFichasPadrePlayer.SetActive (true);
		Cantidades.numJugadores = 1;

		tirachinas1.position = pos4.position;
		tirachinas1.gameObject.SetActive (true);
		tirachinas2.gameObject.SetActive (false);
		tirachinas3.gameObject.SetActive (false);
		tirachinas4.gameObject.SetActive (false);

		apuntador1.gameObject.SetActive (true);
		apuntador1.GetComponent<Apuntar> ().Inicializar ();
		apuntador2.gameObject.SetActive (false);
		apuntador3.gameObject.SetActive (false);
		apuntador4.gameObject.SetActive (false);

		player1Panel.gameObject.SetActive (true);
		player1Panel.gameObject.transform.position = new Vector2 (Camera.main.pixelWidth*0.5f,Camera.main.pixelHeight*0.5f);
		player1Panel.GetComponent<SelectorNinno> ().InicializarNinno ();
		player2Panel.gameObject.SetActive (false);
		player3Panel.gameObject.SetActive (false);
		player4Panel.gameObject.SetActive (false);

		Panelplayer1.gameObject.SetActive (true);
		Panelplayer1.transform.position= new Vector2 (Camera.main.pixelWidth*0.40f, Camera.main.pixelHeight * 0.1f);
		Panelplayer2.gameObject.SetActive (false);
		Panelplayer3.gameObject.SetActive (false);
		Panelplayer4.gameObject.SetActive (false);

//		asignaNombre1.gameObject.SetActive (true);
//		asignaNombre1.transform.position= new Vector2 (Camera.main.pixelWidth*0.40f,Camera.main.pixelHeight * 0.1f);
//		asignaNombre2.gameObject.SetActive (false);
//		asignaNombre3.gameObject.SetActive (false);
//		asignaNombre4.gameObject.SetActive (false);

		gameObject.SetActive (false);

	}

	 public void TwoPlayer () {

		activaFichasPadrePlayer.SetActive (true);

		Cantidades.numJugadores = 2;

		tirachinas1.position = pos2.position;
		tirachinas1.gameObject.SetActive (true);
		tirachinas2.position = pos6.position;
		tirachinas2.gameObject.SetActive (true);
		tirachinas3.gameObject.SetActive (false);
		tirachinas4.gameObject.SetActive (false);
		
		apuntador1.gameObject.SetActive (true);
		apuntador1.GetComponent<Apuntar> ().Inicializar ();
		apuntador2.gameObject.SetActive (true);
		apuntador2.GetComponent<Apuntar> ().Inicializar ();
		apuntador3.gameObject.SetActive (false);
		apuntador4.gameObject.SetActive (false);
		
		player1Panel.gameObject.SetActive (true);
		player1Panel.gameObject.transform.position = new Vector2 (Camera.main.pixelWidth*0.3f,Camera.main.pixelHeight*0.5f);
		player1Panel.GetComponent<SelectorNinno> ().InicializarNinno ();
		player2Panel.gameObject.SetActive (true);
		player2Panel.gameObject.transform.position = new Vector2 (Camera.main.pixelWidth*0.7f,Camera.main.pixelHeight*0.5f);
		player2Panel.GetComponent<SelectorNinno> ().InicializarNinno ();
		player3Panel.gameObject.SetActive (false);
		player4Panel.gameObject.SetActive (false);

		Panelplayer1.gameObject.SetActive (true);
		Panelplayer1.transform.position= new Vector2 (Camera.main.pixelWidth*0.2f,Camera.main.pixelHeight * 0.1f);
		Panelplayer2.gameObject.SetActive (true);
		Panelplayer2.transform.position= new Vector2 (Camera.main.pixelWidth*0.6f,Camera.main.pixelHeight * 0.1f);
		Panelplayer3.gameObject.SetActive (false);
		Panelplayer4.gameObject.SetActive (false);

//		asignaNombre1.gameObject.SetActive (true);
//		asignaNombre1.transform.position= new Vector2 (Camera.main.pixelWidth*0.2f,Camera.main.pixelHeight * 0.1f);
//		asignaNombre2.gameObject.SetActive (true);
//		asignaNombre2.transform.position= new Vector2 (Camera.main.pixelWidth*0.6f,Camera.main.pixelHeight * 0.1f);
//		asignaNombre3.gameObject.SetActive (false);
//		asignaNombre4.gameObject.SetActive (false);

		gameObject.SetActive (false);

		
	 }

	 public void ThreePlayer () {

		activaFichasPadrePlayer.SetActive (true);

		Cantidades.numJugadores = 3;

		tirachinas1.position = pos1.position;
		tirachinas1.gameObject.SetActive (true);
		tirachinas2.position = pos4.position;
		tirachinas2.gameObject.SetActive (true);
		tirachinas3.position = pos7.position;
		tirachinas3.gameObject.SetActive (true);
		tirachinas4.gameObject.SetActive (false);
		
		apuntador1.gameObject.SetActive (true);
		apuntador1.GetComponent<Apuntar> ().Inicializar ();
		apuntador2.gameObject.SetActive (true);
		apuntador2.GetComponent<Apuntar> ().Inicializar ();
		apuntador3.gameObject.SetActive (true);
		apuntador3.GetComponent<Apuntar> ().Inicializar ();
		apuntador4.gameObject.SetActive (false);
		
		player1Panel.gameObject.SetActive (true);
		player1Panel.GetComponent<SelectorNinno> ().InicializarNinno ();
		player1Panel.gameObject.transform.position = new Vector2 (Camera.main.pixelWidth*0.2f,Camera.main.pixelHeight*0.5f);
		player2Panel.gameObject.SetActive (true);
		player2Panel.GetComponent<SelectorNinno> ().InicializarNinno ();
		player2Panel.gameObject.transform.position = new Vector2 (Camera.main.pixelWidth*0.5f,Camera.main.pixelHeight*0.5f);
		player3Panel.gameObject.SetActive (true);
		player3Panel.GetComponent<SelectorNinno> ().InicializarNinno ();
		player3Panel.gameObject.transform.position = new Vector2 (Camera.main.pixelWidth*0.8f,Camera.main.pixelHeight*0.5f);
		player4Panel.gameObject.SetActive (false);

		Panelplayer1.gameObject.SetActive (true);
		Panelplayer1.transform.position= new Vector2 (Camera.main.pixelWidth*0.1f,Camera.main.pixelHeight * 0.1f);
		Panelplayer2.gameObject.SetActive (true);
		Panelplayer2.transform.position= new Vector2 (Camera.main.pixelWidth*0.40f,Camera.main.pixelHeight * 0.1f);
		Panelplayer3.gameObject.SetActive (true);
		Panelplayer3.transform.position= new Vector2 (Camera.main.pixelWidth*0.7f,Camera.main.pixelHeight * 0.1f);
		Panelplayer4.gameObject.SetActive (false);

//		asignaNombre1.gameObject.SetActive (true);
//		asignaNombre1.transform.position= new Vector2 (Camera.main.pixelWidth*0.1f,Camera.main.pixelHeight * 0.1f);
//		asignaNombre2.gameObject.SetActive (true);
//		asignaNombre2.transform.position= new Vector2 (Camera.main.pixelWidth*0.40f,Camera.main.pixelHeight * 0.1f);
//		asignaNombre3.gameObject.SetActive (true);
//		asignaNombre3.transform.position= new Vector2 (Camera.main.pixelWidth*0.7f,Camera.main.pixelHeight * 0.1f);
//		asignaNombre4.gameObject.SetActive (false);

		gameObject.SetActive (false);

		
	 }

	 public void FourPlayer () {

		activaFichasPadrePlayer.SetActive (true);

		Cantidades.numJugadores = 4;

		tirachinas1.position = pos1.position;
		tirachinas1.gameObject.SetActive (true);
		tirachinas2.position = pos3.position;
		tirachinas2.gameObject.SetActive (true);
		tirachinas3.position = pos5.position;
		tirachinas3.gameObject.SetActive (true);
		tirachinas4.position = pos7.position;
		tirachinas4.gameObject.SetActive (true);
		
		apuntador1.gameObject.SetActive (true);
		apuntador1.GetComponent<Apuntar> ().Inicializar ();
		apuntador2.gameObject.SetActive (true);
		apuntador2.GetComponent<Apuntar> ().Inicializar ();
		apuntador3.gameObject.SetActive (true);
		apuntador3.GetComponent<Apuntar> ().Inicializar ();
		apuntador4.gameObject.SetActive (true);
		apuntador4.GetComponent<Apuntar> ().Inicializar ();
		
		player1Panel.gameObject.SetActive (true);
		player1Panel.GetComponent<SelectorNinno> ().InicializarNinno ();
		player1Panel.gameObject.transform.position = new Vector2 (Camera.main.pixelWidth*0.125f,Camera.main.pixelHeight*0.5f);
		player2Panel.gameObject.SetActive (true);
		player2Panel.GetComponent<SelectorNinno> ().InicializarNinno ();
		player2Panel.gameObject.transform.position = new Vector2 (Camera.main.pixelWidth*0.375f,Camera.main.pixelHeight*0.5f);
		player3Panel.gameObject.SetActive (true);
		player3Panel.GetComponent<SelectorNinno> ().InicializarNinno ();
		player3Panel.gameObject.transform.position = new Vector2 (Camera.main.pixelWidth*0.625f,Camera.main.pixelHeight*0.5f);
		player4Panel.gameObject.SetActive (true);
		player4Panel.GetComponent<SelectorNinno> ().InicializarNinno ();
		player4Panel.gameObject.transform.position = new Vector2 (Camera.main.pixelWidth*0.875f,Camera.main.pixelHeight*0.5f);

		Panelplayer1.gameObject.SetActive (true);
		Panelplayer1.transform.position= new Vector2 (Camera.main.pixelWidth*0.075f,Camera.main.pixelHeight * 0.1f);
		Panelplayer2.gameObject.SetActive (true);
		Panelplayer2.transform.position= new Vector2 (Camera.main.pixelWidth*0.275f,Camera.main.pixelHeight * 0.1f);
		Panelplayer3.gameObject.SetActive (true);
		Panelplayer3.transform.position= new Vector2 (Camera.main.pixelWidth*0.7f,Camera.main.pixelHeight * 0.1f);
		Panelplayer4.gameObject.SetActive (true);
		Panelplayer4.transform.position= new Vector2 (Camera.main.pixelWidth*0.9f,Camera.main.pixelHeight * 0.1f);

//		asignaNombre1.gameObject.SetActive (true);
//		asignaNombre1.transform.position= new Vector2 (Camera.main.pixelWidth*0.075f,Camera.main.pixelHeight * 0.1f);
//		asignaNombre2.gameObject.SetActive (true);
//		asignaNombre2.transform.position= new Vector2 (Camera.main.pixelWidth*0.275f,Camera.main.pixelHeight * 0.1f);
//		asignaNombre3.gameObject.SetActive (true);
//		asignaNombre3.transform.position= new Vector2 (Camera.main.pixelWidth*0.7f,Camera.main.pixelHeight * 0.1f);
//		asignaNombre4.gameObject.SetActive (true);
//		asignaNombre4.transform.position= new Vector2 (Camera.main.pixelWidth*0.9f,Camera.main.pixelHeight * 0.1f);

		gameObject.SetActive (false);

		
	 }
}

