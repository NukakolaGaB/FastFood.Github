using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class MoverImagen : MonoBehaviour {

	[SerializeField] Transform mytransform;

	int identDedo;
	public bool usando;
	[SerializeField] float radioDetectorX;
	[SerializeField] float radioDetectorY;
	[SerializeField] Sprite utilUsando;
	[SerializeField] Sprite utilNoUsando;
	Image imagenUtil;
	Vector3 origen;
	
	[SerializeField] float velocidadInicial;
	[SerializeField]float velocidad;
	[SerializeField]float acel;

	[SerializeField] Transform objetomovido;


	// Use this for initialization
	void Start () {

		mytransform = transform;
//		mytransform.position = Camera.main.WorldToScreenPoint (objetomovido.position);
//		mytransform.position = objetomovido.position;
		origen = mytransform.position;
		imagenUtil = gameObject.GetComponent<Image> ();

		Cepillo cepillo = objetomovido.GetComponentInChildren<Cepillo> ();
		if (cepillo != null) {
			cepillo.moverImagen = this;
		}
		Rascador rascador = objetomovido.GetComponentInChildren<Rascador> ();
		if (rascador != null) {
			rascador.moverImagen = this;
		}
		Torno torno = objetomovido.GetComponentInChildren<Torno> ();
		if (torno != null) {
			torno.moverImagen = this;
		}
	}
	
	// Update is called once per frame
	void Update () {

		if (!usando && (mytransform.position - origen).sqrMagnitude > 0.01f) {
			MoverseHacia (origen);
		}
	}

	public void Comienzo () {

		if (Application.platform != RuntimePlatform.Android) {
			if (Mathf.Abs (Input.mousePosition.x - mytransform.position.x) < radioDetectorX && Mathf.Abs (Input.mousePosition.y - mytransform.position.y) < radioDetectorY && !usando) {
				usando = true;
				imagenUtil.sprite = utilUsando;
			}
		} else {
			foreach (Touch toque in Input.touches) {
				if (Mathf.Abs (toque.position.x - mytransform.position.x) < radioDetectorX && Mathf.Abs (toque.position.y - mytransform.position.y) < radioDetectorY && !usando) {
					identDedo = toque.fingerId;
					usando = true;
					imagenUtil.sprite = utilUsando;
				}
			}
		}
	}

	public void SeguirDedo () {
		
		if (Input.touchCount > 0) {	
			if (usando) {
				foreach (Touch toque in Input.touches) {
					if (toque.fingerId == identDedo) {
						mytransform.position = toque.position;
					}
				}
			}
		} else {
			mytransform.position = Input.mousePosition;
//			mytransform.position = Camera.main.ScreenToWorldPoint(Input.mousePosition);
		}
		objetomovido.position = Camera.main.ScreenToWorldPoint (mytransform.position) + Vector3.forward;
//		objetomovido.position = mytransform.position;
	}


	public void SoltarDedo () {

		usando = false;
		imagenUtil.sprite = utilNoUsando;
		velocidad = velocidadInicial;
	}

	void MoverseHacia (Vector3 destino) {

		velocidad += Time.deltaTime * acel;
		mytransform.position = Vector3.MoveTowards (mytransform.position, destino, Time.deltaTime * velocidadInicial);

		if (Mathf.Abs (destino.x - mytransform.position.x) < Mathf.Abs (destino.y - mytransform.position.y)) {
			mytransform.position =	Vector3.MoveTowards (mytransform.position, new Vector3 (mytransform.position.x, destino.y, mytransform.position.z), Time.deltaTime * velocidad);
		} else {
			mytransform.position = Vector3.MoveTowards (mytransform.position, new Vector3 (destino.x, mytransform.position.y, destino.z), Time.deltaTime * velocidad);
		}

		objetomovido.position = Camera.main.ScreenToWorldPoint (mytransform.position) + Vector3.forward;
//		objetomovido.position = mytransform.position;
	}



}
