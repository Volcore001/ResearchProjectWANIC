using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class GameManager : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void Check ()
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



    }
}
