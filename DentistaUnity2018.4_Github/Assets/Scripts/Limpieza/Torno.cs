using UnityEngine;
using System.Collections;

public class Torno : MonoBehaviour {

	 float velocidadArreglo;

	 Carie carie;

	[SerializeField] AudioSource sonido;

    public GameObject TornoParti;

    public MoverImagen moverImagen;

    IEnumerator taladrar;

	// Use this for initialization
	void Start () {
	
		sonido = GetComponent<AudioSource> ();
		velocidadArreglo = Cantidades.velTorno;

	}

	void OnTriggerEnter2D (Collider2D col) {
		
		carie = col.GetComponent<Carie> ();
        taladrar = Taladrar();
        StartCoroutine(taladrar);

	}

	//void OnTriggerStay2D (Collider2D col) {
	//	if (carie != null && moverImagen.usando && Accesos.relojOn) {
 //           //sonido.mute = false;
 //           Debug.Log("Torno en stay");
 //           SimplePool.Spawn(TornoParti, gameObject.transform.position, gameObject.transform.rotation);
 //           if (carie.Arreglar (Time.deltaTime * velocidadArreglo)) {
	//			sonido.mute = true;
	//			carie = null;
	//		} else {
	//			sonido.mute = false;
	//		}
	//	} else {
	//		sonido.mute = true;
	//	}
	//}

	void OnTriggerExit2D (Collider2D col) {
		if (col.GetComponent<Carie> () == carie) {
			sonido.mute = true;
			carie = null;
            StopCoroutine(taladrar);
		}

	}

    IEnumerator Taladrar()
    {
        while (carie != null && moverImagen.usando && Accesos.relojOn)
        {
            //sonido.mute = false;
            //Debug.Log("Torno en stay");
            SimplePool.Spawn(TornoParti, gameObject.transform.position, gameObject.transform.rotation);
            if (carie.Arreglar(Time.deltaTime * velocidadArreglo))
            {
                sonido.mute = true;
                carie = null;
            }
            else
            {
                sonido.mute = false;
            }
            yield return null;
        }
            sonido.mute = true;

    }
}
