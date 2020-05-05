using UnityEngine;
using System.Collections;

public class SillaAleatoria : MonoBehaviour {

	[SerializeField] Transform miPos;
	[SerializeField] Animator animatorC;
	public float tiempoCambio;
	 float tiempo;
	Aturdir aturdir;
	int numNinno;
	int y;
	int YAnt = 9999;

	// Use this for initialization
	void Start () {

		y = Random.Range (0, Accesos.sillas.posiciones.Length);
		while (Accesos.sillas.ocupadas [y]) {
			y = Random.Range (0, Accesos.sillas.posiciones.Length);
		}
		miPos.position=  Accesos.sillas.posiciones[y].position ;
		Accesos.sillas.ocupadas [y] = true;
		YAnt = y;
		numNinno = GetComponentInChildren<ImpactoReaccion> ().numNinno;

		aturdir = GetComponentInChildren<Aturdir> ();
		aturdir.sillaAleatoria = this;
	}
	
	// Update is called once per frame
	void Update () {

		if (tiempo > 0) {
			tiempo -= Time.deltaTime;
		} else {
			tiempo = tiempoCambio + Cantidades.retrasoHambre[numNinno];
			if (!aturdir.aturdido) {
				//Invoke("Cambio",0.5f);
				animatorC.SetBool("CambioSilla",true);
			}
		}
			

	}
	public void CambioAturdir(){
	
		//Invoke("Cambio",0.5f);
		animatorC.SetBool("CambioSilla",true);
		tiempo = tiempoCambio + Cantidades.retrasoHambre[numNinno];

	
	
	}
	public void Cambio(){

		while (Accesos.sillas.ocupadas [y]) {
			y = Random.Range (0, Accesos.sillas.posiciones.Length);
		}
		miPos.position=  Accesos.sillas.posiciones[y].position ;
		Accesos.sillas.ocupadas [y] = true;
		Accesos.sillas.ocupadas [YAnt] = false;
		YAnt = y;
		animatorC.SetBool("CambioSilla",false);

	}


}
