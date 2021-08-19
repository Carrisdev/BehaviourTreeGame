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
        scoreText1 = "Score\n\nTotal #\nof instructions: 00\n\n";
        scoreText2 = "Total # of steps: 000\n\n";
        scoreText3 = "Food collected: 00";
    }

    public void updateScore1(int score)
    {
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
        gameObject.GetComponent<Text>().text = scoreText1 + scoreText2 + scoreText3;
    }

    public void updateScore2(int score)
    {
        if (score > 99)
        {
            scoreText2 = "Total # of steps: " + score + "\n\n";
        }
        else if (score > 9)
        {
            scoreText2 = "Total # of steps: 0" + score + "\n\n";
        }
        else
        {
            scoreText2 = "Total # of steps: 00" + score + "\n\n";
        }

        updateText();
    }

    public void updateScore3(int score)
    {
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
