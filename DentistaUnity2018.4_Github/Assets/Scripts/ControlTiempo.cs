using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ControlTiempo : MonoBehaviour {

	[SerializeField] Text textoTiempoRestante;
	float tiempoRestante;

	[SerializeField] Image reloj;
	[SerializeField] Transform manecillaSegundero;
	[SerializeField] Transform manecillaMinutero;
	[Tooltip ("tiempoque dura esta fase, en segundos")]
	[SerializeField] float tiempoDeJuego;
	[Tooltip ("Cuando quedan menos de estos segundos pita")]
	[SerializeField] float tiempoLimite;
	float inversoTiempoJuego;
	float contadorTiempo;
	float segundero;
	float minutero;

	[SerializeField] NuevaComida nuevaComida;

	[SerializeField] Sprite [] cuentaAtras;
	int indiceCuentaAtras;
	[SerializeField] Sprite fin;

	[SerializeField] AudioSource sonidoCA;
	[SerializeField] AudioSource sonidoFinal;

	[SerializeField] GameObject finalText;
	[SerializeField] GameObject infoDentista;
	[SerializeField] GameObject infoJuego;
	public CambioMusica cambioMusica;

	int jugadoresActivos = 0;
	int jugadoresPuntuados = 0;

	public Marcador [] marcadores = new Marcador[5];

    [SerializeField]
    Apuntar image1;
    [SerializeField]
    Apuntar image2;
    [SerializeField]
    Apuntar image3;
    [SerializeField]
    Apuntar image4;

    // Use this for initialization
    void Awake () {
		Accesos.controlTiempoLanzaComida = this;
        Accesos.relojOn = false;
	}
	void Start () {

		indiceCuentaAtras = cuentaAtras.Length - 1;

		contadorTiempo = tiempoDeJuego;
		textoTiempoRestante.text = Mathf.CeilToInt (contadorTiempo).ToString();

		inversoTiempoJuego = 1 / tiempoDeJuego;
	}
	
	// Update is called once per frame
	void Update () {

		if (Accesos.relojOn) {
			if (contadorTiempo > 0) {
				contadorTiempo -= Time.deltaTime;
				textoTiempoRestante.text = Mathf.CeilToInt (contadorTiempo).ToString();

				reloj.fillAmount = contadorTiempo * inversoTiempoJuego;
			} else {
				textoTiempoRestante.text = "0";
				Accesos.relojOn=false;
				sonidoFinal.Play();
				finalText.SetActive(true);
                nuevaComida.SeAcabaLaComida();
                nuevaComida.imagenSiguienteComida.sprite = fin;
                nuevaComida.imagenSiguienteComida1.sprite = fin;
                Invoke("FinFase",1f);
			}
			if (segundero >= 1f) {
				segundero -= 1f;

				manecillaSegundero.Rotate (0f, 0f, -6f);
				if (contadorTiempo < tiempoLimite) {
					sonidoCA.Play ();
				}
			}
			segundero += Time.deltaTime;

			if (minutero >= 60f) {
				minutero -= 60f;
				manecillaMinutero.Rotate (0f, 0f, -6f);
			}
			minutero += Time.deltaTime;
		}
	}

//	void PonerComidaJugadoresCero () {
//		Cantidades.alimentado = new int[] {0, 0, 0, 0};
//	}

	public void JugadorPulsaStart () {

		jugadoresActivos++;
		if (jugadoresActivos == Cantidades.numJugadores) {
			LanzarCuentaAtras ();
		}
	}

	void LanzarCuentaAtras () {

		sonidoCA.Play ();
		if (indiceCuentaAtras >= 0) {
			nuevaComida.imagenSiguienteComida.sprite = cuentaAtras [indiceCuentaAtras];
			nuevaComida.imagenSiguienteComida1.sprite = cuentaAtras [indiceCuentaAtras];
			Invoke ("LanzarCuentaAtras", 0.5f);
			indiceCuentaAtras--;
		} else {
			nuevaComida.PrimeraComida ();
			Accesos.relojOn = true;
            image1.ForzarVolver();
            image2.ForzarVolver();
            image3.ForzarVolver();
            image4.ForzarVolver();

        }
    }

	public void FinFase () {


		for (int i = 1; i <= Cantidades.numJugadores; i++) {
			marcadores [i].DarPuntos ();
		}
		
	}
	
	public void CargaEscena () {
		
		jugadoresPuntuados++;
		if (jugadoresPuntuados == Cantidades.numJugadores) {
			if (Escenas.ronda == 0) {
				
				infoDentista.SetActive (true);
				cambioMusica.MusicaInfo ();

			}
			else if(Escenas.ronda==1){

				infoJuego.SetActive (true);
				cambioMusica.MusicaInfo ();


			}
			Invoke ("CargarLaEscena", 4f);
		}

	}
	
	void CargarLaEscena () {

//		if (Escenas.ronda == 0) {
//
//			infoDentista.SetActive (true);
//			cambioMusica.MusicaInfo ();
//		}
		//Escenas.escenaCargada = Escenas.escenaDentista;
		Application.LoadLevel (Escenas.escenaDentista);
	}

	public int JugadorTermina () {
		
		jugadoresActivos--;
		if (jugadoresActivos <= 0) {

			Accesos.relojOn=false;
			FinFase ();
		}
		return Cantidades.numJugadores - jugadoresActivos;
	}
}
