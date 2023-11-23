using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SPlay : MonoBehaviour
{
    //private Text xo; (not needed now)
    private bool validMove = true;

    public Sprite xImage;
    public Sprite oImage;
    public int moveValue;
    //Had to take a reference from this
    //public Image board;

    private Image source;

    //To access reference to GameRules script
    private SGameRules sGameRulesRef;
    
    // Start is called before the first frame update
    void Start()
    {
        //Get reference  to Text component to change it into X or O
        //xo = GetComponentInChildren<Text>();
        //Get GameRulesRef via "board"
        //source.GetComponent<Image>();
        
        source = gameObject.GetComponent<Image>();
        sGameRulesRef = gameObject.GetComponentInParent<SGameRules>();

        //sGameRulesRef = board.GetComponent<SGameRules>();
        
        moveValue = 999;
        
    }
   
    //Needed to use EventTrigger T_T , no need for collider2D
    public void OnClicked()
    {
        if (validMove && !sGameRulesRef.gameOver)
        {
            //Make a move and draw X or O
            SetImageAndMoveValue();

            sGameRulesRef.MovePlayed();
            sGameRulesRef.CheckCondition();
            //This grid can no longer be played
            validMove = false;
        }

    }


    public void SetImageAndMoveValue()
    {
        if (sGameRulesRef.playerTurn)
        {
            source.sprite = oImage;
            moveValue = 0;
        }
        else
        {
            source.sprite = xImage;
            moveValue = 1;
        }
    }
}
