using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Apuntar : MonoBehaviour {

	[SerializeField] Transform mytransform;
	[SerializeField] Vector3 posInicial;


	//[SerializeField] Transform bolaLanzada;
	Vector3 posBola;

//	Rigidbody lanzaRB;
	[SerializeField] float speed;
	Vector3 velocidadBola;
	Vector3 posInicialBola;
	[SerializeField] Transform posInicProjec;
	[SerializeField] float zLanza;

	[SerializeField] Camera camara;

	[SerializeField] Vector3 check;
	[SerializeField] Vector3 dif;

//	public float divisorX;
//	public float divisorY;
//	[SerializeField] float correctorEscala;



	[SerializeField] GameObject trayectoria;
	float tiempo;
	float distBolasTr;
	[SerializeField] Transform[] bolasTr;
	[SerializeField] Vector3[] verticesTr;
	LineRenderer lineasTR;
	[SerializeField] Material materialLineasTr;


    [SerializeField] AudioSource sonidoGoma;


	//para las gomas
	[SerializeField] Transform gomaIzda;
	[SerializeField] Transform gomaDcha;
	LineRenderer goma;
	[SerializeField] Material gomaMat;
	Vector3 esquina1 = new Vector3 (-1.1f, 0, 0);
	Vector3 esquina2 = new Vector3 (-0.7f, 0, -1);
	Vector3 esquina3 = new Vector3 (0.7f, 0, -1);
	Vector3 esquina4 = new Vector3 (1.1f, 0, 0);

    AnimacionBoca animacionBoca;

	Comida comidaLanzada;

    RaycastHit hit;
    bool noToca;
    bool noAcierta;

	//public Text touchID;
	int identDedo;
	bool usando;
	public float radioDetector;

	// Use this for initialization
	void Awake () {
		Input.multiTouchEnabled = true;
		mytransform = transform;
		trayectoria.SetActive (false);

		distBolasTr = 70 / bolasTr.Length;

	}

	public void Inicializar(){
	
		posInicialBola = posInicProjec.position;
		//		lanzaRB = bolaLanzada.GetComponent<Rigidbody> ();	
		//bolaLanzada = null;
		
		posInicial = Camera.main.WorldToScreenPoint (posInicialBola);
		mytransform.position = posInicial;

//		correctorEscala = posInicial.y;
//		divisorX = correctorEscala / Camera.main.pixelWidth;
//		divisorY = 0.2f * correctorEscala / Camera.main.pixelHeight;
		
		goma = gameObject.AddComponent<LineRenderer>();
		goma.useWorldSpace = true;
		goma.SetVertexCount (6);
		goma.material = gomaMat;
//		goma.SetColors (Color.red, Color.red);
		goma.SetWidth(0.2F, 0.2F);
		GomaAsuSitio ();
	
		if (Accesos.trayLineas) {
			lineasTR = trayectoria.AddComponent<LineRenderer> ();
			lineasTR.useWorldSpace = true;
			lineasTR.SetVertexCount (bolasTr.Length);
			lineasTR.material = materialLineasTr;
//			lineasTR.SetColors (Color.green, Color.green);
			lineasTR.SetWidth (0.2F, 0.2F);
		}
	}


	public void Comienzo () {
		if (Application.platform != RuntimePlatform.Android && comidaLanzada == null) {

			trayectoria.SetActive (true);
			comidaLanzada = Accesos.nuevaComida.CogerComida ();
			if (comidaLanzada != null) {
				comidaLanzada.rigid.isKinematic = true;
				comidaLanzada.sprite.enabled = true;
				comidaLanzada.collider.enabled = true;
				comidaLanzada.suTransform.position = posInicialBola;
				//bolaLanzada = comidaLanzada.suTransform;
			}
		}

		foreach (Touch toque in Input.touches) {
			if (Mathf.Abs (toque.position.x - mytransform.position.x) < radioDetector && Mathf.Abs (toque.position.y - mytransform.position.y) < radioDetector && !usando) {
				identDedo = toque.fingerId;
				//Debug.Log(identDedo);
				//touchID.text=identDedo.ToString();
				usando = true;
			}
		}
		if (usando && comidaLanzada == null) {
			trayectoria.SetActive (true);
			comidaLanzada = Accesos.nuevaComida.CogerComida ();
			if (comidaLanzada != null) {
				comidaLanzada.rigid.isKinematic = true;
				comidaLanzada.sprite.enabled = true;
				comidaLanzada.collider.enabled = true;
				comidaLanzada.suTransform.position = posInicialBola;
				//bolaLanzada = comidaLanzada.suTransform;
                //comidaLanzada = null;
			}
		}
	}

	public void SeguirDedo () {

//		if (Application.platform == RuntimePlatform.Android) {	
		if (Input.touchCount > 0) {	
			if (usando) {
				foreach (Touch toque in Input.touches) {
					if (toque.fingerId == identDedo) {
						check = toque.position;	
					}
				}
                mytransform.position = check;
                sonidoGoma.enabled = false;
                BolaSigue();
            }
		} else if (Application.platform != RuntimePlatform.Android)
        {
			check = Input.mousePosition;
            mytransform.position = check;
            sonidoGoma.enabled = false;
            BolaSigue();
        }



		
	}


	public void Volver () {

        bool acabadoToque = true;
        foreach (Touch toque in Input.touches)
        {
            if (toque.fingerId == identDedo && toque.phase != TouchPhase.Ended && toque.phase != TouchPhase.Canceled)
            {
                acabadoToque = false;
            }
        }

        if (acabadoToque)
        {

            mytransform.position = posInicial;
            check = mytransform.position;
            trayectoria.SetActive(false);
            sonidoGoma.enabled = true;

            if (comidaLanzada != null)
            {
                comidaLanzada.rigid.isKinematic = false;
                comidaLanzada.rigid.velocity = velocidadBola;
                comidaLanzada = null;
            }

            //bolaLanzada = null;
            GomaAsuSitio();
            usando = false;
        }
	}


	void BolaSigue () {

		dif = check - posInicial;
		if (comidaLanzada != null) {
            comidaLanzada.suTransform.position = posInicialBola + new Vector3 (Mathf.Clamp (dif.x * Cantidades.sensibilidad, -6f, 6f), Mathf.Clamp (dif.y * Cantidades.sensibilidad, -4f, 0f), -5f);
			posBola = comidaLanzada.suTransform.position;
			velocidadBola = (posInicialBola - posBola) * speed;
		} else {
			posBola = posInicialBola + new Vector3 (Mathf.Clamp (dif.x * Cantidades.sensibilidad, -6f, 6f), Mathf.Clamp (dif.y * Cantidades.sensibilidad, -4f, 0f), -5f);
			velocidadBola = (posInicialBola - posBola) * speed;
		}
		CalculoTrayectoria ();

		goma.SetVertexCount (6);
		goma.SetPosition (0, gomaIzda.position);
		goma.SetPosition (1, posBola + esquina1);
		goma.SetPosition (2, posBola + esquina2);
		goma.SetPosition (3, posBola + esquina3);
		goma.SetPosition (4, posBola + esquina4);
		goma.SetPosition (5, gomaDcha.position);
	}

	void CalculoTrayectoria () {
        //tiempo = Time.fixedDeltaTime * 15;

        //Debug.Log("Apuntando" + hit.collider.gameObject.tag);
        //lineasTR.material = materialLineasTr;
        bolasTr[0].position = posBola;
		
		lineasTR.SetPosition (0, posBola);
		
        noToca = true;
        noAcierta = true;
		for (int i = 1; i < bolasTr.Length; i++) {

            
            tiempo = i * Time.fixedDeltaTime * distBolasTr;
			bolasTr[i].position = bolasTr [0].position + velocidadBola * tiempo + 0.5f * Physics.gravity * tiempo * tiempo;
            lineasTR.SetPosition(i, bolasTr[i].position);

            if (comidaLanzada != null && i > 2)
            {
                Vector3 segmento = bolasTr[i].position - bolasTr[i - 1].position;
                if (noToca && Physics.Raycast(bolasTr[i - 1].position, segmento, out hit, segmento.magnitude))
                {
                    noToca = false;
                    //Debug.Log(i.ToString());
                    if (hit.collider.tag == "mesa")
                    {
                        animacionBoca = hit.collider.gameObject.GetComponent<AnimacionBoca>();
                        animacionBoca.AbrirBoca();
                        noAcierta = false;
                    }
                }
            }
        }
        if (noAcierta && animacionBoca!=null)
        {
            //Debug.Log("Cerrar boca" );
            animacionBoca.CerrarBoca();
            animacionBoca = null;
        }
	}

	void GomaAsuSitio () {
		//if (bolaLanzada != null && bolaLanzada.position == posInicialBola) {
		//	goma.SetVertexCount (6);
		//	goma.SetPosition (0, gomaIzda.position);
		//	goma.SetPosition (1, bolaLanzada.position + esquina1);
		//	goma.SetPosition (2, bolaLanzada.position + esquina2);
		//	goma.SetPosition (3, bolaLanzada.position + esquina3);
		//	goma.SetPosition (4, bolaLanzada.position + esquina4);
		//	goma.SetPosition (5, gomaDcha.position);
		//} else {
		//	goma.SetVertexCount (2);
		//	goma.SetPosition (0, gomaIzda.position);
		//	goma.SetPosition (1, gomaDcha.position);
		//}
        goma.SetVertexCount(2);
        goma.SetPosition(0, gomaIzda.position);
        goma.SetPosition(1, gomaDcha.position);
    }

    void OnDisable()
    {
        trayectoria.SetActive(false);
        //GomaAsuSitio();
        if (comidaLanzada != null)
        {
            SimplePool.Despawn(comidaLanzada.gameObject);
            ForzarVolver();
        }
  
    }

    public void ForzarVolver()
    {
        if (gameObject.activeSelf)
        {
            mytransform.position = posInicial;
            check = mytransform.position;
            trayectoria.SetActive(false);
            sonidoGoma.enabled = true;

            if (comidaLanzada != null)
            {
                comidaLanzada.rigid.isKinematic = false;
                comidaLanzada.rigid.velocity = velocidadBola;
                comidaLanzada = null;
            }

            GomaAsuSitio();
            usando = false;
        }
    }
}
