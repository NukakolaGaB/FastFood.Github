using UnityEngine;
using System.Collections;

public class ImpactoReaccion : MonoBehaviour {

	public AudioSource umm;
	public AudioSource acierto;
	[SerializeField] AudioClip rico;
	[SerializeField] AudioClip ay;

	public Sprite spriteNinno;
	public Sprite spritePlayer;
	public Marcador marcador;
	public Color colorTirachinas;

	bool duelenMuelas;
	float duracionDolor = 3f;
	[SerializeField] Animator animatorC;
	[SerializeField] Aturdir aturdir;
	//Renderer myRenderer;

	public int numNinno;

	[SerializeField] Comida comidaA1;
	[SerializeField] Comida comidaA2;

	public bool asignado;

	[SerializeField] Collider cabezaColl;
	[SerializeField] Collider bocaColl;

    [SerializeField] SillaAleatoria sillaAleatoria;

    // Use this for initialization
    void Awake () {

		Cantidades.imagenesNinnos [numNinno] = spritePlayer;

		Accesos.asignadorNinnos.ninnos [numNinno] = this;
		//myRenderer = gameObject.GetComponent<Renderer> ();
	}
	void Start(){
	
		float tiempoCambio = gameObject.GetComponentInParent<SillaAleatoria> ().tiempoCambio;
		float tiempoRecuperacion = gameObject.GetComponentInChildren<Aturdir> ().tiempoRecuperacion;
		Cantidades.velocidadNinno [numNinno] = 2/tiempoCambio;
		Cantidades.fuerzaNinno [numNinno] = 1/tiempoRecuperacion;
		duracionDolor = tiempoRecuperacion;

		comidaA1.cuantoAlimenta [numNinno] = 15;
		comidaA2.cuantoAlimenta [numNinno] = 15;
		Accesos.comidaAfin [numNinno] = comidaA1.sprite.sprite;
		Accesos.comidaAfin2 [numNinno] = comidaA2.sprite.sprite;

	
	}

    public void CambioSilla()
    {

        sillaAleatoria.Cambio();


    }
	void OnCollisionEnter(Collision col){

		if (col.gameObject.tag == "Bola") {
			if(aturdir.aturdido==false){
			animatorC.SetBool("Acierto",true);

			if (marcador != null) {
				Comida comida = col.gameObject.GetComponent<Comida>();
				if (comida != null && !duelenMuelas) {
					marcador.Comer (comida.CuantoAlimenta (numNinno), comida.CuantoEnsucia (numNinno));
					if (marcador.Muysucio()) {
						DolorMuelas ();
					} else {
						ComeBien ();
					}
				} else {
					umm.PlayOneShot (ay);
				}

			} else {
				ComeBien ();
			}
			}
		}


	}

	void ComeBien () {
		//myRenderer.material.color = Color.green;
//		umm.enabled=true;
		umm.PlayOneShot (rico);
		acierto.Play ();
		//Invoke ("CambioColor",1.2f);

	}
	public void CogerStop(){

		animatorC.SetBool("Acierto",false);


	}
	public void CambioColor(){

		//myRenderer.material.color = Color.white;
//		umm.enabled=false;
	}
	public void ApagarTriggers () {
	
		cabezaColl.enabled = false;
		bocaColl.enabled = false;
	
	}
	public void EncenderTriggers () {

		cabezaColl.enabled = true;
		bocaColl.enabled = true;

	}
	public void DolorMuelas () {
		//myRenderer.material.color = Color.red;
		umm.PlayOneShot (ay);
		animatorC.SetBool("Suciedad",true);
		Invoke ("RecuperarseDolor", duracionDolor);
		duelenMuelas = true;
	}

	public void RecuperarseDolor () {
		//myRenderer.material.color = Color.white;
		duelenMuelas = false;
		animatorC.SetBool("Suciedad",false);
	}

}
