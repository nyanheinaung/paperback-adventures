using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Play : MonoBehaviour
{
    private Text xo;
    private bool validMove = true;

    //Had to take a reference from this
    public Image board;
    //To access reference to GameRules script
    private GameRules gameRulesRef;
    
    // Start is called before the first frame update
    void Start()
    {
        //Get reference  to Text component to change it into X or O
        xo = GetComponentInChildren<Text>();
        //Get GameRulesRef via "board"
        gameRulesRef = board.GetComponent<GameRules>();  
    }
   
    //Needed to use EventTrigger T_T , no need for collider2D
    public void OnClicked()
    {
        if (validMove && !gameRulesRef.gameOver)
        {
            //Make a move and draw X or O
            xo.text = SetValue();
            gameRulesRef.OneMovePlayed();
            gameRulesRef.CheckCondition();
            //This grid can no longer be played
            validMove = false;
        }

    }


    public string SetValue()
    {
        if (gameRulesRef.playerTurn)
        {
            return "O";
        }
        else
        {
            return "X";
        }
    }
}
