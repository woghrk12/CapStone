using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Node
{
    public Node(bool _isWall, int _x, int _y)
    {
        isWall = _isWall;
        x = _x;
        y = _y;
    }

    public bool isWall;
    public Node ParentNode;

    public int x, y, G, H;
    public int F { get { return G + H; } }
}

public class MarkerMove : MonoBehaviour
{
    public GameObject Marker;

    int buildingNum;
    public int Speed;

    public Vector2Int BottomLeft, TopRight, StartPos, TargetPos;
    public List<Node> FinalNodeList;

    int sizeX, sizeY;
    Node[,] NodeArray;
    Node StartNode, TargetNode, CurNode;
    List<Node> OpenList, ClosedList;

    void PathFinding() 
    {
        sizeX = TopRight.x - BottomLeft.x + 1;
        sizeY = TopRight.y - BottomLeft.y + 1;
        NodeArray = new Node[sizeX, sizeY];

        for (int i = 0; i < sizeX; i++)
        {
            for (int j = 0; j < sizeY; j++)
            {
                bool isWall = false;
                foreach (Collider2D col in Physics2D.OverlapCircleAll(new Vector2(i + BottomLeft.x, j + BottomLeft.y), 0.4f))
                    if (col.gameObject.layer == LayerMask.NameToLayer("Wall")) isWall = true;

                NodeArray[i, j] = new Node(isWall, i + BottomLeft.x, j + BottomLeft.y);
            }
        }

        StartNode = NodeArray[StartPos.x - BottomLeft.x, StartPos.y - BottomLeft.y];
        TargetNode = NodeArray[TargetPos.x - BottomLeft.x, TargetPos.y - BottomLeft.y];

        OpenList = new List<Node>() { StartNode };
        ClosedList = new List<Node>();
        FinalNodeList = new List<Node>();

        while (OpenList.Count > 0)
        {
            CurNode = OpenList[0];
            for (int i = 1; i < OpenList.Count; i++)
                if (OpenList[i].F <= CurNode.F && OpenList[i].H < CurNode.H)
                    CurNode = OpenList[i];

            OpenList.Remove(CurNode);
            ClosedList.Add(CurNode);

            if (CurNode == TargetNode)
            {
                Node TargetCurNode = TargetNode;

                while (TargetCurNode != StartNode)
                {
                    FinalNodeList.Add(TargetCurNode);
                    TargetCurNode = TargetCurNode.ParentNode;
                }

                FinalNodeList.Add(StartNode);
                FinalNodeList.Reverse();

                return;
            }
        }
    }

    void MoveMarker()
    { 
    
    }
}
