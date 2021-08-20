using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pongManager : MonoBehaviour
{
    [SerializeField]
    Ball ball;
    [SerializeField]
    AIPaddle aiPaddle;
    [SerializeField]
    HumanPaddle humanPaddle;

    public void startGame()
    {
        //start the game by changing the ball velocity to send it off
        ball.GetComponent<Rigidbody2D>().velocity = new Vector2(-5, 0);
        humanPaddle.started = true;
    }

    public void endGame()
    {
        //stop the ball from moving
        ball.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
        //stop the player from inputting commands
        humanPaddle.started = false;
        //reset the position of both paddles and the ball
        ball.transform.position = new Vector3(-3.76f, 0, 0);
        humanPaddle.transform.position = new Vector3(-8.085f, 0, 0);
        aiPaddle.transform.position = new Vector3(0.38f, 0, 0);
    }
}
