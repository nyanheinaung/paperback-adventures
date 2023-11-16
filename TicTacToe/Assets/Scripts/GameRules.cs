using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameRules : MonoBehaviour
{
    public Image[] boxes;
    public bool playerTurn = true;

    // Start is called before the first frame update
    void Start()
    {       
        foreach(Image box in boxes)
        {
            box.GetComponentInChildren<Text>().text = "";
        }
    }

    public void CheckWinner()
    {
        //If no winner, continue to next turn.


        ChangePlayer();
    }

    public void ChangePlayer()
    {
        playerTurn = !playerTurn;
    }


}
