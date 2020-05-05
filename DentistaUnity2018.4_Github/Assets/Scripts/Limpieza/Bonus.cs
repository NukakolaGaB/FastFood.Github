using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Bonus : MonoBehaviour {

	Transform myTran;
	float alfa = 1;
	Text texto;
	Color mycolor;
	Vector2 posicion;

	[SerializeField] float velSubida = 15f;
	[SerializeField] float velTransparencia = 0.1f;

	// Use this for initialization
	void Awake () {
		myTran = transform;
		texto = GetComponent<Text> ();
		mycolor = texto.color;
		posicion = myTran.position;
	}
	
	// Update is called once per frame
	void Update () {
		posicion += Time.deltaTime * velSubida * Vector2.up;
		myTran.position = posicion;
		alfa -= Time.deltaTime * velTransparencia;
		mycolor.a = alfa;
		texto.color = mycolor;
		if (alfa < 0) {
			Destroy (gameObject);
		}
	}

	public void AsignarPuntos (int puntos) {
		texto.text = "+"+ puntos.ToString();
		myTran.localScale = Vector3.one;
	}
}
