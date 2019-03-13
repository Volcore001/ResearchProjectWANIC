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
                    if(Board.Get()[i, j].High == 1)
                    {
                        P1++;
                    }
                    if (Board.Get()[i, j].High == 2)
                    {
                        P2++;
                    }
                    if (Board.Get()[i, j].Medium == 1)
                    {
                        P1++;
                    }
                    if (Board.Get()[i, j].Medium == 2)
                    {
                        P2++;
                    }
                    if (Board.Get()[i, j].Low == 1)
                    {
                        P1++;
                    }
                    if (Board.Get()[i, j].Low == 2)
                    {
                        P2++;
                    }
                }
            }
            Vector2 victor = new Vector2(0,0);
            if(P1 >= P2)
            {
                victor = Moves(true, Board.GameBoard);
            }
            else
            {
                victor = Moves(false, Board.GameBoard);
            }
            if(victor.x > victor.y)
            {
                //Player one
                Debug.Log("Player One" + victor.ToString());
            }
            if (victor.x < victor.y)
            {
                //Player two
                Debug.Log("Player Two" + victor.ToString());
            }
            if (victor.x == victor.y)
            {
                //50/50 chance
                Debug.Log("50/50 chance" + victor.ToString());
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

    Vector2 Moves(bool PlayerOneTurn, Cell[,] board)
    {
        Cell[,] Moved = new Cell[4,4];
        for (int i = 0; i < 4; i++)
        {
            for (int j = 0; j < 4; j++)
            {
                Moved[i, j] = board[i, j];
            }
        }
        if (Check() != 0)
        {
            Vector2 victor = new Vector2(0, 0);
            //victor.Set(0.0f, 0.0f);
            if (Check() == 1)
            {
                victor.Set(1, 0);
            }
            else if (Check() == 2)
            {
                victor.Set(0, 1);
            }
            return victor;
        }
        Vector2 value = new Vector2(0, 0);
        for (int i = 0; i < 1; i++)
        {
            // Row 0
            if (Moved[i, 0].High == 0 && Moved[i, 0].Medium == 0 && Moved[i, 0].Low == 0)
            {
                if(PlayerOneTurn)
                {
                    Moved[i, 0].Low = 1;
                }else
                {
                    Moved[i, 0].Low = 2;
                }
                value += Moves(!PlayerOneTurn, Moved);
                Moved[i, 0].Low = 0;
            }
            if (Moved[i, 0].High == 0 && Moved[i, 0].Medium == 0)
            {
                if (PlayerOneTurn)
                {
                    Moved[i, 0].Medium = 1;
                }
                else
                {
                    Moved[i, 0].Medium = 2;
                }
                value += Moves(!PlayerOneTurn, Moved);
                Moved[i, 0].Medium = 0;
            }
            if (Moved[i, 0].High == 0)
            {
                if (PlayerOneTurn)
                {
                    Moved[i, 0].High = 1;
                }
                else
                {
                    Moved[i, 0].High = 2;
                }
                value += Moves(!PlayerOneTurn, Moved);
                Moved[i, 0].High = 0;
            }
            //Row 1
            if (Moved[i, 1].High == 0 && Moved[i, 1].Medium == 0 && Moved[i, 1].Low == 0)
            {
                if (PlayerOneTurn)
                {
                    Moved[i, 1].Low = 1;
                }
                else
                {
                    Moved[i, 1].Low = 2;
                }
                value += Moves(!PlayerOneTurn, Moved);
                Moved[i, 1].Low = 0;
            }
            if (Moved[i, 1].High == 0 && Moved[i, 1].Medium == 0)
            {
                if (PlayerOneTurn)
                {
                    Moved[i, 1].Medium = 1;
                }
                else
                {
                    Moved[i, 1].Medium = 2;
                }
                value += Moves(!PlayerOneTurn, Moved);
                Moved[i, 1].Medium = 0;
            }
            if (Moved[i, 1].High == 0)
            {
                if (PlayerOneTurn)
                {
                    Moved[i, 1].High = 1;
                }
                else
                {
                    Moved[i, 1].High = 2;
                }
                value += Moves(!PlayerOneTurn, Moved);
                Moved[i, 1].High = 0;
            }
            //Row 2
            if (Moved[i, 2].High == 0 && Moved[i, 2].Medium == 0 && Moved[i, 2].Low == 0)
            {
                if (PlayerOneTurn)
                {
                    Moved[i, 2].Low = 1;
                }
                else
                {
                    Moved[i, 2].Low = 2;
                }
                value += Moves(!PlayerOneTurn, Moved);
                Moved[i, 2].Low = 0;
            }
            if (Moved[i, 2].High == 0 && Moved[i, 2].Medium == 0)
            {
                if (PlayerOneTurn)
                {
                    Moved[i, 2].Medium = 1;
                }
                else
                {
                    Moved[i, 2].Medium = 2;
                }
                value += Moves(!PlayerOneTurn, Moved);
                Moved[i, 2].Medium = 0;
            }
            if (Moved[i, 2].High == 0)
            {
                if (PlayerOneTurn)
                {
                    Moved[i, 2].High = 1;
                }
                else
                {
                    Moved[i, 2].High = 2;
                }
                value += Moves(!PlayerOneTurn, Moved);
                Moved[i, 2].High = 0;
            }
            //Row 3
            if (Moved[i, 3].High == 0 && Moved[i, 3].Medium == 0 && Moved[i, 3].Low == 0)
            {
                if (PlayerOneTurn)
                {
                    Moved[i, 3].Low = 1;
                }
                else
                {
                    Moved[i, 3].Low = 2;
                }
                value += Moves(!PlayerOneTurn, Moved);
                Moved[i, 3].Low = 0;
            }
            if (Moved[i, 3].High == 0 && Moved[i, 3].Medium == 0)
            {
                if (PlayerOneTurn)
                {
                    Moved[i, 3].Medium = 1;
                }
                else
                {
                    Moved[i, 3].Medium = 2;
                }
                value += Moves(!PlayerOneTurn, Moved);
                Moved[i, 3].Medium = 0;
            }
            if (Moved[i, 3].High == 0)
            {
                if (PlayerOneTurn)
                {
                    Moved[i, 3].High = 1;
                }
                else
                {
                    Moved[i, 3].High = 2;
                }
                value += Moves(!PlayerOneTurn, Moved);
                Moved[i, 3].High = 0;
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
                if(Board.Get()[i, j].High != 0)
                {
                    board2[i, j] = Board.Get()[i, j].High;
                }
                else if(Board.Get()[i, j].Medium != 0)
                {
                    board2[i, j] = Board.Get()[i, j].Medium;
                }
                else
                {
                    board2[i, j] = Board.Get()[i, j].Low;
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
        bool full = true;
        for (int i = 0; i < 4; i++)
        {
            for (int j = 0; j < 4; j++)
            {
                if(Board.Get()[i, j].High == 0)
                {
                    full = false;
                }
                Debug.Log(Board.Get()[i, j].High.ToString());
            }
        }
        if(full)
        {
            return -1;
        }
        //No victor
        return 0;
    }
}
