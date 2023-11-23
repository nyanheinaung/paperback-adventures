using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SGameRules : MonoBehaviour
{
    private Image board;
    public bool playerTurn = true;
    private int totalMoves;
    public bool gameOver;
    public int gridSize;
    private Image[,] boxes;
    public Image gridPrefab;
   // private bool winnerDecided;

    // Start is called before the first frame update
    void Start()
    {
        board = GetComponent<Image>();
        board.rectTransform.sizeDelta = new Vector2(gridSize * 105, gridSize * 105);

        boxes = new Image[gridSize,gridSize];

        float positionCoef = (float)(gridSize - 1) / 2; 

        for (int i = 0; i < gridSize; i++)
        {
            for (int j = 0; j < gridSize; j++)
            {
                Image grid = Instantiate(gridPrefab, transform.position, transform.rotation);
                grid.transform.SetParent(transform);

                Vector3 position = new Vector3((i - positionCoef) * 105, (j - positionCoef) * 105, 0);

                grid.transform.position += position;
                boxes[i,j] = grid;
            }         
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
        else if(totalMoves == gridSize * gridSize)
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

    public void MovePlayed()
    {
        totalMoves++;        
    }

    bool Winner()
    {
        int[] iCheck = new int[gridSize];
        int[] jCheck = new int[gridSize];
        int cCheck = 0;
        int crCheck = 0;

        for (int i = 0; i<gridSize; i++)
        {
            for(int j = 0; j<gridSize; j++)
            {
                iCheck[i] += boxes[i, j].GetComponent<SPlay>().moveValue;
                jCheck[j] += boxes[j, i].GetComponent<SPlay>().moveValue;
                if (i == j)
                {
                    cCheck += boxes[i, j].GetComponent<SPlay>().moveValue;
                    crCheck += boxes[i, gridSize - j - 1].GetComponent<SPlay>().moveValue;
                }
            }
        }

        for (int k = 0; k < gridSize; k++)
        {
            if (iCheck[k] == gridSize || jCheck[k] == gridSize || cCheck == gridSize || crCheck == gridSize ||
               iCheck[k] == 0 || jCheck[k] == 0 || cCheck == 0 || crCheck == 0)
            {
                return true;
            }
        }

        return false;
    }
}
