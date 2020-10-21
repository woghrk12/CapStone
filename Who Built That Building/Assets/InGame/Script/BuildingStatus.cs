using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Dynamic;
using UnityEditor.UI;
using UnityEngine;
using UnityEngine.UI;

// State of Building
public enum State { Idle, Complete, Damaged, Destroyed };

// Information of Building
public class Building
{
    public Building(int _N, int _M, int _H, int _A, int _S, int _C, int _NN, State _s)
    {
        NeedPopulation = _N;   
        MinPopulation = _M;
        Human = _H;
        Alien = _A;
        Score = _S;
        CompleteTurn = _C;
        NeedCompany = new char[_NN];
        state = _s;
    }

    private State state; // Building State

    public char[] NeedCompany;  // Array of Need Player

    // Private Member
    private int NeedPopulation; 
    private int MinPopulation;
    private int Human;
    private int Alien;
    private int Score;
    private int CompleteTurn;

    // Get Functions
    public State getState() { return state; }

    public int getNeedPopulation() { return NeedPopulation; }

    public int getMinPopulation() { return MinPopulation; }

    public int getHuman() { return Human; }

    public int getAlien() { return Alien; }

    public int getScore() { return Score; }

    public int getCompleteTurn() { return CompleteTurn; }

    // Set Function
    public void setState(State _S) { state = _S; }

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

    public Building building;

    void Awake()
    {
        switch (BuildingType)   // Initialize Building State as Building Type
        {
            case 'A':
                building = new Building(200, 20, 0, 0, 50, 0, 2, State.Idle);
                break;

            case 'B':
                building = new Building(500, 50, 0, 0, 100, 0, 3, State.Idle);
                break;

            case 'C':
                building = new Building(1000, 100, 0, 0, 300, 0, 5, State.Idle);
                break;

            default:
                break;
        }
    }
}
