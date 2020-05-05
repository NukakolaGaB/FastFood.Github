using UnityEngine;
using System.Collections;

public class Rascador : MonoBehaviour {

	 float velocidadLimp;
	
	 Suciedad suciedad;

	[SerializeField] AudioSource sonido;

	public GameObject suciedadparti;

	Transform myTransform;
	Vector3 posAnt;

	public MoverImagen moverImagen;

	// Use this for initialization
	void Start () {
		
		myTransform = transform;
		sonido = GetComponent<AudioSource> ();
		velocidadLimp = Cantidades.velRasca;

	}

	void OnTriggerEnter2D (Collider2D col) {
		
		if (suciedad == null) {
			suciedad = col.GetComponent<Suciedad> ();
		}
		posAnt = myTransform.position;
	}
	void OnTriggerStay2D (Collider2D col) {
		if (suciedad == null) {
			suciedad = col.GetComponent<Suciedad> ();
		}
		if (myTransform.position != posAnt && suciedad != null && moverImagen.usando && Accesos.relojOn) {
			sonido.mute = false;
			SimplePool.Spawn(suciedadparti,gameObject.transform.position,gameObject.transform.rotation);
			if (suciedad.Limpiar (Time.deltaTime * velocidadLimp)) {
				sonido.mute = true;
				suciedad = null;
				}
		} else {
			sonido.mute = true;
		}
		posAnt = myTransform.position;
	}
	void OnTriggerExit2D (Collider2D col) {
		if (col.GetComponent<Suciedad> () == suciedad) {
			sonido.mute = true;
			suciedad = null;
		}
	}
}
