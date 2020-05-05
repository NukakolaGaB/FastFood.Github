using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Powers : MonoBehaviour {

	public SillaAleatoria sillaAleatoria;
	public Aturdir aturdir;
	public Image imgNinno;

	// Use this for initialization
	void Start () {

		if (gameObject.name == "Vel") {
			float cantidadSilla = gameObject.GetComponent<Image> ().fillAmount;
			cantidadSilla = sillaAleatoria.tiempoCambio * 0.1f;

		} else if (gameObject.name == "Fuerza") {

			float cantidadAturdir = gameObject.GetComponent<Image> ().fillAmount;
			cantidadAturdir = aturdir.tiempoRecuperacion * 0.1f;
		}
	}

}
