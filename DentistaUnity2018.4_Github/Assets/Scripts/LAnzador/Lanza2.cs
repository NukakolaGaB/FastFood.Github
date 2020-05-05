using UnityEngine;
using System.Collections;

public class Lanza2 : MonoBehaviour {

	[SerializeField] Transform mytransform;
	[SerializeField] Rigidbody2D rb;
	Vector3 posInicial;
	[SerializeField] float fza = 5;
	// Use this for initialization
	void Start () {
		posInicial = mytransform.position;

	}
	
	public void Lanzar () {
		//gameObject.SetActive (true);
		rb.isKinematic = false;
		rb.WakeUp();
		rb.velocity = fza * (posInicial - mytransform.position);
	}


}
