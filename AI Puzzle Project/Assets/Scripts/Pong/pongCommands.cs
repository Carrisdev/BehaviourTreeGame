using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pongCommands : MonoBehaviour
{
    [SerializeField]
    Ball ball;
    public void moveUp(AIPaddle paddle)
    {
        paddle.moveUp();
    }
    public void moveDown(AIPaddle paddle)
    {
        paddle.moveDown();
    }
    public void moveToInput(AIPaddle paddle, float input)
    {
        //input is a percentage of the screen height, so we want to translate that into an actual Y coordinate
        //the % input is very slightly skewed due to dividing by 99 and not 100, but this way the input field can still be locked to 2 characters
        //input 0 is = -4.15
        //input 99 is = 4.15
        float positionalInput = input / 99 * 8.3f - 4.15f;
        //move the paddle in the direction it needs to go to match up with the desired location
        if(paddle.transform.position.y < positionalInput)
        {
            paddle.moveUp();
        }
        else if(paddle.transform.position.y > positionalInput)
        {
            paddle.moveDown();
        }
    }
    public bool checkBall(AIPaddle paddle)
    {
        if(ball.transform.position.y > paddle.transform.position.y)
        {
            return true;
        }
        return false;
    }
    public bool checkBallInput(AIPaddle paddle, float input)
    {
        //change the % value passed in by the player to an actual position
        float positionalInput = input / 99 * 8.3f - 4.15f;
        if(ball.transform.position.y > positionalInput)
        {
            return true;
        }
        return false;
    }
    public bool checkBallInputX(AIPaddle paddle, float input)
    {
        //change the % value passed in by the player to an actual position
        float positionalInput = input / 99 * 8.46f - 4.23f;
        //need to shift it to the left as 0 is not the middle
        positionalInput -= 3.85f;
        if(ball.transform.position.x < positionalInput)
        {
            return true;
        }
        return false;
    }
}
