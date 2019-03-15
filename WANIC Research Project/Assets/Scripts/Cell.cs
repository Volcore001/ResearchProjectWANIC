/******************************************************************************/
/*!
\file   GameManager.cs
\author Kyle Jamison, William Siauw
\brief  
    This class contains the information for each cell of the game board
*/
/******************************************************************************/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public struct Cell {
    public int High;
    public int Medium;
    public int Low;

    

    public override string ToString()
    {
        return "H: " + High + " M: " + Medium + " Low: " + Low;
    }
    public void init()
    {
        High = 0;
        Medium = 0;
        Low = 0;
    }

    public Cell(Cell cell)
    {
        High = cell.High;
        Medium = cell.Medium;
        Low = cell.Low;
    }

    public static int Check(Cell[,] board)
    {
        int[,] board2 = new int[4, 4];
        for (int i = 0; i < 4; i++)
        {
            for (int j = 0; j < 4; j++)
            {
                if (board[i, j].High != 0)
                {
                    board2[i, j] = board[i, j].High;
                }
                else if (board[i, j].Medium != 0)
                {
                    board2[i, j] = board[i, j].Medium;
                }
                else
                {
                    board2[i, j] = board[i, j].Low;
                }
            }
        }

        for (int i = 0; i < 4; i++)
        {
            //Debug.Log(board2[0, 0] + " " + board2[1, 0] + " " + board2[2, 0] + " " + board2[3, 0]);
            //Debug.Log(board2[0, 1] + " " + board2[1, 1] + " " + board2[2, 1] + " " + board2[3, 1]);
            //Debug.Log(board2[0, 2] + " " + board2[1, 2] + " " + board2[2, 2] + " " + board2[3, 2]);
            //Debug.Log(board2[0, 3] + " " + board2[1, 3] + " " + board2[2, 3] + " " + board2[3, 3]);

            //Vertical ----
            if (board2[i, 0] == board2[i, 1] && board2[i, 1] == board2[i, 2] && board2[i, 2] == board2[i, 3])
            {
                if (board2[i, 0] == 1)
                {
                    //Player One Wins
                    Debug.Log("P1 Vertical win " + i);
                    return 1;
                }
                else if (board2[i, 0] == 2)
                {
                    //Player Two Wins
                    Debug.Log("P2 Vertical win " + i);
                    return 2;
                }
            }
            //Horizontal ----
            if (board2[0, i] == board2[1, i] && board2[1, i] == board2[2, i] && board2[2, i] == board2[3, i])
            {
                if (board2[0, i] == 1)
                {
                    //Player One Wins
                    Debug.Log("P1 Horizontal win " + i);
                    return 1;
                }
                else if (board2[0, i] == 2)
                {
                    //Player Two Wins
                    Debug.Log("P2 Horizontal win " + i);
                    return 2;
                }
            }
        }
        //Diagonal \
        if (board2[0, 0] == board2[1, 1] && board2[1, 1] == board2[2, 2] && board2[2, 2] == board2[3, 3])
        {
            if (board2[0, 0] == 1)
            {
                //Player One Wins
                Debug.Log("P1 Diagonal \\ win  [0,0]");
                return 1;
            }
            else if (board2[0, 0] == 2)
            {
                //Player Two Wins
                Debug.Log("P2 Diagonal \\ win  [0,0]");
                return 2;
            }
        }
        //Diagonal /
        if (board2[3, 0] == board2[2, 1] && board2[2, 1] == board2[1, 2] && board2[1, 2] == board2[0, 3])
        {
            if (board2[3, 0] == 1)
            {
                //Player One Wins
                Debug.Log("P1 Diagonal / win  [3,0]");
                return 1;
            }
            else if (board2[3, 0] == 2)
            {
                //Player Two Wins
                Debug.Log("P2 Diagonal / win  [3,0]");
                return 2;
            }
        }
        bool full = true;
        for (int i = 0; i < 4; i++)
        {
            for (int j = 0; j < 4; j++)
            {
                if (Board.Get()[i, j].High == 0)
                {
                    full = false;
                }

                //Debug.Log(Board.Get()[i, j].High.ToString());
            }
        }
        if (full)
        {
            return -1;
        }
        //No victor
        return 0;
    }
}
