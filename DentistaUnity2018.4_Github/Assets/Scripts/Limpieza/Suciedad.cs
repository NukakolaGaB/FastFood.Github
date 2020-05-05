using UnityEngine;
using System.Collections;

public class Suciedad : MonoBehaviour {

	public float sucio;
	public Diente diente;
	public Boca boca;

	SpriteRenderer mySprite;

	BoxCollider2D myCollider;

    public GameObject partSuciedadLimpio;

	// Use this for initialization
	void Start () {
		mySprite = GetComponent<SpriteRenderer> ();
		myCollider = GetComponent<BoxCollider2D> ();
		myCollider.enabled = false;
		ColorearDiente ();
	}

	public bool Limpiar (float limpia) {
		if (limpia <= sucio) {
			diente.suciedadTotal -= limpia;
			sucio -= limpia;
			ColorearDiente ();
			return false;
		} else {
			diente.suciedadTotal -= sucio;
			sucio = 0;
			ColorearDiente ();
			myCollider.enabled = false;
            SimplePool.Spawn(partSuciedadLimpio, gameObject.transform.position, gameObject.transform.rotation);
			boca.SuciedadLimpia ();
			//algo para avisar de que esta limpio
			return true;
		}
	}
	public void ColorearDiente () {
//		float alfa = 0.01f * sucio;
//		if (alfa > 0 && alfa < Cantidades.alfaMinima) {
//			alfa = Cantidades.alfaMinima;
//		}

		float alfa = 0.005f * sucio;
		if (alfa > 0f) {
			alfa += Cantidades.alfaMinima;
		}

//		Color colorSucio = new Color (0.5f, 0.25f, 0.25f, alfa);
//		mySprite.color = colorSucio;
		Color colorSucio = mySprite.color;
		colorSucio.a = alfa;
		mySprite.color = colorSucio;
	}

	public void ActivarCollider () {
		myCollider.enabled = true;
	}

}
