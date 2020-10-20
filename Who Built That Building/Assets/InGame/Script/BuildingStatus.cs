using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Dynamic;
using UnityEditor.UI;
using UnityEngine;
using UnityEngine.UI;

public enum State { Idle, Complete, Damaged, Destroyed };

public class Building
{
    public Building(int _N, int _M, int _H, int _A, int _S, int _C, int _NN)
    {
        NeedPopulation = _N;
        MinPopulation = _M;
        Human = _H;
        Alien = _A;
        Score = _S;
        CompleteTurn = _C;
        NeedCompany = new char[_NN];
    }

    public State state;

    public char[] NeedCompany;

    private int NeedPopulation;
    private int MinPopulation;
    private int Human;
    private int Alien;
    private int Score;
    private int CompleteTurn;

    public int getNeedPopulation() { return NeedPopulation; }

    public int getMinPopulation() { return MinPopulation; }

    public int getHuman() { return Human; }

    public int getAlien() { return Alien; }

    public int getScore() { return Score; }

    public int getCompleteTurn() { return CompleteTurn; }

    public void setNeedPopulation(int _N) { NeedPopulation = _N; }

    public void setMinPopulation(int _M) { MinPopulation = _M; }

    public void setHuman(int _H) { Human = _H; }

    public void setAlien(int _A) { Alien = _A; }

    public void setScore(int _S) { Score = _S; }

    public void setCompleteTurn(int _C) { CompleteTurn = _C; }
}

public class BuildingStatus : MonoBehaviour
{
    public Button StatusBtn;
    public GameManager Manager;
    public Sprite[] Sprite;

    public char BuildingType;

    State state;
    public Building building;

    void Awake()
    {
        state = State.Idle;
        switch (BuildingType)
        {
            case 'A':
                building = new Building(200, 20, 0, 0, 50, 0, 2);
                break;

            case 'B':
                building = new Building(500, 50, 0, 0, 100, 0, 3);
                break;

            case 'C':
                building = new Building(1000, 100, 0, 0, 300, 0, 5);
                break;

            default:
                break;
        }
    }
}
