using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Letra : MonoBehaviour {

	[SerializeField] char[] beta = "ABCDEFGHIJKLMNOPQRSTUVWXYZ ".ToCharArray();
	int i = 0;
	[SerializeField] Text mytext;

	// Use this for initialization
	void Start () {
		mytext.text = beta [i].ToString();
	}
	

	public void Subir () {
		if (i == beta.Length -1) {
			i = 0;
		} else {
			i++;
		}
		mytext.text = beta [i].ToString();
	}
	public void Bajar () {
		if (i == 0) {
			i = beta.Length - 1;
		} else {
			i--;
		}
		mytext.text = beta [i].ToString();
	}
}
