using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlPanel : MonoBehaviour
{
    public GameObject LogCanvas;
    public GameObject StatusCanvas;
    public GameObject UICanvas;

    public void ShowLogPanel() 
    {
        LogCanvas.transform.position += new Vector3(0f, 0f, -50f);
        UICanvas.SetActive(false);
    }

    public void HideLogPanel()
    {
        LogCanvas.transform.position += new Vector3(0f, 0f, 50f);
        UICanvas.SetActive(true);
    }

    public void ShowStatusPanel()
    {
        StatusCanvas.SetActive(true);
        UICanvas.SetActive(false);
    }

    public void HideStatusPanel()
    {
        StatusCanvas.SetActive(false);
        UICanvas.SetActive(true);
    }
}
