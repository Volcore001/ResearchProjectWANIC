using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class GameManager : MonoBehaviour {

    public void PerfectPlayer()
    {
        //is there a victor
        if(Check() == 0)
        {
            int P1 = 0;
            int P2 = 0;
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    if(Board.GetInstance().Get()[i, j].High == 1)
                    {
                        P1++;
                    }
                    if (Board.GetInstance().Get()[i, j].High == 2)
                    {
                        P2++;
                    }
                    if (Board.GetInstance().Get()[i, j].Medium == 1)
                    {
                        P1++;
                    }
                    if (Board.GetInstance().Get()[i, j].Medium == 2)
                    {
                        P2++;
                    }
                    if (Board.GetInstance().Get()[i, j].Low == 1)
                    {
                        P1++;
                    }
                    if (Board.GetInstance().Get()[i, j].Low == 2)
                    {
                        P2++;
                    }
                }
            }
            int victor = 0;
            if(P1 >= P2)
            {
                victor = Moves(true, Board.GetInstance());
            }
            else
            {
                victor = Moves(false, Board.GetInstance());
            }
            if(victor > 0)
            {
                //Player one
                Debug.Log("Player One");
            }
            if (victor < 0)
            {
                //Player two
                Debug.Log("Player Two");
            }
            if (victor == 0)
            {
                //50/50 chance
                Debug.Log("50/50 chance");
            }

        }
        else
        {
            if(Check() == 1)
            {
                //Player one
                Debug.Log("Player One");
            }
            if (Check() == 2)
            {
                //Player two
                Debug.Log("Player Two");
            }
        }
    }

    int Moves(bool PlayerOneTurn, Board board)
    {
        Board Moved = board;
        if (Check() != 0)
        {
            if (Check() == 1)
            {
                return 1;
            }
            else
            {
                return -1;
            }
        }
        int value = 0;
        for (int i = 0; i < 4; i++)
        {
            for (int j = 0; j < 4; j++)
            {
                if (Moved.Get()[i, j].High == 0 && Moved.Get()[i, j].Medium == 0 && Moved.Get()[i, j].Low == 0)
                {
                    if(PlayerOneTurn)
                    {
                        Moved.ChangeCell(i, j, 1);
                    }else
                    {
                        Moved.ChangeCell(i, j, 4);
                    }
                    value += Moves(!PlayerOneTurn, Moved);
                }
                if (Moved.Get()[i, j].High == 0 && Moved.Get()[i, j].Medium == 0)
                {
                    if (PlayerOneTurn)
                    {
                        Moved.ChangeCell(i, j, 2);
                    }
                    else
                    {
                        Moved.ChangeCell(i, j, 5);
                    }
                    value += Moves(!PlayerOneTurn, Moved);
                }
                if (Moved.Get()[i, j].High == 0)
                {
                    if (PlayerOneTurn)
                    {
                        Moved.ChangeCell(i, j, 3);
                    }
                    else
                    {
                        Moved.ChangeCell(i, j, 6);
                    }
                    value += Moves(!PlayerOneTurn, Moved);
                }
            }
        }
        return value;
    }

    int Check ()
    {
        int[,] board2 = new int[4,4];
        for (int i = 0; i < 4; i++)
        {
            for (int j = 0; j < 4; j++)
            {
                if(Board.GetInstance().Get()[i, j].High != 0)
                {
                    board2[i, j] = Board.GetInstance().Get()[i, j].High;
                }
                else if(Board.GetInstance().Get()[i, j].Medium != 0)
                {
                    board2[i, j] = Board.GetInstance().Get()[i, j].Medium;
                }
                else
                {
                    board2[i, j] = Board.GetInstance().Get()[i, j].Low;
                }
            }
        }

        for (int i = 0; i < 4; i++)
        { 
            //Horizontal ----
            if (board2[i, 0] == board2[i, 1] && board2[i, 1] == board2[i, 2] && board2[i, 2] == board2[i, 3])
            {            
                if(board2[i, 0] == 1)
                {
                    //Player One Wins
                    return 1;
                }
                else if(board2[i, 0] == 2)
                {
                    //Player Two Wins
                    return 2;
                }
            }
            //Vertical |
            if (board2[0, i] == board2[1, i] && board2[1, i] == board2[2, i] && board2[2, i] == board2[3, i])
            {
                if (board2[0, i] == 1)
                {
                    //Player One Wins
                    return 1;
                }
                else if (board2[0, i] == 2)
                {
                    //Player Two Wins
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
                return 1;
            }
            else if (board2[0, 0] == 2)
            {
                //Player Two Wins
                return 2;
            }
        }
        //Diagonal /
        if (board2[3, 0] == board2[2, 1] && board2[2, 1] == board2[1, 2] && board2[1, 2] == board2[0, 3])
        {
            if (board2[3, 0] == 1)
            {
                //Player One Wins
                return 1;
            }
            else if (board2[3, 0] == 2)
            {
                //Player Two Wins
                return 2;
            }
        }
        //No victor
        return 0;
    }
}
