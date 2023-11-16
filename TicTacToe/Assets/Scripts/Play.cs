using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Play : MonoBehaviour
{
    private Text xo;
    private bool validMove = true;
    public Image board;
    private GameRules gameRulesRef;
    
    // Start is called before the first frame update
    void Start()
    {
        xo = GetComponentInChildren<Text>();
        gameRulesRef = board.GetComponent<GameRules>();
  
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    
    //Needed to use EventTrigger T_T , no need for collider2D
    public void OnClicked()
    {
        if (validMove)
        {

              xo.text = SetValue();
              gameRulesRef.CheckWinner();
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
