using UnityEngine;
using System.Collections;

public class MostrarGestorSensibilidad : MonoBehaviour {

    public int clicks ;
    public GameObject canvasSensibilidad;

	public void ContarMostrar()
    {
        //Debug.Log("Clickado" + clicks + "vez");
        clicks++;
        if (clicks == 3)
        {
            canvasSensibilidad.SetActive(true);
            
        }
      
        else if (clicks > 3)
        {
            canvasSensibilidad.SetActive(false);
            clicks = 0;
        }


    }
}
