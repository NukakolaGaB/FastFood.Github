using UnityEngine;
using System.Collections;

public class Carie : MonoBehaviour {

	public float carie;
	public Diente diente;
	public Boca boca;


	SpriteRenderer mySprite;

	CircleCollider2D myCollider;

    public GameObject partCarieLimpia;
    // Use this for initialization
    void Start () {
		mySprite = GetComponent<SpriteRenderer> ();
		myCollider = GetComponent<CircleCollider2D> ();
		myCollider.enabled = false;
		ColorearDiente ();
	}

	public bool Arreglar (float arreglo) {
		if (diente.suciedadTotal <= 999) {
			if (arreglo <= carie) {
				carie -= arreglo;
				ColorearDiente ();
				return false;
			} else {
				carie = 0;
				ColorearDiente ();
                SimplePool.Spawn(partCarieLimpia, gameObject.transform.position, gameObject.transform.rotation);
                boca.CarieArreglada ();
				myCollider.enabled = false;
				//algo para avisar de que esta curada
				return true;
			}
		} else {
			return true;
		}
	}


	public void ColorearDiente () {
		float alfa = 0.01f * carie;
		Color colorSucio = new Color (0f, 0f, 0f, alfa);
		mySprite.color = colorSucio;
	}

	public void ActivarCollider () {
		myCollider.enabled = true;
	}

}
