using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Node
{
    int PlayerOneWin;
    int PlayerTwoWin;
    Cell[,] CurBoard;
    List<Node> ChildrenNodes;
    public Node ParentNode;
    int Playerturn;



    void Tree ()
    {
        this.intialize();
        this.Branches();
    }
    void Branches ()
    {
        //Makes children
        int check = -1;
        for (int i = 0; i < 4; ++i)
        {
            for (int j = 0; j < 4; ++j)
            {
                if (CurBoard[i, j].High == 0)
                {
                    this.AddChildNode();
                    check++;
                }
                if ((CurBoard[i, j].High == 0) && (CurBoard[i, j].Medium == 0))
                {
                    this.AddChildNode();
                    check++;
                }
                if ((CurBoard[i, j].High == 0) && (CurBoard[i, j].Medium == 0) && (CurBoard[i, j].Low == 0))
                {
                    this.AddChildNode();
                    check++;
                }
            }
        }
        //Moves the peices per children
        int index = -1;
        for (int i = 0; i < 4; ++i)
        {
            for (int j = 0; j < 4; ++j)
            {
                if (CurBoard[i, j].High == 0)
                {
                    index++;
                    if (this.GetNode(index).Playerturn == 1)
                    {
                        this.GetNode(index).Playerturn = 2;
                        this.GetNode(index).CurBoard[i, j].High = 1;
                    }
                    else
                    {
                        this.GetNode(index).Playerturn = 1;
                        this.GetNode(index).CurBoard[i, j].High = 2;
                    }
                }
                if ((CurBoard[i, j].High == 0) && (CurBoard[i, j].Medium == 0))
                {
                    index++;
                    if (this.GetNode(index).Playerturn == 1)
                    {
                        this.GetNode(index).Playerturn = 2;
                        this.GetNode(index).CurBoard[i, j].High = 1;
                    }
                    else
                    {
                        this.GetNode(index).Playerturn = 1;
                        this.GetNode(index).CurBoard[i, j].High = 2;
                    }
                }
                if ((CurBoard[i, j].High == 0) && (CurBoard[i, j].Medium == 0) && (CurBoard[i, j].Low == 0))
                {
                    index++;
                    if (this.GetNode(index).Playerturn == 1)
                    {
                        this.GetNode(index).Playerturn = 2;
                        this.GetNode(index).CurBoard[i, j].High = 1;
                    }
                    else
                    {
                        this.GetNode(index).Playerturn = 1;
                        this.GetNode(index).CurBoard[i, j].High = 2;
                    }
                }
            }
        }
        //goes in chilldren
        //WARNING
        if (index == check)
        {
            for (int i = 0; i <= index; ++i)
            {
                this.GetNode(i).Branches();
            }
        }else
        {
            Debug.Log("Node Branch Error");
        }
    }
    Node GetNode (int Index)
    {
        return ChildrenNodes[Index];
    }
    void AddChildNode ()
    {
        Node newNode = new Node(this);
        ChildrenNodes.Add(newNode);
    }
    void intialize ()
    {
        PlayerOneWin = 0;
        PlayerTwoWin = 0;
        CurBoard = Board.GameBoard;
        ChildrenNodes = null;
        ParentNode = null;
        Playerturn = Board.PlayerTurn;
    }
    public Node(Node node)
    {
        PlayerOneWin = node.PlayerOneWin;
        PlayerTwoWin = node.PlayerTwoWin;
        CurBoard = node.CurBoard;
        ChildrenNodes = null;
        ParentNode = node;
        Playerturn = node.Playerturn;
    }
}
