using UnityEngine;

public class Board : MonoBehaviour {

    public Cell[,] GameBoard = new Cell[4, 4];
    static Board instance;
    private void Awake()
    {
        instance = this;
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
        if (p.Player == 2)
            val += 3;
        else if (p.Player == 0)
            val = 0;
        x = index % 4;
        y = index / 4;
        ChangeCell(x, y, val);
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
    public static Board GetInstance()
    { return instance; }
    // Use this for initialization
    void Start () {
        foreach (Cell c in GameBoard)
        {
            c.init();
        }
    }

    public Cell[,] Get ()
    {
        return GameBoard;
    }
}
