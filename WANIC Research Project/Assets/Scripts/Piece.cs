using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Piece : MonoBehaviour {

    [Tooltip("Which player this piece belongs to, 1 for player 1, 2 for player 2")]
    public int Player;

    [Tooltip("The size of the piece, either 1, 2, or 3 representing small medium or large respectively.")]
    public int Size;

    [Tooltip("The corresponding place of the piece, either 0 - 15, representing the 16 spaces on the board.")]
    public int Index;
    // Use this for initialization
    void Start () {
		
	}

	// Update is called once per frame
	void Update () {
		
	}
}
