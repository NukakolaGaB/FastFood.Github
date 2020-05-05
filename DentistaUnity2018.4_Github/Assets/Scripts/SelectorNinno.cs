using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class SelectorNinno : MonoBehaviour {

	[SerializeField] int Player;

	[SerializeField] Marcador marcador;
//	public int numPlayer;
	[SerializeField] int numNinno;
	[SerializeField] int numANt;

//	[SerializeField] Image imagenNinnoPLayer;
	[SerializeField] Image imagenNinnoFicha;
	[SerializeField] AudioSource sonidoBoton;
	[SerializeField] Image velocidad;
	[SerializeField] Image fuerza;
	[SerializeField] Image comidaAfin1Img;
	[SerializeField] Image comidaAfin2Img;



	public void InicializarNinno(){
	
		if (Escenas.ronda == 0) {
			while (Accesos.asignadorNinnos.ninnos [numNinno].asignado && numNinno < Cantidades.ninnos - 1) {
				numNinno++;
			}
			imagenNinnoFicha.sprite = Accesos.asignadorNinnos.ninnos [numNinno].spriteNinno;
			Accesos.asignadorNinnos.ninnos [numNinno].asignado = true;
			numANt = numNinno;
			velocidad.fillAmount = Cantidades.velocidadNinno [numNinno];
			fuerza.fillAmount = Cantidades.fuerzaNinno [numNinno];
			comidaAfin1Img.sprite = Accesos.comidaAfin [numNinno];
			comidaAfin2Img.sprite = Accesos.comidaAfin2 [numNinno];
			Accesos.ninno [Player] = numNinno;
		} else {
			numNinno = Accesos.ninno [Player];
			numANt = numNinno;
			Accesos.asignadorNinnos.ninnos [numNinno].asignado = true;
			imagenNinnoFicha.sprite = Accesos.asignadorNinnos.ninnos [numNinno].spriteNinno;
			velocidad.fillAmount = Cantidades.velocidadNinno [numNinno];
			fuerza.fillAmount = Cantidades.fuerzaNinno [numNinno];
			comidaAfin1Img.sprite = Accesos.comidaAfin [numNinno];
			comidaAfin2Img.sprite = Accesos.comidaAfin2 [numNinno];
		}


	}

	public void Mas () {
		sonidoBoton.Play ();
		Accesos.asignadorNinnos.ninnos [numANt].asignado = false;
		if (numNinno < Cantidades.ninnos - 1) {
			numNinno++;
		} else {
			numNinno = 0;
		}
		if (Accesos.asignadorNinnos.ninnos [numNinno].asignado) {
			Mas ();
		} else {
//			Accesos.asignadorNinnos.ninnos [numANt].asignado = false;
			numANt = numNinno;
			Accesos.asignadorNinnos.ninnos [numNinno].asignado = true;
			imagenNinnoFicha.sprite = Accesos.asignadorNinnos.ninnos [numNinno].spriteNinno;
			velocidad.fillAmount = Cantidades.velocidadNinno [numNinno];
			fuerza.fillAmount = Cantidades.fuerzaNinno [numNinno];
			comidaAfin1Img.sprite = Accesos.comidaAfin [numNinno];
			comidaAfin2Img.sprite = Accesos.comidaAfin2 [numNinno];
		}

	}

	public void Menos () {
		sonidoBoton.Play ();
		Accesos.asignadorNinnos.ninnos [numANt].asignado = false;
		if (numNinno > 0) {
			numNinno--;
		} else {
			numNinno = Cantidades.ninnos - 1;
		}
		if (Accesos.asignadorNinnos.ninnos [numNinno].asignado) {
			Menos ();
		} else {
//			Accesos.asignadorNinnos.ninnos [numANt].asignado = false;
			numANt = numNinno;
			Accesos.asignadorNinnos.ninnos [numNinno].asignado = true;
//			imagenNinnoPLayer.sprite = Accesos.asignadorNinnos.ninnos [numNinno].spriteNinno;
			imagenNinnoFicha.sprite = Accesos.asignadorNinnos.ninnos [numNinno].spriteNinno;		
			velocidad.fillAmount = Cantidades.velocidadNinno [numNinno];
			fuerza.fillAmount = Cantidades.fuerzaNinno [numNinno];
			comidaAfin1Img.sprite = Accesos.comidaAfin [numNinno];
			comidaAfin2Img.sprite = Accesos.comidaAfin2 [numNinno];
		}
	}

	public void Asignar () {

		Accesos.ninno [Player] = numNinno;

		Accesos.controlTiempoLanzaComida.JugadorPulsaStart ();
		Accesos.asignadorNinnos.ninnos [numNinno].marcador = marcador;
		marcador.ninnoImage.sprite = Accesos.asignadorNinnos.ninnos [numNinno].spritePlayer;
		marcador.numNinno = numNinno;
		Material[] oldMaterials = marcador.tirachinasR.materials;

		for (var i = 0; i < oldMaterials.Length-1; i++) {
			marcador.tirachinasR.materials[i].color = Accesos.asignadorNinnos.ninnos [numNinno].colorTirachinas;
		}
			//marcador.tirachinasR.material.color = Accesos.asignadorNinnos.ninnos [numNinno].colorTirachinas;

	}

}
