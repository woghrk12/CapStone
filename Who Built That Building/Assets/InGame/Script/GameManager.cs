using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public int MaxLandNum = 20;
    public int LandNum;
    public int Dice;
    public int Turn;

    public int MilitaryPower;

    public GameObject RollDiceBtn;
    public GameObject ActionCanvas;
    public GameObject UICanvas;
    public GameObject[] Buildings;

    void Awake()
    {
        Turn = 1;
        MilitaryPower = 0;
        LandNum = 1;
    }

    public void RollDice() 
    {
        Dice = Random.Range(1, 7);
        LandNum += Dice;

        if (LandNum > MaxLandNum)
            LandNum = LandNum % MaxLandNum;

        ActionCanvas.SetActive(true);
        UICanvas.SetActive(false);
        RollDiceBtn.SetActive(false);
    }
}
