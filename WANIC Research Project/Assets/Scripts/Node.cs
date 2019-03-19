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
    int MaxIndex;

    int P1 = 1;
    int P2 = 2;
    int P0 = 0;

    public int PlayerOne()
    {
        return PlayerOneWin;
    }
    public int PlayerTwo()
    {
        return PlayerTwoWin;
    }
    public void Tree ()
    {
        this.intialize();
        this.Branches();
        Debug.Log("Player One Wins: " + PlayerOneWin);
        Debug.Log("Player Two Wins: " + PlayerTwoWin);
        if(PlayerOneWin >= PlayerTwoWin)
        {
            Debug.Log("Player One Win Chance: " + (PlayerOneWin/(PlayerOneWin+PlayerTwoWin)));
        }
        else
        {
            Debug.Log("Player Two Win Chance: " + (PlayerTwoWin / (PlayerOneWin + PlayerTwoWin)));
        }
                
    }
    public int CominatorialGame ()
    {
        int Index = -1;
        float WinRatio = -10;

        Debug.Log("New node");

        for (int i = 0; i <= this.MaxIndex; i++)
       {
            if (this.GetNode(i).PlayerOneWin != 0 && this.GetNode(i).PlayerTwoWin != 0)
            {
                float P1W = this.GetNode(i).PlayerOneWin;
                float P2W = this.GetNode(i).PlayerTwoWin;

                if (this.Playerturn == P1)
                {
                    Debug.Log("Ratio: (P1W / P2W)" + (P1W / P2W));
                    if (WinRatio < (P1W / P2W))
                    {
                        WinRatio = (P1W / P2W);
                        Index = i;
                    }
                } else if (this.Playerturn == P2)
                {
                    Debug.Log("Ratio: (P2W / P1W)" + (P2W / P1W));
                    if (WinRatio < (P2W / P1W))
                    {
                        WinRatio = (P2W / P1W);
                        Index = i;
                    }
                }
            }
      }
      if (Index == -1)
      {
          if (this.PlayerOneWin >= 1 && this.PlayerTwoWin == 0)
          {
              Debug.Log("Player One Win Com");
                return 1;
          }
          else if (this.PlayerTwoWin >= 1 && this.PlayerOneWin == 0)
          {
              Debug.Log("Player Two Win Com");
                return 2;
          }
          else if (this.PlayerOneWin == 0 && this.PlayerTwoWin == 0)
          {
              Debug.Log("Tie Com");
                Debug.Log("Last 1: " + this.ParentNode.PlayerOneWin);
                Debug.Log("Last 2: " + this.ParentNode.PlayerTwoWin);
                Debug.Log("Now 1: " + this.PlayerOneWin);
                Debug.Log("Now 2: " + this.PlayerTwoWin);
                return 0;
          }
          else
            {
                if(this.Playerturn == 1)
                {
                    Debug.Log("Player Two Win Com");
                    return 2;
                }
                else
                {
                    Debug.Log("Player One Win Com");
                    return 1;
                }
            }
      }else
      {
            return this.GetNode(Index).CominatorialGame();
      }
      
    }
    void Branches ()
    {
        //Edit for high only

        //Makes children
        int check = -1;
        for (int i = 0; i < 4; ++i)
        {
            for (int j = 0; j < 4; ++j)
            {
                if (CurBoard[i, j].High == P0)
                {
                    this.AddChildNode();
                    check++;
                }
                if ((CurBoard[i, j].High == P0) && (CurBoard[i, j].Medium == P0))
                {
                    this.AddChildNode();
                    check++;
                }
                if ((CurBoard[i, j].High == P0) && (CurBoard[i, j].Medium == P0) && (CurBoard[i, j].Low == P0))
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
                //low
                if ((CurBoard[i, j].High == P0) && (CurBoard[i, j].Medium == P0) && (CurBoard[i, j].Low == P0))
                {
                    index++;
                    //Debug.Log("Low [" + i + ", " + j + "]");
                    if (this.GetNode(index).Playerturn == P1)
                    {
                        this.GetNode(index).Playerturn = P2;
                        this.GetNode(index).CurBoard[i, j].Low = P1;
                    }
                    else
                    {
                        this.GetNode(index).Playerturn = P1;
                        this.GetNode(index).CurBoard[i, j].Low = P2;
                    }
                }
                //Med
                if ((CurBoard[i, j].High == P0) && (CurBoard[i, j].Medium == P0))
                {
                    index++;
                    //Debug.Log("Medium [" + i + ", " + j + "]");
                    if (this.GetNode(index).Playerturn == P1)
                    {
                        this.GetNode(index).Playerturn = P2;
                        this.GetNode(index).CurBoard[i, j].Medium = P1;
                    }
                    else
                    {
                        this.GetNode(index).Playerturn = P1;
                        this.GetNode(index).CurBoard[i, j].Medium = P2;
                    }
                }
                //High
                if (CurBoard[i, j].High == P0)
                {
                    index++;
                    //Debug.Log("High [" + i + ", " + j + "]");
                    if (this.GetNode(index).Playerturn == P1)
                    {
                        this.GetNode(index).Playerturn = P2;
                        this.GetNode(index).CurBoard[i, j].High = P1;
                    }
                    else
                    {
                        this.GetNode(index).Playerturn = P1;
                        this.GetNode(index).CurBoard[i, j].High = P2;
                    }
                }

            }
        }
        //goes in chilldren
        //WARNING
        if (index == check)
        {
            this.MaxIndex = index;
            for (int i = 0; i <= index; ++i)
            {
                if (Cell.Check(CurBoard) == P0)
                {
                    this.GetNode(i).Branches();
                }
            }
            if(Cell.Check(CurBoard) == P1)
            {
                PlayerOneWin += 1;
                //Debug.Log("Player One UP = " + PlayerOneWin);
            }
            else if (Cell.Check(CurBoard) == P2)
            {
                PlayerTwoWin += 1;
                //Debug.Log("Player Two UP = " + PlayerTwoWin);
            }
        }
        else
        {
            Debug.Log("Node Branch Error:" + index + "!=" + check);
        }
        if((index < 0) && (check < 0))
        {
            //Debug.Log("End Of Branch"); 
        }
        if (ParentNode != null)
        {
            ParentNode.PlayerOneWin = ParentNode.PlayerOneWin + PlayerOneWin;
            ParentNode.PlayerTwoWin = ParentNode.PlayerTwoWin + PlayerTwoWin;
            //Debug.Log("End: " + PlayerOneWin + " " + PlayerTwoWin);
            //Debug.Log("Parent: " + ParentNode.PlayerOneWin + " " + ParentNode.PlayerTwoWin);
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
        ChildrenNodes = new List<Node>();
        ParentNode = null;
        Playerturn = Board.PlayerTurn;
    }
    public Node(Node node)
    {
        PlayerOneWin = node.PlayerOneWin;
        PlayerTwoWin = node.PlayerTwoWin;

        CurBoard = new Cell[4,4];
        for(int i = 0; i < 4; i++)
        {
            for(int j = 0; j < 4; j++)
            {
                CurBoard[i, j] = node.CurBoard[i, j];
            }
        }

        ChildrenNodes = new List<Node>();
        ParentNode = node;
        Playerturn = node.Playerturn;
    }
    public Node()
    {
        PlayerOneWin = 0;
        PlayerTwoWin = 0;
        CurBoard = null;
        ChildrenNodes = new List<Node>();
        ParentNode = null;
        Playerturn = 0;
    }
}
