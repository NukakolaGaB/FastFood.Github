using UnityEngine;
using System.Collections;

public class ShowHideScore : MonoBehaviour {

	[SerializeField] Transform topScore;

	[SerializeField] float tiempoS;
	float tiempo;
	// Use this for initialization
	void Start () {
		TocarPantalla ();
	}
	
	// Update is called once per frame
	void Update () {
		if (tiempo > 0) {
			tiempo -= Time.deltaTime;
		} else {
			topScore.gameObject.SetActive (true);
		}
	}

	public void TocarPantalla () {
		topScore.gameObject.SetActive (false);
		tiempo = tiempoS;
	}
}
