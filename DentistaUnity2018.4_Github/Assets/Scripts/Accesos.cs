using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public static class Accesos {

	public static Sillas sillas;
	public static NuevaComida nuevaComida;
	public static AsignadorNinnos asignadorNinnos;
	public static ControlTiempo controlTiempoLanzaComida;
	public static ControlTiempoLimpieza controlTiempoLimpieza;

	/// <summary>
	/// Array con el num del niño que le corresponde a cada player.
	/// </summary>
	public static int [] ninno = new int[] {0, 1, 2, 3, 4};

	public static Sprite[] comidaAfin = new Sprite[8];
	public static Sprite[] comidaAfin2 = new Sprite[8];

	public static bool trayBolas;
	public static bool trayLineas = true;
	public static bool relojOn;
	public static Transform canvasDentista;
}

public static class numComida {

	public const int perrito = 1;
	public const int burrito = 2;
	public const int pizza = 3;
	public const int pollo = 4;
	public const int burguer = 5;
	public const int salad = 6;
	public const int chipa = 7;
	public const int donuts = 8;
	public const int icecream = 9;
	public const int aliadaCola = 10;

}

public static class Cantidades {
	public const int ninnos = 8;

	public const float velCepillo = 300;
	public const float velRasca = 50;
	public const float velTorno = 50;
	public static int numJugadores;

	public static int [] alimentado = new int[] {0, 0, 0, 0, 0};
	public static int [] sucio = new int[] {0, 0, 0, 0, 0};
	public static int [] puntos = new int[] {0, 0, 0, 0, 0};

	public static string [] nombreJug = new string[] {"", "", "", "", ""};

	public const int puntosLimpieza = 10;

	public static float[] velocidadNinno = new float[] {5, 5, 5, 5, 5, 5, 5, 5};
	public static float[] fuerzaNinno = new float[] {5, 5, 5, 5, 5, 5, 5, 5};
	public static float[] retrasoHambre = new float[] {0, 0, 0, 0 ,0 ,0 ,0 ,0};

	public static Sprite [] imagenesNinnos = new Sprite[ninnos];

	public const float alfaMinima = 0.5f;

	public static float sensibilidad = 0.04f;

	public const int puntosDienteLimpio = 5;
	public const int puntosSuciedadQuitada = 10;
	public const int puntosCarieArreglada = 15;
}
public static class Escenas {

	public static int escenaCargada;

	public static int ronda = 0;
	public const int escenaLanzar = 0;
	public const int escenaDentista = 1;
	public const int escenaPodium = 2;
}