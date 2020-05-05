using UnityEngine;
using System.Collections;

public class Preload : MonoBehaviour {

	[SerializeField] GameObject bola;
	[SerializeField] GameObject explo;
	[SerializeField] GameObject mancha;
	[SerializeField] GameObject rotura;
	// Use this for initialization
	void Start () {
	
		SimplePool.Preload (bola,4);
		SimplePool.Preload (explo,4);
		SimplePool.Preload (mancha,4);
		SimplePool.Preload (rotura,4);
	}

}
