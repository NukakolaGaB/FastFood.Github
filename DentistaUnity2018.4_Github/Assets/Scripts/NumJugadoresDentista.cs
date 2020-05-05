using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class NumJugadoresDentista : MonoBehaviour {

	 [Tooltip ("CanvasParaActivar")]
	 [SerializeField] GameObject player1Canvas;
	[SerializeField] GameObject player2Canvas;
	[SerializeField] GameObject player3Canvas;
	[SerializeField] GameObject player4Canvas;

	[SerializeField] GameObject p1escena;
	[SerializeField] GameObject p2escena;
	[SerializeField] GameObject p3escena;
	[SerializeField] GameObject p4escena;









	// Use this for initialization
	void Awake () {

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

		player1Canvas.SetActive(true);
		p1escena.SetActive(true);
		//testTexure = Resources.Load("iPhone Standard Assets/Textures/sky_02" ) as Texture; 

		player2Canvas.SetActive(false);
		p2escena.SetActive(false);

		player3Canvas.SetActive(false);
		p3escena.SetActive(false);
		
		player4Canvas.SetActive(false);
		p4escena.SetActive(false);
	}

	 public void TwoPlayer () {

		player1Canvas.SetActive(false);
		p1escena.SetActive (false);

		player2Canvas.SetActive(true);
		p2escena.SetActive(true);

		player3Canvas.SetActive(false);
		p3escena.SetActive(false);

		player4Canvas.SetActive(false);
		p4escena.SetActive(false);
	 }

	 public void ThreePlayer () {

		player1Canvas.SetActive(false);
		p1escena.SetActive (false);
		
		player2Canvas.SetActive(false);
		p2escena.SetActive(false);

		player3Canvas.SetActive(true);
		p3escena.SetActive(true);

		player4Canvas.SetActive(false);
		p4escena.SetActive(false);

	 }

	 public void FourPlayer () {

		player1Canvas.SetActive(false);
		p1escena.SetActive (false);
		
		player2Canvas.SetActive(false);
		p2escena.SetActive(false);
		
		player3Canvas.SetActive(false);
		p3escena.SetActive(false);

		player4Canvas.SetActive(true);
		p4escena.SetActive(true);

		
	 }
}

