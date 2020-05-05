using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class NuevaComida : MonoBehaviour {

	Comida siguienteComida;

	public Image imagenSiguienteComida;
	public Image imagenSiguienteComida1;
	Vector3 lejos = new Vector3(1000,1000,1000);
	[SerializeField] Comida [] comidas;

    [Tooltip("para desactivar las imagenes del canvas que mueven las gomas")]
    [SerializeField]
    GameObject[] imagenes;

	// Use this for initialization
	void Awake () {
		Accesos.nuevaComida = this;
	}


	public void PrimeraComida () {
		int i = Random.Range (0, comidas.Length);
		//siguienteComida = comidas [i];
        siguienteComida = SimplePool.Spawn(comidas[i].prefab, lejos, Quaternion.identity).GetComponent<Comida>();
        //siguienteComida.lanzada = true;
        imagenSiguienteComida.sprite = siguienteComida.sprite.sprite;
		imagenSiguienteComida1.sprite = siguienteComida.sprite.sprite;
	}
	
	public Comida CogerComida () {

		if (siguienteComida != null) {
		
			Comida comidaCogida = siguienteComida;
			int i = Random.Range (0, comidas.Length);
			//if (comidas [i].lanzada) {
			//	siguienteComida = SimplePool.Spawn (comidas [i].prefab, lejos, Quaternion.identity).GetComponent<Comida> ();
			//	siguienteComida.copia = true;
			//} else {
			//	siguienteComida = comidas [i];
			//}
            siguienteComida = SimplePool.Spawn(comidas[i].prefab, lejos, Quaternion.identity).GetComponent<Comida>();
            imagenSiguienteComida.sprite = comidas [i].sprite.sprite;
			imagenSiguienteComida1.sprite = comidas[i].sprite.sprite;

	
//			comidaCogida.lanzada = true;
			//aqui habilitar comidaCogida

			return comidaCogida;
		} else {
			return null;
		}
	}

	public void SeAcabaLaComida () {
		siguienteComida = null;
        foreach (GameObject imagen in imagenes)
        {
            imagen.SetActive(false);
        }
	}
}
