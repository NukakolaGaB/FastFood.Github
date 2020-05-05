using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Marcador : MonoBehaviour {

	[SerializeField] Image alimentadoImage;
	[SerializeField] Image sucioImage;
	public Image ninnoImage;
	public MeshRenderer tirachinasR;
	
	[SerializeField] int numJugador;

	[SerializeField] int limiteSuciedad = 90;

	[SerializeField] AudioSource puntosSonido;

	[SerializeField] Text textPuntos;
	[SerializeField] float velocidadSuma = 50;
	bool sumar;
	public int numNinno;
//	[SerializeField] Text podium;

	float puntos = 0;

    bool acabado = false;
	// Use this for initialization
	void Start () {

		textPuntos.text = Cantidades.puntos [numJugador].ToString();

		puntos = 0;
		alimentadoImage.fillAmount = Cantidades.alimentado [numJugador] * 0.01f;
		sucioImage.fillAmount = Cantidades.sucio [numJugador] * 0.01f;

		Accesos.controlTiempoLanzaComida.marcadores [numJugador] = this;
	}
	
	// Update is called once per frame
	void Update () {
	
		if (sumar) {
			if (puntos > Time.deltaTime * velocidadSuma) {
				puntos -= Time.deltaTime * velocidadSuma;
				alimentadoImage.fillAmount = puntos * 0.01f;
				textPuntos.text = Mathf.RoundToInt(Cantidades.puntos [numJugador] - puntos).ToString();

			} else {
				textPuntos.text = Cantidades.puntos [numJugador].ToString ();
				puntos = 0;
				sumar = false;
				puntosSonido.Stop();
                if (!acabado) {

                    Invoke("CargarEscena",1f);
                    acabado = true;
                }
               
			}
		}
	}
    void CargarEscena()
    {
        Accesos.controlTiempoLanzaComida.CargaEscena();


    }
    public void Comer (int alimenta, int ensucia) {
		Cantidades.alimentado [numJugador] += alimenta;
		Cantidades.sucio [numJugador] += ensucia;
		alimentadoImage.fillAmount = Cantidades.alimentado [numJugador] * 0.01f;
		sucioImage.fillAmount = Cantidades.sucio [numJugador] * 0.01f;

		if (Cantidades.alimentado [numJugador] >= 100) {
			//tambien se puede poner algo para decirle que ha acabado.
			int clasificacion = Accesos.controlTiempoLanzaComida.JugadorTermina ();
//			podium.text = clasificacion.ToString();
//			podium.gameObject.SetActive (true);
			if (clasificacion == 1) {
				Cantidades.puntos [numJugador] += 30;
				textPuntos.text = Cantidades.puntos [numJugador].ToString();
			} else if (clasificacion == 2) {
				Cantidades.puntos [numJugador] += 20;
				textPuntos.text = Cantidades.puntos [numJugador].ToString();
			} else if (clasificacion == 3) {
				Cantidades.puntos [numJugador] += 10;
				textPuntos.text = Cantidades.puntos [numJugador].ToString();
			}
		}
	}

	public bool Muysucio () {
		if (Cantidades.sucio [numJugador] >= limiteSuciedad) {
			return true;
		} else {
			return false;
		}
	}

	public void DarPuntos () {

		if (Cantidades.alimentado [numJugador] == 0) {

			Cantidades.retrasoHambre[numNinno]+=2f;
		
		}
		puntos = Cantidades.alimentado [numJugador];
		Cantidades.puntos [numJugador] += Cantidades.alimentado [numJugador];
		Cantidades.alimentado [numJugador] = 0;
		sumar = true;
		puntosSonido.Play();
	}

}
