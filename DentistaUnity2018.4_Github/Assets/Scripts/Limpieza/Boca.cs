using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Boca : MonoBehaviour {

	public int pruebaSumarSuciedad;

	public Diente [] dientes;

	public int player;

	[SerializeField] Image barraSuciedad;
	[SerializeField] int suciedadBoca = 0;
	bool hecho;

	[SerializeField] int valorDiente = 3;
	[SerializeField] int valorSuciedad = 5;
	[SerializeField] int valorCarie = 10;

	public AudioSource sonidosLimpio;
	public AudioClip sonidoDienteLimpio;
	public AudioClip sonidoRaspaLimpio;
	public AudioClip sonidoCarieLimpio;
	public AudioClip sonidoTodoLimpio;

	[SerializeField] Text mensajeCompletado; 
	[SerializeField] Text puntos; 
	[SerializeField] Text puntosFinales; 


	bool sumar;
	bool restar;
	float sumador;
	[SerializeField] float velocidadSuma = 50;

	public AudioClip puntosSonido;


	// Use this for initialization
	void Start () {
		dientes = GetComponentsInChildren<Diente> ();
		foreach (Diente diente in dientes) {
			diente.gameObject.layer = LayerMask.NameToLayer ("Cepillo"+player.ToString());
			foreach (Suciedad suciedad in diente.suciedad) {
				suciedad.gameObject.layer = LayerMask.NameToLayer ("Raspador"+player.ToString());
			}
			foreach (Carie carie in diente.carie) {
				carie.gameObject.layer = LayerMask.NameToLayer ("Torno"+player.ToString());
			}
		}

		EnsuciarDientes (Cantidades.sucio [player] +10);

		puntos.text = Cantidades.puntos [player].ToString();
		mensajeCompletado.enabled = false;
		Accesos.controlTiempoLimpieza.NuevaBoca (this);
	}
	
	// Update is called once per frame
	void Update () {
//		if (Input.GetKeyDown (KeyCode.Space) && !hecho) {
//			EnsuciarDientes (pruebaSumarSuciedad);
//			hecho = true;
//		}
//		else if (Application.platform == RuntimePlatform.Android && !hecho) {
//			EnsuciarDientes (pruebaSumarSuciedad);
//			hecho = true;
//		}

		if (sumar) {
			if (sumador > Time.deltaTime * velocidadSuma) {
				sumador -= Time.deltaTime * velocidadSuma;
				puntos.text = Mathf.RoundToInt (Cantidades.puntos [player] - sumador).ToString ();
				
			} else {
				puntos.text = Cantidades.puntos [player].ToString ();
				sumador = 0;
				sumar = false;
				sonidosLimpio.Stop ();
//				Accesos.controlTiempoLanzaComida.CargaEscena ();
			}
		} else if (restar) {
			if (sumador > Time.deltaTime * velocidadSuma) {
				sumador -= Time.deltaTime * velocidadSuma;
				puntos.text = Mathf.RoundToInt (Cantidades.puntos [player] + sumador).ToString ();
				
			} else {
				puntos.text = Cantidades.puntos [player].ToString ();
				sumador = 0;
				sumar = false;
				sonidosLimpio.Stop ();
			}
		}
	}

	public void EnsuciarDientes (int masSuciedad) {
		bool annadida = false;
		int suciedadAnnadida = 0;
		if (suciedadBoca + masSuciedad > 100) {
			masSuciedad = 100 - suciedadBoca;
		}
		while (suciedadAnnadida < masSuciedad) {
			annadida=false;

			if (suciedadAnnadida < masSuciedad) {
				Diente nuevoDiente = BuscarDienteLimpio ();
				if (nuevoDiente != null) {
					nuevoDiente.boca = this;
					nuevoDiente.sucio = 100;
					nuevoDiente.suciedadTotal += nuevoDiente.sucio;
					nuevoDiente.ActivarCollider ();
					nuevoDiente.ColorearDiente ();
					suciedadBoca += valorDiente;
					suciedadAnnadida += valorDiente;
					annadida = true;
				}
			}

			if (suciedadAnnadida < masSuciedad) {
				Suciedad nuevaSuciedad = BuscarSuciedadLimpia ();
				if (nuevaSuciedad != null) {
					nuevaSuciedad.boca = this;
					nuevaSuciedad.sucio = 100;
					nuevaSuciedad.diente.suciedadTotal += nuevaSuciedad.sucio;
					nuevaSuciedad.ActivarCollider ();
					nuevaSuciedad.ColorearDiente ();
					suciedadBoca += valorSuciedad;
					suciedadAnnadida += valorSuciedad;
					annadida = true;
				}
			}

			if (suciedadBoca >= 30 && suciedadAnnadida < masSuciedad) {
				Carie nuevaCarie = BuscarCarieSana ();
				if (nuevaCarie != null) {
					nuevaCarie.boca = this;
					nuevaCarie.carie = 100;
					nuevaCarie.ActivarCollider ();
					nuevaCarie.ColorearDiente();
					suciedadBoca += valorCarie;
					suciedadAnnadida += valorCarie;
					annadida = true;
				}
			}

			if (!annadida) {
				masSuciedad = 0;
			}
		}
		barraSuciedad.fillAmount = 0.01f * suciedadBoca;
	}

	
	Diente BuscarDienteLimpio () {
		int indice = Random.Range (0, dientes.Length);
		for (int i = indice; i < dientes.Length; i++) {
			if (dientes[i].sucio == 0) {
				return dientes[i];
			}
		}
		for (int i = 0; i < indice; i++) {
			if (dientes[i].sucio == 0) {
				return dientes[i];
			}
		}
		return null;
	}

	Suciedad BuscarSuciedadLimpia () {
		int indice = Random.Range (0, dientes.Length);
		for (int i = indice; i < dientes.Length; i++) {
			for (int j = 0; j < dientes[i].suciedad.Length; j++) {
				if (dientes[i].suciedad[j].sucio == 0) {
					return dientes[i].suciedad[j];
				}
			}
		}
		for (int i = 0; i < indice; i++) {
			for (int j = 0; j < dientes[i].suciedad.Length; j++) {
				if (dientes[i].suciedad[j].sucio == 0) {
					return dientes[i].suciedad[j];
				}
			}
		}
		return null;
	}

	Carie BuscarCarieSana () {
		int indice = Random.Range (0, dientes.Length);
		for (int i = indice; i < dientes.Length; i++) {
			for (int j = 0; j < dientes[i].carie.Length; j++) {
				if (dientes[i].carie[j].carie == 0) {
					return dientes[i].carie[j];
				}
			}
		}
		for (int i = 0; i < indice; i++) {
			for (int j = 0; j < dientes[i].carie.Length; j++) {
				if (dientes[i].carie[j].carie == 0) {
					return dientes[i].carie[j];
				}
			}
		}
		return null;
	}

	public void DienteLimpio () {

		sonidosLimpio.PlayOneShot(sonidoDienteLimpio);
		suciedadBoca -= valorDiente;
		if (suciedadBoca <= 0) {
			suciedadBoca = 0;
			BocaLimpiaDelTodo ();
		}
		barraSuciedad.fillAmount = 0.01f * suciedadBoca;
	}
	public void CarieArreglada () {

		sonidosLimpio.PlayOneShot(sonidoCarieLimpio);
		suciedadBoca -= valorCarie;
		if (suciedadBoca <= 0) {
			suciedadBoca = 0;
			BocaLimpiaDelTodo ();
		}
		barraSuciedad.fillAmount = 0.01f * suciedadBoca;
	}
	public void SuciedadLimpia () {

		sonidosLimpio.PlayOneShot(sonidoRaspaLimpio);
		suciedadBoca -= valorSuciedad;
		if (suciedadBoca <= 0) {
			suciedadBoca = 0;
			BocaLimpiaDelTodo ();
		}
		barraSuciedad.fillAmount = 0.01f * suciedadBoca;
	}

	/// <summary>
	/// Calcula la suciedad total de la boca y la asigna a la estatica.
	/// </summary>
	public void CalculoTotalSuciedad () {

		float suciedadTemp = 0;
		foreach (Diente diente in dientes) {
			suciedadTemp += diente.sucio * 0.01f * valorDiente;
			foreach (Suciedad suciedad in diente.suciedad) {
				suciedadTemp += suciedad.sucio * 0.01f * valorSuciedad;
			}
			foreach (Carie carie in diente.carie) {
				suciedadTemp += carie.carie * 0.01f * valorCarie;
			}
		}
		suciedadBoca = Mathf.CeilToInt (suciedadTemp);
		barraSuciedad.fillAmount = 0.01f * suciedadBoca;
		Cantidades.sucio [player] = suciedadBoca;

		if (Cantidades.puntos [player] > suciedadBoca) {
			Cantidades.puntos [player] -= suciedadBoca;
			puntosFinales.text = "-"+suciedadBoca.ToString();
			sumador = suciedadBoca;
		} else {
			puntosFinales.text = "-"+Cantidades.puntos[player].ToString();
			sumador = Cantidades.puntos [player];
			Cantidades.puntos [player] = 0;
		}
//		puntos.text = Cantidades.puntos [player].ToString();
		//puntos.enabled = true;
		sumar = true;
		sonidosLimpio.clip = puntosSonido;
		sonidosLimpio.loop = true;
		sonidosLimpio.Play ();
	}

	void BocaLimpiaDelTodo () {
		sonidosLimpio.PlayOneShot(sonidoTodoLimpio);
		mensajeCompletado.enabled=true;
		int clasificacion = Accesos.controlTiempoLimpieza.JugadorTermina ();
		mensajeCompletado.text = "¡¡Limpieza completa!! " + clasificacion.ToString() + "º";
		puntos.text = Cantidades.puntos [player].ToString();
		//puntos.enabled = true;
		if (clasificacion == 1) {
			Cantidades.puntos [player] += 20;
			puntosFinales.text = "+20";
			sumador = 20;
		} else {
			Cantidades.puntos [player] += 10;
			puntosFinales.text = "+10";
			sumador = 10;
		}
		sumar = true;
		sonidosLimpio.clip = puntosSonido;
		sonidosLimpio.loop = true;
		sonidosLimpio.Play ();
	}
}
