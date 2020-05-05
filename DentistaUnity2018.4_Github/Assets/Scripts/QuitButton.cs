using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class QuitButton : MonoBehaviour {


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            //Scene scena = SceneManager.GetActiveScene();
            //if (scena.buildIndex != 0)
            //{
            //    Escenas.ronda = 0;
            //    SceneManager.LoadScene(0);
            //}
            //else
            //{

                Application.Quit();

            //}
        }
    }
}