using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ControlPanel : MonoBehaviour
{

    public GameObject LogCanvas;
    public GameObject StatusCanvas;
    public GameObject UICanvas;

    public Image BuildingImage;
    public Text NeedPointText, MinPointText, ScorePointText, TurnPointText;

    void Awake() 
    {

    }

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

    public void ShowStatusPanel(BuildingStatus BuildingStatus)
    {
        NeedPointText.text = BuildingStatus.building.getNeedPopulation().ToString();
        MinPointText.text = BuildingStatus.building.getMinPopulation().ToString();
        ScorePointText.text = BuildingStatus.building.getScore().ToString();
        TurnPointText.text = BuildingStatus.building.getCompleteTurn().ToString();

        StatusCanvas.SetActive(true);
        UICanvas.SetActive(false);
    }

    public void HideStatusPanel()
    {
        StatusCanvas.SetActive(false);
        UICanvas.SetActive(true);
    }
}
