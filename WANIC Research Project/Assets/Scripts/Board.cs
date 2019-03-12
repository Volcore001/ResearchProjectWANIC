using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Board : MonoBehaviour {

    public Cell[,] GameBoard = new Cell[4, 4];
    public Button sd;
	// Use this for initialization
	void Start () {
        foreach (Cell c in GameBoard)
        {
            c.init();
        }
    }
}
