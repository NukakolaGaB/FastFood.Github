using UnityEngine;
using System.Collections;

public class Avanza : MonoBehaviour {

	[SerializeField] float speed;

	Transform myTransform;

	// Use this for initialization
	void Start () {
		myTransform = transform;
	}
	
	// Update is called once per frame
	void Update () {

		myTransform.position += myTransform.forward * speed * Time.deltaTime;
	
	}
}
