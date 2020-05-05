using UnityEngine;
using System.Collections;

public class Comida : MonoBehaviour {

	public GameObject prefab;

	public GameObject mancha;

	public Rigidbody rigid;
	public SpriteRenderer sprite;
	public Collider collider;


	public GameObject explo;
	public AudioSource sonidoExplo;
	public AudioClip splat1;
	public AudioClip splat;
	public AudioClip splat2;
	public Transform suTransform;


//	[Tooltip("cuanto alimenta a cada crio (int)"]
	public int [] cuantoAlimenta;
//	[Tooltip("cuanto alimenta a cada crio (int)"]
	[SerializeField] int [] cuantoEnsucia;

	// Use this for initialization
	void Awake () {

		rigid = gameObject.GetComponent<Rigidbody> ();
		sprite = gameObject.GetComponent<SpriteRenderer> ();
		collider = gameObject.GetComponent<Collider> ();
	}

	void Start () {
	
	}

	void OnCollisionEnter(Collision collision) {
		//Debug.Log (collision.gameObject.name);
		
		rigid.isKinematic = true;
		sprite.enabled=false;
		collider.enabled=false;


		if (collision.gameObject.tag != "mesa") {

			SimplePool.Spawn (explo ,suTransform.position , suTransform.localRotation);
			ContactPoint contact = collision.contacts[0];
			Quaternion rot = Quaternion.FromToRotation(Vector3.back , contact.normal);
			Vector3 pos = contact.point;
			SimplePool.Spawn(mancha ,pos , rot );
			//float rotz = manchaza.transform.localRotation.z;
			//rotz = Random.Range(20f , 50.5f);
			//rotz += 90;
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
		
		SimplePool.Despawn (gameObject);
	}

	public int CuantoAlimenta (int numNinno) {
		if (numNinno < cuantoAlimenta.Length) {
			return cuantoAlimenta [numNinno];
		} else {
			return 0;
		}
	}

	public int CuantoEnsucia (int numNinno) {
		if (numNinno < cuantoEnsucia.Length) {
			return cuantoEnsucia [numNinno];
		} else {
			return 0;
		}
	}
}
