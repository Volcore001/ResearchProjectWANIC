using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Board : MonoBehaviour {

    public Cell[,] GameBoard = new Cell[4, 4];
	// Use this for initialization
	void Start () {
        foreach (Cell c in GameBoard)
        {
            c.init();
        }
	}
}
