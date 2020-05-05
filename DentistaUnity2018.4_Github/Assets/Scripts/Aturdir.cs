using UnityEngine;
using System.Collections;

public class Aturdir : MonoBehaviour {

	//[SerializeField] SpriteRenderer estrellitas;
	[SerializeField] Animator animatorC;

	public bool aturdido;
	public AudioSource errorSonido;
	public SillaAleatoria sillaAleatoria;
	public float tiempoRecuperacion;

	// Use this for initialization
	void Start () {
		//estrellitas = gameObject.GetComponent<SpriteRenderer> ();
	}


	void OnCollisionEnter(Collision col) {
//	void OnTriggerEnter(Collider col){


		if (col.gameObject.tag == "Bola" && aturdido==false) {
			
			aturdido = true;
			errorSonido.Play();
			animatorC.SetBool("Aturdido",true);
			Invoke ("Recuperarse", tiempoRecuperacion);
		}
		
		
	}

	public void Recuperarse () {
		//estrellitas.enabled = false;

		aturdido = false;
		animatorC.SetBool("Aturdido",false);
		sillaAleatoria.CambioAturdir ();

	}
}
