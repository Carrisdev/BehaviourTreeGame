using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class turtleScore : MonoBehaviour
{
    string scoreText;

    private void Start()
    {
        scoreText = "Score\n\nTotal #\nof instructions: 00\nTotal # of steps: 00";
    }

    public void updateInstruction(int score)
    {
        //if the instruction score is less than 10, we want to add a 0 to keep consistency in the text. also it looks nicer
        if(score > 9)
        {
            scoreText = "Score\n\nTotal #\nof instructions: " + score + "\nTotal # of steps: 00";
        }
        else
        {
            scoreText = "Score\n\nTotal #\nof instructions: 0" + score + "\nTotal # of steps: 00";
        }
        updateText();
    }

    private void updateText()
    {
        gameObject.GetComponent<Text>().text = scoreText;
    }

    public void updateSteps(int score)
    {
        //remove the final numbers from the scoretext. since it is a large string, we can't change it without trim
        scoreText = scoreText.TrimEnd(new char[] { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9' });
        //if the instruction score is less than 10, we want to add a 0 to keep consistency in the text. also it looks nicer
        if (score < 10)
        {
            scoreText = scoreText + "0" + score;
        }
        else
        {
            scoreText = scoreText + score;
        }

        updateText();
    }
}
