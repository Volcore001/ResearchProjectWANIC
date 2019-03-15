using UnityEngine;
using UnityEngine.UI;
public class Board : MonoBehaviour {

    public static Cell[,] GameBoard = new Cell[4, 4];
    public static int PlayerTurn = 1;
    public Board (Board board)
    {
        if (board != null)
        {
            //GameBoard = board.GameBoard;
        }
    }

    public void Update()
    {
        //Debug.Log("Board 4, 4: " + GameBoard[3,3].ToString());
    }
    public void UpdateCell(Piece p)
    {
        int x = 0;
        int y = 0;
        int val = p.Size;
        int index = p.Index;
        p.Player = Board.PlayerTurn;
        //Debug.Log(p.Player);
        if (p.Player == 2)
            val += 3;
        x = index % 4;
        y = index / 4;
    
        ChangeCell(x, y, val);
        if (val != 0)
        {
            p.GetComponent<Image>().color = p.NewColor;
            if (PlayerTurn == 1)
                PlayerTurn = 2;
            else
                PlayerTurn = 1;
        }
    }
    public void ChangeCell(int boardX, int boardY, int value) // Value: 0 = none / default, 1 = P:1 low, 2 = P:1 medium, 3 = P:1 high, 4 = P:2 low, 5 = P:2 medium, 6 = P:2 high
    {
        switch(value)
        {
            case 1:
                GameBoard[boardX, boardY].Low = 1;
                break;
            case 2:
                GameBoard[boardX, boardY].Medium = 1;
                break;
            case 3:
                GameBoard[boardX, boardY].High = 1;
                break;
            case 4:
                GameBoard[boardX, boardY].Low = 2;
                break;
            case 5:
                GameBoard[boardX, boardY].Medium = 2;
                break;
            case 6:
                GameBoard[boardX, boardY].High = 2;
                break;
            default:
                GameBoard[boardX, boardY].High = 0;
                GameBoard[boardX, boardY].Medium = 0;
                GameBoard[boardX, boardY].Low = 0;
                break;
        }
    }

    // Use this for initialization
    void Start () {
        foreach (Cell c in GameBoard)
        {
            c.init();
        }
    }

    public static Cell[,] Get ()
    {
        return GameBoard;
    }

    public Board GetBoard()
    {
        return this;
    }
}
