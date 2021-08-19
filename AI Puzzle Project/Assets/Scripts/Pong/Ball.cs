using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    [SerializeField]
    Score score;
    Vector3 startingPosition;
    Rigidbody2D ballRigidbody;
    // Start is called before the first frame update
    void Start()
    {
        startingPosition = transform.position;
        ballRigidbody = gameObject.GetComponent<Rigidbody2D>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.name == "HumanScore")
        {
            score.updateScore(true);
            transform.position = startingPosition;
            ballRigidbody.velocity = new Vector2(0, 0);
            StartCoroutine(pauseVelocity());
        } 
        else if(collision.gameObject.name == "AIScore")
        {
            score.updateScore(false);
            transform.position = startingPosition;
            ballRigidbody.velocity = new Vector2(0, 0);
            StartCoroutine(pauseVelocity());
        }
        else if(collision.gameObject.name == "wall" || collision.gameObject.name == "wall2")
        {
            ballRigidbody.velocity = new Vector2(ballRigidbody.velocity.x, -ballRigidbody.velocity.y);
        }
        else
        {
            float xVelocity = ballRigidbody.velocity.x;
            float difference = gameObject.transform.position.y - collision.transform.position.y;
            ballRigidbody.velocity = new Vector2(-xVelocity, difference*5);

        }
    }

    IEnumerator pauseVelocity()
    {
        yield return new WaitForSeconds(1);
        if(FindObjectOfType<HumanPaddle>().started)
        {
            ballRigidbody.velocity = new Vector2(-3, 0);
        }
        yield return 0;
    }
}
