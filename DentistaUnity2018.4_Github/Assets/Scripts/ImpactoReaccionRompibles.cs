using UnityEngine;
using System.Collections;

public class ImpactoReaccionRompibles : MonoBehaviour {

	public AudioSource crack;
	public GameObject roturaPart;
	// Use this for initialization
	void Start () {
	
	}

	void OnCollisionEnter(Collision collision) {

		if (collision.gameObject.tag == "Bola") {
		
			gameObject.GetComponent<Renderer>().enabled=false;
			//col.gameObject.SetActive (false);
			//Destroy(col.gameObject);
			SimplePool.Spawn(roturaPart ,gameObject.transform.position , gameObject.transform.localRotation);
			collision.gameObject.GetComponent<SpriteRenderer>().enabled=false;
			collision.gameObject.GetComponent<Collider>().enabled=false;
			crack.enabled=true;
			Invoke ("CambioColor",1.2f);
		
		}


	}
	public void CambioColor(){
		
		Destroy (gameObject);

	}
}
