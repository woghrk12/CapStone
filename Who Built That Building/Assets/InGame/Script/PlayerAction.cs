using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerAction : MonoBehaviour
{
    public GameManager Manager;
    public Text text;

    public void GetResource()
    {
        Manager.RollDiceBtn.SetActive(true);
        Manager.ActionCanvas.SetActive(false);
        Manager.UICanvas.SetActive(true);
    }

    public void SelectAction()
    {
    
    }

    void Build() 
    {
        Manager.ActionCanvas.SetActive(false);
    }

    void Repair()
    {
        Manager.ActionCanvas.SetActive(false);
    }
}
