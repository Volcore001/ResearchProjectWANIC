using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
public class Piece : MonoBehaviour, IPointerEnterHandler
{

    [Tooltip("Which player this piece belongs to, 1 for player 1, 2 for player 2")]
    public int Player;

    [Tooltip("The size of the piece, either 1, 2, or 3 representing small medium or large respectively.")]
    public int Size;

    [Tooltip("The corresponding place of the piece, either 0 - 15, representing the 16 spaces on the board.")]
    public int Index;
    [HideInInspector]
    public Color NewColor = new Color();

    // Use this for initialization
    void Start () {
		
	}
    void OnMouseOver()
    {

    }
    // Update is called once per frame
    void Update () {     
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        switch (Board.PlayerTurn)
        {
            case 1:
                NewColor = new Color(255, 0, 0);
                break;
            case 2:
                NewColor = new Color(0, 0, 255);
                break;
        }
        ColorBlock colorVar = GetComponent<Button>().colors;
        colorVar.highlightedColor = NewColor;
        GetComponent<Button>().colors = colorVar;
    }
}
