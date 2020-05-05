using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Sensibilidad : MonoBehaviour {


	[SerializeField] Slider barraCambio;
	[SerializeField] Text visor;

	public void CambiaSensibilidad () {

		Cantidades.sensibilidad = barraCambio.value;
		visor.text = Cantidades.sensibilidad.ToString ();
        PlayerPrefs.SetFloat("sensibilidad", Cantidades.sensibilidad);
        PlayerPrefs.Save();
    }

	void Start () {
		Cantidades.sensibilidad = PlayerPrefs.GetFloat ("sensibilidad", 0.03f);
		barraCambio.value = Cantidades.sensibilidad;
		visor.text = Cantidades.sensibilidad.ToString ();
	}

	void OnDestroy () {
		PlayerPrefs.SetFloat ("sensibilidad", Cantidades.sensibilidad);
		PlayerPrefs.Save ();
	}
}
