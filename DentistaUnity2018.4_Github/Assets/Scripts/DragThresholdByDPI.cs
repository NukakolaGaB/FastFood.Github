using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class DragThresholdByDPI : MonoBehaviour
{
    public int defaultValue;
    //public Text dpi;
    //public Text dragT;

    void Start()
    {
        //Debug.Log(Screen.dpi);
        defaultValue = EventSystem.current.pixelDragThreshold;
        EventSystem.current.pixelDragThreshold =
                Mathf.Max(defaultValue,(int)(defaultValue * Screen.dpi / 160f));
        //dpi.text = Screen.dpi.ToString();
        //dragT.text = EventSystem.current.pixelDragThreshold.ToString();

    }
}
