using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    int humanScore = 0;
    int AIScore = 0;
    [SerializeField]
    Text scoreText;

    public void updateScore(bool humanScored) {
        if(humanScored)
        {
            humanScore++;
        }
        else
        {
            AIScore++;
        }
        scoreText.text = "Score\nHuman: " + humanScore + "\nAI: " + AIScore;
    }
    public void resetScore()
    {
        humanScore = 0;
        AIScore = 0;
        scoreText.text = "Score\nHuman: " + humanScore + "\nAI: " + AIScore;
    }
}
