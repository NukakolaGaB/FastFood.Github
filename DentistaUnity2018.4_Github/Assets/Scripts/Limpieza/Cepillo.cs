using UnityEngine;
using System.Collections;

public class Cepillo : MonoBehaviour {

	 float velocidadLimp;

	 Diente diente;

	[SerializeField] AudioSource sonido;
	[SerializeField] GameObject cepilloparti;

	public MoverImagen moverImagen;

	Transform myTransform;
	Vector3 posAnt;
	float angulo;
	float deltaX;
	float deltaY;

	// Use this for initialization
	void Start () {
	
		myTransform = transform;
		sonido = GetComponent<AudioSource> ();
		velocidadLimp = Cantidades.velCepillo;

	}

	void OnTriggerEnter2D (Collider2D col) {

		if (diente == null) {
			diente = col.GetComponent<Diente> ();
		}
		posAnt = myTransform.position;
	}
	void OnTriggerStay2D (Collider2D col) {
		if (diente == null) {
			diente = col.GetComponent<Diente> ();
		}
		if (myTransform.position != posAnt && diente != null && moverImagen.usando && Accesos.relojOn) {
			deltaX = myTransform.position.x - posAnt.x;
			deltaY = myTransform.position.y - posAnt.y;
			if (deltaX >= 0 && deltaY >= 0) {
				if (deltaX > deltaY) {
					angulo = 180f;
				} else {
					angulo = 90f;
				}
			} else if (deltaX <= 0 && deltaY >= 0) {
				if (-deltaX > deltaY) {
					angulo = 0f;
				} else {
					angulo = 90f;
				}
			} else if (deltaX <= 0 && deltaY <= 0) {
				if (deltaX > deltaY) {
					angulo = 0f;
				} else {
					angulo = -90f;
				}
			} else if (deltaX <= 0 && deltaY >= 0) {
				if (deltaX > -deltaY) {
					angulo = 180f;
				} else {
					angulo = 90f;
				}
			}
			sonido.mute = false;
			SimplePool.Spawn(cepilloparti,gameObject.transform.position, Quaternion.Euler (0, 0, angulo));
			if (diente.Limpiar (Time.deltaTime * (deltaX * deltaX + deltaY * deltaY) * velocidadLimp)) {
				sonido.mute = true;
				diente = null;
			}
		} else {
			sonido.mute = true;
		}
		posAnt = myTransform.position;

	}
	void OnTriggerExit2D (Collider2D col) {
		if (col.GetComponent<Diente> () == diente) {
			sonido.mute = true;
			diente = null;
		}
	}
}
