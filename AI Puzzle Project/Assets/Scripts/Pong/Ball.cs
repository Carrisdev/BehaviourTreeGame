using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    [SerializeField]
    Score score;
    Vector3 startingPosition;
    Rigidbody2D ballRigidbody;
    void Start()
    {
        startingPosition = transform.position;
        ballRigidbody = gameObject.GetComponent<Rigidbody2D>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //if the ball hits the AI's goal area
        if(collision.gameObject.name == "HumanScore")
        {
            //give the human a point
            score.updateScore(true);
            //reset balls position
            transform.position = startingPosition;
            ballRigidbody.velocity = new Vector2(0, 0);
            //give the ball a small delay before being sent off again
            StartCoroutine(pauseVelocity());
            //play the goal sound effect
            FindObjectOfType<soundManager>().playClip("point");
        } 
        //if the ball hits the human's goal area
        else if(collision.gameObject.name == "AIScore")
        {
            //give the AI a point
            score.updateScore(false);
            //reset the balls position
            transform.position = startingPosition;
            ballRigidbody.velocity = new Vector2(0, 0);
            //give the ball a small delay before being sent off again
            StartCoroutine(pauseVelocity());
            //play the goal sound effect
            FindObjectOfType<soundManager>().playClip("point");
        }
        else if(collision.gameObject.name == "wall" || collision.gameObject.name == "wall2")
        {
            //if the ball hits a wall, bounce off of it and play the bounce sound effect
            ballRigidbody.velocity = new Vector2(ballRigidbody.velocity.x, -ballRigidbody.velocity.y);
            FindObjectOfType<soundManager>().playClip("bounce");
        }
        else
        {
            //if the ball hits a paddle, calculate how much spin to put on the ball and bounce it off
            float xVelocity = ballRigidbody.velocity.x;
            float difference = gameObject.transform.position.y - collision.transform.position.y;
            ballRigidbody.velocity = new Vector2(-xVelocity, difference*7);
            //play the bounce sound effect
            FindObjectOfType<soundManager>().playClip("bounce");
        }
    }

    IEnumerator pauseVelocity()
    {
        //wait for a second, then add the velocity back to the ball
        yield return new WaitForSeconds(1);
        if(FindObjectOfType<HumanPaddle>().started)
        {
            ballRigidbody.velocity = new Vector2(-5, 0);
        }
        yield return 0;
    }
}
