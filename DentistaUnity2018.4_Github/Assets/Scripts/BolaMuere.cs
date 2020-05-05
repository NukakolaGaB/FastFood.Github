using UnityEngine;
using System.Collections;

public class BolaMuere : MonoBehaviour {

	public GameObject explo;
	public GameObject mancha;
	public AudioSource sonidoExplo;
	public AudioClip splat1;
	public AudioClip splat;
	public AudioClip splat2;
	public Transform miTransf;
	public Transform posOrigen;

	// Use this for initialization
	void Start () {

		posOrigen=gameObject.transform;
		//Debug.Log (posOrigen.localPosition);

	}

	void OnCollisionEnter(Collision collision) {
		//Debug.Log (collision.gameObject.name);
		if (collision.gameObject.tag != "mesa") {
		gameObject .GetComponent<Rigidbody> ().isKinematic = true;
		gameObject.GetComponent<SpriteRenderer>().enabled=false;
		gameObject.GetComponent<Collider>().enabled=false;
		ContactPoint contact = collision.contacts[0];
		SimplePool.Spawn(explo ,gameObject.transform.position , gameObject.transform.localRotation);
		Quaternion rot = Quaternion.FromToRotation(Vector3.back, contact.normal);
		Vector3 pos = contact.point;
		SimplePool.Spawn(mancha ,pos , rot);
		//gameObject.transform.localPosition = posOrigen.localPosition;


				int n = Random.Range (0, 3);
				if (n == 0) {
					sonidoExplo.PlayOneShot (splat);
				}
				else if(n==1){

					sonidoExplo.PlayOneShot (splat1);
				}
				else if(n==2){
					
					sonidoExplo.PlayOneShot (splat2);
				}
		}


	}
}
