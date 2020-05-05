using UnityEngine;
using System.Collections;

public class CambioRadio : MonoBehaviour {

	public Apuntar apuntar1;
	public Apuntar apuntar2;
	public Apuntar apuntar3;
	public Apuntar apuntar4;
	// Use this for initialization
	void Start () {
	
	}

	public void Radio5(){

		apuntar1.radioDetector = 5f;
		apuntar2.radioDetector = 5f;
		apuntar3.radioDetector = 5f;
		apuntar4.radioDetector = 5f;

	}
	public void Radio25(){
		
		apuntar1.radioDetector = 25f;
		apuntar2.radioDetector = 25f;
		apuntar3.radioDetector = 25f;
		apuntar4.radioDetector = 25f;
	}
	public void Radio50(){
		
		apuntar1.radioDetector = 50f;
		apuntar2.radioDetector = 50f;
		apuntar3.radioDetector = 50f;
		apuntar4.radioDetector = 50f;
		
	}
	public void Radio100(){
		
		apuntar1.radioDetector = 100f;
		apuntar2.radioDetector = 100f;
		apuntar3.radioDetector = 100f;
		apuntar4.radioDetector = 100f;
	}
}
