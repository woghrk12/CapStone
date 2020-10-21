using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerAction : PlayerManager
{
    public GameManager Manager;
    public Text text;

    BuildingStatus _Status;

    int _BuildingNum;
    bool isIdle;

    void Update() 
    {
        _BuildingNum = Manager.LandNum;
        _Status = Manager.Buildings[_BuildingNum];

        if (_Status.building.getState() == State.Idle)
        {
            text.text = "건물 건설";
            isIdle = true;
        }
        else if (_Status.building.getState() == State.Damaged)
        {
            text.text = "건물 수리";
            isIdle = false;
        }
    }

    public void GetResource()   // When Click GetResource Button
    {
        Manager.RollDiceBtn.SetActive(true);
        Manager.ActionCanvas.SetActive(false);
        Manager.UICanvas.SetActive(true);
    }

    public void SelectAction()  // When Click Build / Repair Button
    {
        if (isIdle) Build();
        else Repair();
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
