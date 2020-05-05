using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class TopScore : MonoBehaviour {

	[SerializeField] Text textoTopScore;

	[SerializeField] Text [] texNombresTopScore = new Text[ScoreList.longitud - 1];
	[SerializeField] Text [] texPuntosTopScore = new Text[ScoreList.longitud - 1];
	[SerializeField] Image [] imagenTopScore = new Image[ScoreList.longitud - 1];

	score suScore;

	// Use this for initialization
	void Start () {


		Refrescar ();
	
		for (int i = 1; i <= Cantidades.numJugadores; i++) {
			MeterScore (Cantidades.nombreJug [i], Cantidades.puntos [i], Accesos.ninno [i]);
		}
		GrabarScores ();
	}

	public void MeterScore (string newName, int newPuntos, int newNinno) {

		score nuevo = new score (newName, newPuntos, newNinno);

		ScoreList.topscore [ScoreList.longitud - 1] = nuevo;
		for (int i = ScoreList.longitud - 1; i > 0; i--) {
			if (ScoreList.topscore [i].puntos > ScoreList.topscore [i-1].puntos) {
				score aux = ScoreList.topscore [i-1];
				ScoreList.topscore [i-1] = ScoreList.topscore [i];
				ScoreList.topscore [i] = aux;
			}
		}

		Refrescar ();
	}

	void Refrescar () {
		for (int i = 0; i < ScoreList.longitud - 1; i++) {
			texNombresTopScore [i].text = ScoreList.topscore [i].name;
			texPuntosTopScore [i].text = ScoreList.topscore [i].puntos.ToString();
			imagenTopScore [i].sprite = Cantidades.imagenesNinnos [ScoreList.topscore[i].ninno];
		}
	}

	public void GrabarScores () {
		for (int i = 0; i < ScoreList.longitud - 1; i++) {
			PlayerPrefs.SetString ("TopName"+i.ToString(), ScoreList.topscore [i].name);
			PlayerPrefs.SetInt ("TopScore"+i.ToString(), ScoreList.topscore [i].puntos);
			PlayerPrefs.SetInt ("Ninno"+i.ToString(), ScoreList.topscore [i].ninno);
		}
		PlayerPrefs.Save ();
	}
}
public class score {
	public string name;
	public int puntos;
	public int ninno;

	public score (string newName, int newPuntos, int newNinno) {
		name = newName;
		puntos = newPuntos;
		ninno = newNinno;
	}
	public score () {
		name = "";
		puntos = 0;
		ninno = 1;
	}
}
public static class ScoreList {
	/// <summary>
	/// array con el topscore, el ultimo elemento no es escore, es para ordenar.
	/// </summary>
	public static score [] topscore = new score[6] {new score(), new score(), new score(), new score(), new score(), new score()};

	public static int longitud = ScoreList.topscore.Length;

}