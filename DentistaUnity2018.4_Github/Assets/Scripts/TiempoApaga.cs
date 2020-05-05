using UnityEngine;
using System.Collections;

public class TiempoApaga : MonoBehaviour {


	public float tiempoVida;


	void OnEnable () {

		Invoke ("Autodestruccion",tiempoVida);

	}
	
	// Update is called once per frame
	void Autodestruccion () {
			
		gameObject.SetActive(false);
	}
}
