using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class snakeScore : MonoBehaviour
{
    string scoreText1;
    string scoreText2;
    string scoreText3;

    private void Start()
    {
        //the snake score is in 3 string variables that are stitched together later
        scoreText1 = "Score\n\nTotal #\nof instructions: 00\n\n";
        scoreText2 = "Total # of steps: 000\n\n";
        scoreText3 = "Food collected: 00";
    }

    public void updateScore1(int score)
    {
        //keep the 10 digit 0 if the score is less than 10
        if (score > 9)
        {
            scoreText1 = "Score\n\nTotal #\nof instructions: " + score + "\n\n";
        }
        else
        {
            scoreText1 = "Score\n\nTotal #\nof instructions: 0" + score + "\n\n";
        }
        updateText();
    }

    private void updateText()
    {
        //stitch all the strings together
        gameObject.GetComponent<Text>().text = scoreText1 + scoreText2 + scoreText3;
    }

    public void updateScore2(int score)
    {
        //if the score is greater than 99, use all 3 0s
        if (score > 99)
        {
            scoreText2 = "Total # of steps: " + score + "\n\n";
        }
        //if it's higher than 9, use the last 2 0s
        else if (score > 9)
        {
            scoreText2 = "Total # of steps: 0" + score + "\n\n";
        }
        //otherwise only use the last 0
        else
        {
            scoreText2 = "Total # of steps: 00" + score + "\n\n";
        }

        updateText();
    }

    public void updateScore3(int score)
    {
        //keep the 10 digit 0 if the score is less than 10
        if (score > 9)
        {
            scoreText3 = "Food collected: " + score;
        }
        else
        {
            scoreText3 = "Food collected: 0" + score;
        }
        updateText();
    }
}
