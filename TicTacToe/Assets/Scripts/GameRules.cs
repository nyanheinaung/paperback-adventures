using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameRules : MonoBehaviour
{
    public Image[] boxes;
    public bool playerTurn = true;
    private int totalMoves;
    public bool gameOver;
   // private bool winnerDecided;

    // Start is called before the first frame update
    void Start()
    {       
        foreach(Image box in boxes)
        {
            box.GetComponentInChildren<Text>().text = "";
        }
        totalMoves = 0;
        gameOver = false;
    }

    public void CheckCondition()
    {
        //Check if there is winner, then current player is the winner
        if(Winner())
        {
            gameOver = true;
            DisplayWinner();
        }
        //If all grids filled and no winner, declare Tie
        else if(totalMoves == 9)
        {
            DisplayTie();
        }
        //If no winner, continue to next turn.
        else
        {
            ChangePlayer();
        }
    }

    public void ChangePlayer()
    {
        playerTurn = !playerTurn;
    }

    void DisplayWinner()
    {
        print("GameOver");
        
        if(playerTurn)
        {  
            print("Player 1 Wins");
        }
        else
        {
            print("Player 2 Wins");
        }
    }

    void DisplayTie()
    {
        print("Tie");
    }

    public void OneMovePlayed()
    {
        totalMoves++;
    }

    bool Winner()
    {
        if(boxes[0].GetComponentInChildren<Text>().text == boxes[1].GetComponentInChildren<Text>().text && boxes[1].GetComponentInChildren<Text>().text  == boxes[2].GetComponentInChildren<Text>().text && boxes[2].GetComponentInChildren<Text>().text != ""||
            boxes[3].GetComponentInChildren<Text>().text == boxes[4].GetComponentInChildren<Text>().text && boxes[4].GetComponentInChildren<Text>().text == boxes[5].GetComponentInChildren<Text>().text && boxes[5].GetComponentInChildren<Text>().text != ""||
            boxes[6].GetComponentInChildren<Text>().text == boxes[7].GetComponentInChildren<Text>().text && boxes[7].GetComponentInChildren<Text>().text == boxes[8].GetComponentInChildren<Text>().text && boxes[8].GetComponentInChildren<Text>().text != ""||
            boxes[0].GetComponentInChildren<Text>().text == boxes[3].GetComponentInChildren<Text>().text && boxes[3].GetComponentInChildren<Text>().text == boxes[6].GetComponentInChildren<Text>().text && boxes[6].GetComponentInChildren<Text>().text != ""||
            boxes[1].GetComponentInChildren<Text>().text == boxes[4].GetComponentInChildren<Text>().text && boxes[4].GetComponentInChildren<Text>().text == boxes[7].GetComponentInChildren<Text>().text && boxes[7].GetComponentInChildren<Text>().text != ""||
            boxes[2].GetComponentInChildren<Text>().text == boxes[5].GetComponentInChildren<Text>().text && boxes[5].GetComponentInChildren<Text>().text == boxes[8].GetComponentInChildren<Text>().text && boxes[8].GetComponentInChildren<Text>().text != ""||
            boxes[0].GetComponentInChildren<Text>().text == boxes[4].GetComponentInChildren<Text>().text && boxes[4].GetComponentInChildren<Text>().text == boxes[8].GetComponentInChildren<Text>().text && boxes[8].GetComponentInChildren<Text>().text != ""||
            boxes[2].GetComponentInChildren<Text>().text == boxes[4].GetComponentInChildren<Text>().text && boxes[4].GetComponentInChildren<Text>().text == boxes[6].GetComponentInChildren<Text>().text && boxes[6].GetComponentInChildren<Text>().text != ""
        )
        {            
            return true;
        }
        else
        {
            return false;
        }
            
    }
}
