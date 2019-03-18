/******************************************************************************/
/*!
\file   GameManager.cs
\author Kyle Jamison, William Siauw
\brief  
    This class contains the algorthims to calculate the winner and play a board.
*/
/******************************************************************************/

using UnityEngine;
using UnityEngine.UI;


public class GameManager : MonoBehaviour {
    public GameObject TextWinDisplay;
    public void PerfectPlayer()
    {
        //is there a victor
        if(Check() == 0)
        {
            /*
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
            }*/

            Node node = new Node();
            node.Tree();
        }
        else
        {
            if(Check() == 1)
            {
                //Player one
                Debug.Log("Player One ERROR");
            }
            if (Check() == 2)
            {
                //Player two
                Debug.Log("Player Two ERROR");
            }
        }
    }

    /*
    Vector2 Moves(bool PlayerOneTurn, Cell[,] board)
    {
        Cell[,] PlayerBoard = new Cell[4,4];
        //Building the this Manualy because it has to be
        PlayerBoard[0, 0].Low = board[0, 0].Low;
        PlayerBoard[0, 0].Medium = board[0, 0].Medium;
        PlayerBoard[0, 0].High = board[0, 0].High;

        PlayerBoard[0, 1].Low = board[0, 1].Low;
        PlayerBoard[0, 1].Medium = board[0, 1].Medium;
        PlayerBoard[0, 1].High = board[0, 1].High;

        PlayerBoard[0, 2].Low = board[0, 2].Low;
        PlayerBoard[0, 2].Medium = board[0, 2].Medium;
        PlayerBoard[0, 2].High = board[0, 2].High;

        PlayerBoard[0, 3].Low = board[0, 3].Low;
        PlayerBoard[0, 3].Medium = board[0, 3].Medium;
        PlayerBoard[0, 3].High = board[0, 3].High;
        //1
        PlayerBoard[1, 0].Low = board[1, 0].Low;
        PlayerBoard[1, 0].Medium = board[1, 0].Medium;
        PlayerBoard[1, 0].High = board[1, 0].High;

        PlayerBoard[1, 1].Low = board[1, 1].Low;
        PlayerBoard[1, 1].Medium = board[1, 1].Medium;
        PlayerBoard[1, 1].High = board[1, 1].High;

        PlayerBoard[1, 2].Low = board[1, 2].Low;
        PlayerBoard[1, 2].Medium = board[1, 2].Medium;
        PlayerBoard[1, 2].High = board[1, 2].High;

        PlayerBoard[1, 3].Low = board[1, 3].Low;
        PlayerBoard[1, 3].Medium = board[1, 3].Medium;
        PlayerBoard[1, 3].High = board[1, 3].High;
        //2
        PlayerBoard[2, 0].Low = board[2, 0].Low;
        PlayerBoard[2, 0].Medium = board[2, 0].Medium;
        PlayerBoard[2, 0].High = board[2, 0].High;

        PlayerBoard[2, 1].Low = board[2, 1].Low;
        PlayerBoard[2, 1].Medium = board[2, 1].Medium;
        PlayerBoard[2, 1].High = board[2, 1].High;

        PlayerBoard[2, 2].Low = board[2, 2].Low;
        PlayerBoard[2, 2].Medium = board[2, 2].Medium;
        PlayerBoard[2, 2].High = board[2, 2].High;

        PlayerBoard[2, 3].Low = board[2, 3].Low;
        PlayerBoard[2, 3].Medium = board[2, 3].Medium;
        PlayerBoard[2, 3].High = board[2, 3].High;
        //3
        PlayerBoard[3, 0].Low = board[3, 0].Low;
        PlayerBoard[3, 0].Medium = board[3, 0].Medium;
        PlayerBoard[3, 0].High = board[3, 0].High;

        PlayerBoard[3, 1].Low = board[3, 1].Low;
        PlayerBoard[3, 1].Medium = board[3, 1].Medium;
        PlayerBoard[3, 1].High = board[3, 1].High;

        PlayerBoard[3, 2].Low = board[3, 2].Low;
        PlayerBoard[3, 2].Medium = board[3, 2].Medium;
        PlayerBoard[3, 2].High = board[3, 2].High;

        PlayerBoard[3, 3].Low = board[3, 3].Low;
        PlayerBoard[3, 3].Medium = board[3, 3].Medium;
        PlayerBoard[3, 3].High = board[3, 3].High;

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

        //Row 0
        // column 0
        if ((PlayerBoard[0, 0].High == 0) && (PlayerBoard[0, 0].Medium == 0) && (PlayerBoard[0, 0].Low == 0))
        {
            if(PlayerOneTurn)
            {
                PlayerBoard[0, 0].Low = 1;
            }else
            {
                PlayerBoard[0, 0].Low = 2;
            }
            value += Moves(!PlayerOneTurn, PlayerBoard);
            PlayerBoard[0, 0].Low = 0;
        }
        if ((PlayerBoard[0, 0].High == 0) && (PlayerBoard[0, 0].Medium == 0))
        {
            if (PlayerOneTurn)
            {
                PlayerBoard[0, 0].Medium = 1;
            }
            else
            {
                PlayerBoard[0, 0].Medium = 2;
            }
            value += Moves(!PlayerOneTurn, PlayerBoard);
            PlayerBoard[0, 0].Medium = 0;
        }
        if (PlayerBoard[0, 0].High == 0)
        {
            if (PlayerOneTurn)
            {
                PlayerBoard[0, 0].High = 1;
            }
            else
            {
                PlayerBoard[0, 0].High = 2;
            }
            value += Moves(!PlayerOneTurn, PlayerBoard);
            PlayerBoard[0, 0].High = 0;
        }
        //column 1
        if ((PlayerBoard[0, 1].High == 0) && (PlayerBoard[0, 1].Medium == 0) && (PlayerBoard[0, 1].Low == 0))
        {
            if (PlayerOneTurn)
            {
                PlayerBoard[0, 1].Low = 1;
            }
            else
            {
                PlayerBoard[0, 1].Low = 2;
            }
            value += Moves(!PlayerOneTurn, PlayerBoard);
            PlayerBoard[0, 1].Low = 0;
        }
        if ((PlayerBoard[0, 1].High == 0) && (PlayerBoard[0, 1].Medium == 0))
        {
            if (PlayerOneTurn)
            {
                PlayerBoard[0, 1].Medium = 1;
            }
            else
            {
                PlayerBoard[0, 1].Medium = 2;
            }
            value += Moves(!PlayerOneTurn, PlayerBoard);
            PlayerBoard[0, 1].Medium = 0;
        }
        if (PlayerBoard[0, 1].High == 0)
        {
            if (PlayerOneTurn)
            {
                PlayerBoard[0, 1].High = 1;
            }
            else
            {
                PlayerBoard[0, 1].High = 2;
            }
            value += Moves(!PlayerOneTurn, PlayerBoard);
            PlayerBoard[0, 1].High = 0;
        }
        //column 2
        if ((PlayerBoard[0, 2].High == 0) && (PlayerBoard[0, 2].Medium == 0) && (PlayerBoard[0, 2].Low == 0))
        {
            if (PlayerOneTurn)
            {
                PlayerBoard[0, 2].Low = 1;
            }
            else
            {
                PlayerBoard[0, 2].Low = 2;
            }
            value += Moves(!PlayerOneTurn, PlayerBoard);
            PlayerBoard[0, 2].Low = 0;
        }
        if ((PlayerBoard[0, 2].High == 0) && (PlayerBoard[0, 2].Medium == 0))
        {
            if (PlayerOneTurn)
            {
                PlayerBoard[0, 2].Medium = 1;
            }
            else
            {
                PlayerBoard[0, 2].Medium = 2;
            }
            value += Moves(!PlayerOneTurn, PlayerBoard);
            PlayerBoard[0, 2].Medium = 0;
        }
        if (PlayerBoard[0, 2].High == 0)
        {
            if (PlayerOneTurn)
            {
                PlayerBoard[0, 2].High = 1;
            }
            else
            {
                PlayerBoard[0, 2].High = 2;
            }
            value += Moves(!PlayerOneTurn, PlayerBoard);
            PlayerBoard[0, 2].High = 0;
        }
        //column 3
        if ((PlayerBoard[0, 3].High == 0) && (PlayerBoard[0, 3].Medium == 0) && (PlayerBoard[0, 3].Low == 0))
        {
            if (PlayerOneTurn)
            {
                PlayerBoard[0, 3].Low = 1;
            }
            else
            {
                PlayerBoard[0, 3].Low = 2;
            }
            value += Moves(!PlayerOneTurn, PlayerBoard);
            PlayerBoard[0, 3].Low = 0;
        }
        if ((PlayerBoard[0, 3].High == 0) && (PlayerBoard[0, 3].Medium == 0))
        {
            if (PlayerOneTurn)
            {
                PlayerBoard[0, 3].Medium = 1;
            }
            else
            {
                PlayerBoard[0, 3].Medium = 2;
            }
            value += Moves(!PlayerOneTurn, PlayerBoard);
            PlayerBoard[0, 3].Medium = 0;
        }
        if (PlayerBoard[0, 3].High == 0)
        {
            if (PlayerOneTurn)
            {
                PlayerBoard[0, 3].High = 1;
            }
            else
            {
                PlayerBoard[0, 3].High = 2;
            }
            value += Moves(!PlayerOneTurn, PlayerBoard);
            PlayerBoard[0, 3].High = 0;
        }
        //Row 1
        // column 0
        if ((PlayerBoard[1, 0].High == 0) && (PlayerBoard[1, 0].Medium == 0) && (PlayerBoard[1, 0].Low == 0))
        {
            if (PlayerOneTurn)
            {
                PlayerBoard[1, 0].Low = 1;
            }
            else
            {
                PlayerBoard[1, 0].Low = 2;
            }
            value += Moves(!PlayerOneTurn, PlayerBoard);
            PlayerBoard[1, 0].Low = 0;
        }
        if ((PlayerBoard[1, 0].High == 0) && (PlayerBoard[1, 0].Medium == 0))
        {
            if (PlayerOneTurn)
            {
                PlayerBoard[1, 0].Medium = 1;
            }
            else
            {
                PlayerBoard[1, 0].Medium = 2;
            }
            value += Moves(!PlayerOneTurn, PlayerBoard);
            PlayerBoard[1, 0].Medium = 0;
        }
        if (PlayerBoard[1, 0].High == 0)
        {
            if (PlayerOneTurn)
            {
                PlayerBoard[1, 0].High = 1;
            }
            else
            {
                PlayerBoard[1, 0].High = 2;
            }
            value += Moves(!PlayerOneTurn, PlayerBoard);
            PlayerBoard[1, 0].High = 0;
        }
        //column 1
        if ((PlayerBoard[1, 1].High == 0) && (PlayerBoard[1, 1].Medium == 0) && (PlayerBoard[1, 1].Low == 0))
        {
            if (PlayerOneTurn)
            {
                PlayerBoard[1, 1].Low = 1;
            }
            else
            {
                PlayerBoard[1, 1].Low = 2;
            }
            value += Moves(!PlayerOneTurn, PlayerBoard);
            PlayerBoard[1, 1].Low = 0;
        }
        if ((PlayerBoard[1, 1].High == 0) && (PlayerBoard[1, 1].Medium == 0))
        {
            if (PlayerOneTurn)
            {
                PlayerBoard[1, 1].Medium = 1;
            }
            else
            {
                PlayerBoard[1, 1].Medium = 2;
            }
            value += Moves(!PlayerOneTurn, PlayerBoard);
            PlayerBoard[1, 1].Medium = 0;
        }
        if (PlayerBoard[1, 1].High == 0)
        {
            if (PlayerOneTurn)
            {
                PlayerBoard[1, 1].High = 1;
            }
            else
            {
                PlayerBoard[1, 1].High = 2;
            }
            value += Moves(!PlayerOneTurn, PlayerBoard);
            PlayerBoard[1, 1].High = 0;
        }
        //column 2
        if ((PlayerBoard[1, 2].High == 0) && (PlayerBoard[1, 2].Medium == 0) && (PlayerBoard[1, 2].Low == 0))
        {
            if (PlayerOneTurn)
            {
                PlayerBoard[1, 2].Low = 1;
            }
            else
            {
                PlayerBoard[1, 2].Low = 2;
            }
            value += Moves(!PlayerOneTurn, PlayerBoard);
            PlayerBoard[1, 2].Low = 0;
        }
        if ((PlayerBoard[1, 2].High == 0) && (PlayerBoard[1, 2].Medium == 0))
        {
            if (PlayerOneTurn)
            {
                PlayerBoard[1, 2].Medium = 1;
            }
            else
            {
                PlayerBoard[1, 2].Medium = 2;
            }
            value += Moves(!PlayerOneTurn, PlayerBoard);
            PlayerBoard[1, 2].Medium = 0;
        }
        if (PlayerBoard[1, 2].High == 0)
        {
            if (PlayerOneTurn)
            {
                PlayerBoard[1, 2].High = 1;
            }
            else
            {
                PlayerBoard[1, 2].High = 2;
            }
            value += Moves(!PlayerOneTurn, PlayerBoard);
            PlayerBoard[1, 2].High = 0;
        }
        //column 3
        if ((PlayerBoard[1, 3].High == 0) && (PlayerBoard[1, 3].Medium == 0) && (PlayerBoard[1, 3].Low == 0))
        {
            if (PlayerOneTurn)
            {
                PlayerBoard[1, 3].Low = 1;
            }
            else
            {
                PlayerBoard[1, 3].Low = 2;
            }
            value += Moves(!PlayerOneTurn, PlayerBoard);
            PlayerBoard[1, 3].Low = 0;
        }
        if ((PlayerBoard[1, 3].High == 0) && (PlayerBoard[1, 3].Medium == 0))
        {
            if (PlayerOneTurn)
            {
                PlayerBoard[1, 3].Medium = 1;
            }
            else
            {
                PlayerBoard[1, 3].Medium = 2;
            }
            value += Moves(!PlayerOneTurn, PlayerBoard);
            PlayerBoard[1, 3].Medium = 0;
        }
        if (PlayerBoard[1, 3].High == 0)
        {
            if (PlayerOneTurn)
            {
                PlayerBoard[1, 3].High = 1;
            }
            else
            {
                PlayerBoard[1, 3].High = 2;
            }
            value += Moves(!PlayerOneTurn, PlayerBoard);
            PlayerBoard[1, 3].High = 0;
        }
        //Row 2
        // column 0
        if ((PlayerBoard[2, 0].High == 0) && (PlayerBoard[2, 0].Medium == 0) && (PlayerBoard[2, 0].Low == 0))
        {
            if (PlayerOneTurn)
            {
                PlayerBoard[2, 0].Low = 1;
            }
            else
            {
                PlayerBoard[2, 0].Low = 2;
            }
            value += Moves(!PlayerOneTurn, PlayerBoard);
            PlayerBoard[2, 0].Low = 0;
        }
        if ((PlayerBoard[2, 0].High == 0) && (PlayerBoard[2, 0].Medium == 0))
        {
            if (PlayerOneTurn)
            {
                PlayerBoard[2, 0].Medium = 1;
            }
            else
            {
                PlayerBoard[2, 0].Medium = 2;
            }
            value += Moves(!PlayerOneTurn, PlayerBoard);
            PlayerBoard[2, 0].Medium = 0;
        }
        if (PlayerBoard[2, 0].High == 0)
        {
            if (PlayerOneTurn)
            {
                PlayerBoard[2, 0].High = 1;
            }
            else
            {
                PlayerBoard[2, 0].High = 2;
            }
            value += Moves(!PlayerOneTurn, PlayerBoard);
            PlayerBoard[2, 0].High = 0;
        }
        //column 1
        if ((PlayerBoard[2, 1].High == 0) && (PlayerBoard[2, 1].Medium == 0) && (PlayerBoard[2, 1].Low == 0))
        {
            if (PlayerOneTurn)
            {
                PlayerBoard[2, 1].Low = 1;
            }
            else
            {
                PlayerBoard[2, 1].Low = 2;
            }
            value += Moves(!PlayerOneTurn, PlayerBoard);
            PlayerBoard[2, 1].Low = 0;
        }
        if ((PlayerBoard[2, 1].High == 0) && (PlayerBoard[2, 1].Medium == 0))
        {
            if (PlayerOneTurn)
            {
                PlayerBoard[2, 1].Medium = 1;
            }
            else
            {
                PlayerBoard[2, 1].Medium = 2;
            }
            value += Moves(!PlayerOneTurn, PlayerBoard);
            PlayerBoard[2, 1].Medium = 0;
        }
        if (PlayerBoard[2, 1].High == 0)
        {
            if (PlayerOneTurn)
            {
                PlayerBoard[2, 1].High = 1;
            }
            else
            {
                PlayerBoard[2, 1].High = 2;
            }
            value += Moves(!PlayerOneTurn, PlayerBoard);
            PlayerBoard[2, 1].High = 0;
        }
        //column 2
        if ((PlayerBoard[2, 2].High == 0) && (PlayerBoard[2, 2].Medium == 0) && (PlayerBoard[2, 2].Low == 0))
        {
            if (PlayerOneTurn)
            {
                PlayerBoard[2, 2].Low = 1;
            }
            else
            {
                PlayerBoard[2, 2].Low = 2;
            }
            value += Moves(!PlayerOneTurn, PlayerBoard);
            PlayerBoard[2, 2].Low = 0;
        }
        if ((PlayerBoard[2, 2].High == 0) && (PlayerBoard[2, 2].Medium == 0))
        {
            if (PlayerOneTurn)
            {
                PlayerBoard[2, 2].Medium = 1;
            }
            else
            {
                PlayerBoard[2, 2].Medium = 2;
            }
            value += Moves(!PlayerOneTurn, PlayerBoard);
            PlayerBoard[2, 2].Medium = 0;
        }
        if (PlayerBoard[2, 2].High == 0)
        {
            if (PlayerOneTurn)
            {
                PlayerBoard[2, 2].High = 1;
            }
            else
            {
                PlayerBoard[2, 2].High = 2;
            }
            value += Moves(!PlayerOneTurn, PlayerBoard);
            PlayerBoard[2, 2].High = 0;
        }
        //column 3
        if ((PlayerBoard[2, 3].High == 0) && (PlayerBoard[2, 3].Medium == 0) && (PlayerBoard[2, 3].Low == 0))
        {
            if (PlayerOneTurn)
            {
                PlayerBoard[2, 3].Low = 1;
            }
            else
            {
                PlayerBoard[2, 3].Low = 2;
            }
            value += Moves(!PlayerOneTurn, PlayerBoard);
            PlayerBoard[2, 3].Low = 0;
        }
        if ((PlayerBoard[2, 3].High == 0) && (PlayerBoard[2, 3].Medium == 0))
        {
            if (PlayerOneTurn)
            {
                PlayerBoard[2, 3].Medium = 1;
            }
            else
            {
                PlayerBoard[2, 3].Medium = 2;
            }
            value += Moves(!PlayerOneTurn, PlayerBoard);
            PlayerBoard[2, 3].Medium = 0;
        }
        if (PlayerBoard[2, 3].High == 0)
        {
            if (PlayerOneTurn)
            {
                PlayerBoard[2, 3].High = 1;
            }
            else
            {
                PlayerBoard[2, 3].High = 2;
            }
            value += Moves(!PlayerOneTurn, PlayerBoard);
            PlayerBoard[2, 3].High = 0;
        }
        //Row 3
        // column 0
        if ((PlayerBoard[3, 0].High == 0) && (PlayerBoard[3, 0].Medium == 0) && (PlayerBoard[3, 0].Low == 0))
        {
            if (PlayerOneTurn)
            {
                PlayerBoard[3, 0].Low = 1;
            }
            else
            {
                PlayerBoard[3, 0].Low = 2;
            }
            value += Moves(!PlayerOneTurn, PlayerBoard);
            PlayerBoard[3, 0].Low = 0;
        }
        if ((PlayerBoard[3, 0].High == 0) && (PlayerBoard[3, 0].Medium == 0))
        {
            if (PlayerOneTurn)
            {
                PlayerBoard[3, 0].Medium = 1;
            }
            else
            {
                PlayerBoard[3, 0].Medium = 2;
            }
            value += Moves(!PlayerOneTurn, PlayerBoard);
            PlayerBoard[3, 0].Medium = 0;
        }
        if (PlayerBoard[3, 0].High == 0)
        {
            if (PlayerOneTurn)
            {
                PlayerBoard[3, 0].High = 1;
            }
            else
            {
                PlayerBoard[3, 0].High = 2;
            }
            value += Moves(!PlayerOneTurn, PlayerBoard);
            PlayerBoard[3, 0].High = 0;
        }
        //column 1
        if ((PlayerBoard[3, 1].High == 0) && (PlayerBoard[3, 1].Medium == 0) && (PlayerBoard[3, 1].Low == 0))
        {
            if (PlayerOneTurn)
            {
                PlayerBoard[3, 1].Low = 1;
            }
            else
            {
                PlayerBoard[3, 1].Low = 2;
            }
            value += Moves(!PlayerOneTurn, PlayerBoard);
            PlayerBoard[3, 1].Low = 0;
        }
        if ((PlayerBoard[3, 1].High == 0) && (PlayerBoard[3, 1].Medium == 0))
        {
            if (PlayerOneTurn)
            {
                PlayerBoard[3, 1].Medium = 1;
            }
            else
            {
                PlayerBoard[3, 1].Medium = 2;
            }
            value += Moves(!PlayerOneTurn, PlayerBoard);
            PlayerBoard[3, 1].Medium = 0;
        }
        if (PlayerBoard[3, 1].High == 0)
        {
            if (PlayerOneTurn)
            {
                PlayerBoard[3, 1].High = 1;
            }
            else
            {
                PlayerBoard[3, 1].High = 2;
            }
            value += Moves(!PlayerOneTurn, PlayerBoard);
            PlayerBoard[3, 1].High = 0;
        }
        //column 2
        if ((PlayerBoard[3, 2].High == 0) && (PlayerBoard[3, 2].Medium == 0) && (PlayerBoard[3, 2].Low == 0))
        {
            if (PlayerOneTurn)
            {
                PlayerBoard[3, 2].Low = 1;
            }
            else
            {
                PlayerBoard[3, 2].Low = 2;
            }
            value += Moves(!PlayerOneTurn, PlayerBoard);
            PlayerBoard[3, 2].Low = 0;
        }
        if ((PlayerBoard[3, 2].High == 0) && (PlayerBoard[3, 2].Medium == 0))
        {
            if (PlayerOneTurn)
            {
                PlayerBoard[3, 2].Medium = 1;
            }
            else
            {
                PlayerBoard[3, 2].Medium = 2;
            }
            value += Moves(!PlayerOneTurn, PlayerBoard);
            PlayerBoard[3, 2].Medium = 0;
        }
        if (PlayerBoard[3, 2].High == 0)
        {
            if (PlayerOneTurn)
            {
                PlayerBoard[3, 2].High = 1;
            }
            else
            {
                PlayerBoard[3, 2].High = 2;
            }
            value += Moves(!PlayerOneTurn, PlayerBoard);
            PlayerBoard[3, 2].High = 0;
        }
        //column 3
        if ((PlayerBoard[3, 3].High == 0) && (PlayerBoard[3, 3].Medium == 0) && (PlayerBoard[3, 3].Low == 0))
        {
            if (PlayerOneTurn)
            {
                PlayerBoard[3, 3].Low = 1;
            }
            else
            {
                PlayerBoard[3, 3].Low = 2;
            }
            value += Moves(!PlayerOneTurn, PlayerBoard);
            PlayerBoard[3, 3].Low = 0;
        }
        if ((PlayerBoard[3, 3].High == 0) && (PlayerBoard[3, 3].Medium == 0))
        {
            if (PlayerOneTurn)
            {
                PlayerBoard[3, 3].Medium = 1;
            }
            else
            {
                PlayerBoard[3, 3].Medium = 2;
            }
            value += Moves(!PlayerOneTurn, PlayerBoard);
            PlayerBoard[3, 3].Medium = 0;
        }
        if (PlayerBoard[3, 3].High == 0)
        {
            if (PlayerOneTurn)
            {
                PlayerBoard[3, 3].High = 1;
            }
            else
            {
                PlayerBoard[3, 3].High = 2;
            }
            value += Moves(!PlayerOneTurn, PlayerBoard);
            PlayerBoard[3, 3].High = 0;
        }
        
        return value;
    }*/

    public int Check ()
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
            //Debug.Log(board2[0, 0] + " " + board2[1, 0] + " " + board2[2, 0] + " " + board2[3, 0]);
            //Debug.Log(board2[0, 1] + " " + board2[1, 1] + " " + board2[2, 1] + " " + board2[3, 1]);
            //Debug.Log(board2[0, 2] + " " + board2[1, 2] + " " + board2[2, 2] + " " + board2[3, 2]);
            //Debug.Log(board2[0, 3] + " " + board2[1, 3] + " " + board2[2, 3] + " " + board2[3, 3]);
            //Horizontal ----
            if (board2[i, 0] == board2[i, 1] && board2[i, 1] == board2[i, 2] && board2[i, 2] == board2[i, 3])
            {            
                if(board2[i, 0] == 1)
                {
                    //Player One Wins
                    Debug.Log("P1 Horizontal win " + i);
                    return 1;
                }
                else if(board2[i, 0] == 2)
                {
                    //Player Two Wins
                    Debug.Log("P2 Horizontal win " + i);
                    return 2;
                }
            }
            //Vertical |
            if (board2[0, i] == board2[1, i] && board2[1, i] == board2[2, i] && board2[2, i] == board2[3, i])
            {
                if (board2[0, i] == 1)
                {
                    //Player One Wins
                    Debug.Log("P1 Vertical win " + i);
                    return 1;
                }
                else if (board2[0, i] == 2)
                {
                    //Player Two Wins
                    Debug.Log("P2 Vertical win " + i);
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
                Debug.Log("P1 Diagonal / win  [3,0]");
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
                
                //Debug.Log(Board.Get()[i, j].High.ToString());
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
