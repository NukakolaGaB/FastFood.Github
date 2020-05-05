using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class AsignadorNinnos : MonoBehaviour {


//	public Marcador [] marcadores;

	public ImpactoReaccion[] ninnos;

	// Use this for initialization
	void Awake () {
		ninnos = new ImpactoReaccion [Cantidades.ninnos];
		Accesos.asignadorNinnos = this;
	}

}
