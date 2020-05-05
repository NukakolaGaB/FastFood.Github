using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ShowTopScore : MonoBehaviour {

	[SerializeField] Text [] texNombresTopScore = new Text[ScoreList.longitud - 1];
	[SerializeField] Text [] texPuntosTopScore = new Text[ScoreList.longitud - 1];
	[SerializeField] Image [] imagenTopScore = new Image[ScoreList.longitud - 1];

	[SerializeField] Transform movido;
	[SerializeField] float speed;
	Vector3 posIn;

	score suScore;

	public bool reanudar;
	// Use this for initialization
	void Awake () {

		string[] nombresPorDefecto = { "Paula", "Nicolas", "Guillermo", "Antxon", "Leti" };
		int[] scoresPorDefecto = { 110, 90, 86, 74, 65 };
		int[] ninnosPorDefecto = { 1, 5, 4, 3, 7};
		for (int i = 0; i < ScoreList.longitud - 1; i++) {
			ScoreList.topscore [i].name = PlayerPrefs.GetString ("TopName"+i.ToString(), nombresPorDefecto[i]);
			ScoreList.topscore [i].puntos = PlayerPrefs.GetInt ("TopScore"+i.ToString(), scoresPorDefecto[i]);
			ScoreList.topscore [i].ninno =  PlayerPrefs.GetInt ("Ninno"+i.ToString(), ninnosPorDefecto[i]);
		}
		
		//Refrescar ();
		//posIn = movido.position;

	}
	
    void Start ()
    {
        Refrescar();
        posIn = movido.position;

    }

	// Update is called once per frame
	void Update () {

		if (movido.position.y < 195) {
			movido.position += Time.deltaTime * speed * transform.up;
			reanudar=false;
		} else {
			if (movido.position.y < 1300 && movido.position.y > -281) {
				if(reanudar){
				movido.position += Time.deltaTime * speed * transform.up;
				}
				else{
					Invoke("SpeedIgual",3f);
				}
			}
			else{
				movido.position = posIn;
			
			
			}
		}

	}
	public void SpeedIgual(){
		
		reanudar=true;


	}
	void Refrescar () {
		for (int i = 0; i < ScoreList.longitud - 1; i++) {
			texNombresTopScore [i].text = ScoreList.topscore [i].name;
			texPuntosTopScore [i].text = ScoreList.topscore [i].puntos.ToString();
			imagenTopScore [i].sprite = Cantidades.imagenesNinnos [ScoreList.topscore[i].ninno];
		
		}
	}
}
