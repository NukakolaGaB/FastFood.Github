using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class RestartButton : MonoBehaviour {

    [SerializeField]
    GameObject start;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (start != null)
            {
                if (!start.activeSelf)
                {
                    Escenas.ronda = 0;
                    SceneManager.LoadScene(0);
                }
            }
            else
            {
                Escenas.ronda = 0;
                SceneManager.LoadScene(0);
            }
        }
    }
}
