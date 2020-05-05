using UnityEngine;
using System.Collections;

public class Diente : MonoBehaviour {

	public float sucio;
	public float suciedadTotal;

	public Boca boca;
//	public AudioSource sonidoDienteLimpio;
	public GameObject partDienteLimp;

	public Suciedad [] suciedad;
	public Carie [] carie;

	SpriteRenderer mySprite;

	BoxCollider2D myCollider;

	// Use this for initialization
	void Start () {
	
		mySprite = GetComponent<SpriteRenderer> ();
		myCollider = GetComponent<BoxCollider2D> ();
		myCollider.enabled = false;

		suciedad = GetComponentsInChildren<Suciedad> ();
		carie = GetComponentsInChildren<Carie> ();

		suciedadTotal = sucio;
		foreach (Suciedad sucia in suciedad) {
			sucia.diente = this;
			suciedadTotal += sucia.sucio;
		}
		foreach (Carie cariada in carie) {
			cariada.diente = this;
		}
		ColorearDiente ();
	}

	public bool Limpiar (float limpia) {
		if (limpia <= sucio) {
			suciedadTotal -= limpia;
			sucio -= limpia;
			ColorearDiente ();
			return false;
		} else {
			suciedadTotal -= sucio;
			sucio = 0;
			boca.DienteLimpio ();
			ColorearDiente ();
			myCollider.enabled = false;
			//sonidoDienteLimpio.Play();
			SimplePool.Spawn(partDienteLimp,gameObject.transform.position,gameObject.transform.rotation);
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

		Color colorSucio = new Color (0.5f, 0.2f, 0.2f, alfa);
		mySprite.color = colorSucio;
	}

	public void ActivarCollider () {
		myCollider.enabled = true;
	}

}
