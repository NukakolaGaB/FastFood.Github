using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEditor.SceneManagement;

public class ControlTiempoLimpieza : MonoBehaviour {

	[SerializeField] Text textoTiempoRestante;
	float tiempoRestante;

	[SerializeField] Image imagenCuentaAtras;

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

	[SerializeField] Sprite [] cuentaAtras;
	int indiceCuentaAtras;
	[SerializeField] Sprite fin;
    [SerializeField]
    GameObject finalText;
    [SerializeField] AudioSource sonidoCA;
	

	int jugadoresActivos = 0;

	Boca [] bocas = new Boca[0];

	// Use this for initialization
	void Awake () {
		Accesos.controlTiempoLimpieza = this;
	}

	void Start () {

		jugadoresActivos = Cantidades.numJugadores;

		indiceCuentaAtras = cuentaAtras.Length - 1;

		contadorTiempo = tiempoDeJuego;
		textoTiempoRestante.text = Mathf.CeilToInt (contadorTiempo).ToString();
		inversoTiempoJuego = 1 / tiempoDeJuego;

		LanzarCuentaAtras ();
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
					Accesos.relojOn = false;
					FinFase ();
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

	void LanzarCuentaAtras () {
		
		sonidoCA.Play ();
		if (indiceCuentaAtras >= 0) {
			imagenCuentaAtras.sprite = cuentaAtras [indiceCuentaAtras];
			Invoke ("LanzarCuentaAtras", 0.5f);
			indiceCuentaAtras--;
		} else {
			imagenCuentaAtras.enabled = false;
			Accesos.relojOn = true;
		}	
	}
	
	void FinFase () {

		foreach (Boca boca in bocas) {
			boca.CalculoTotalSuciedad ();
		}
        finalText.SetActive(true);
        imagenCuentaAtras.enabled = true;
		imagenCuentaAtras.sprite = fin;
		Invoke ("CargaEscena", 2f);
	}
	
	void CargaEscena () {

		if (Escenas.ronda == 1) {
			Escenas.ronda = 0;
			EditorSceneManager.LoadScene (Escenas.escenaPodium);
		} else {
			Escenas.ronda ++;
			EditorSceneManager.LoadScene (Escenas.escenaLanzar);
		}
	}

	public int JugadorTermina () {
		
		jugadoresActivos--;
		if (jugadoresActivos <= 0) {
			FinFase ();
		}
		return Cantidades.numJugadores - jugadoresActivos;
	}

	public void NuevaBoca (Boca boca) {
		Boca[] temp = new Boca[bocas.Length +1];
		for (int i = 0; i < bocas.Length; i++) {
			temp [i] = bocas [i];
		}
		temp [bocas.Length] = boca;
		bocas = temp;
	}
}
