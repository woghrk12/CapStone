using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using UnityEngine;
using UnityEngine.UI;

public enum State { Idle, Complete, Damaged, Destroyed };

class Building
{
    public Building(int _N, int _M, int _H, int _A, int _S, int _C)
    {
        NeedPopulation = _N;
        MinPopulation = _M;
        Human = _H;
        Alien = _A;
        Score = _S;
        CompleteTurn = _C;
    }

    public State state;

    Queue<char> NeedCompany;

    int NeedPopulation;
    int MinPopulation;
    int Human;
    int Alien;
    int Score;
    int CompleteTurn;
}

public class BuildingStatus : MonoBehaviour
{
    public Button StatusBtn;
    public GameManager Manager;
    public Sprite[] Sprite;

    public char BuildingType;

    State state;
    Building building;

    void Awake()
    {
        state = State.Idle;
        switch (BuildingType)
        {
            case 'A':
                building = new Building(200, 20, 0, 0, 50, 0);
                break;

            case 'B':
                building = new Building(500, 50, 0, 0, 100, 0);
                break;

            case 'C':
                building = new Building(1000, 100, 0, 0, 300, 0);
                break;

            default:
                break;
        }
    }
}
