using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class snakeBody : MonoBehaviour
{
    public snakeSpace currentSpace;
    List<GameObject> body;
    snakeSnake snake;
    [SerializeField]
    Sprite turnSprite;
    //0 for up, 1 for left, 2 for down, 3 for right
    public int direction;

    private void Start()
    {
        //if this is the tail, we can just ignore this entirely
        if(gameObject.name == "snakeTail")
        {
            return;
        }
        //find the snake head
        snake = FindObjectOfType<snakeSnake>();
        //use the head to calculate the direction it needs to be
        //body pieces are always created just behind the head
        //if the head is above
        if(snake.transform.position.y - transform.position.y > 0.5)
        {
            //the snake is created with a Z rotation of 0, so nothing is needed
            direction = 0;
        }
        //if the head is below
        else if(snake.transform.position.y - transform.position.y < -0.5)
        {
            //point the snake downward
            transform.Rotate(0, 0, 180);
            direction = 2;
        }
        //if the head is right
        else if(snake.transform.position.x - transform.position.x > 0.5)
        {
            //point the snake right
            transform.Rotate(0, 0, 270);
            direction = 3;
        }
        //if the head is left
        else if(snake.transform.position.x - transform.position.x < -0.5)
        {
            //point the snake left
            transform.Rotate(0, 0, 90);
            direction = 1;
        }
        //get the position of the next body part to check if the body needs to turn
        //if the body is only this 1 piece, use the tail instead
        Vector3 nextBodyPart;
        if (snake.bodyPieces.Count == 1)
        {
            nextBodyPart = GameObject.Find("snakeTail").transform.position;
        }
        else
        {
            nextBodyPart = snake.bodyPieces[snake.bodyPieces.Count - 2].transform.position;
        }
        //check if the snake doesn't need to change sprite and rotation. if it doesn't we can just return since we're done at that point
        if(direction == 0 && nextBodyPart.y - transform.position.y < -0.5)
        {
            return;
        }
        if(direction == 1 && nextBodyPart.x - transform.position.x > 0.5)
        {
            return;
        }
        if(direction == 2 && nextBodyPart.y - transform.position.y > 0.5)
        {
            return;
        }
        if(direction == 3 && nextBodyPart.x - transform.position.x < -0.5)
        {
            return;
        }
        //change the body into the turn sprite
        gameObject.GetComponent<SpriteRenderer>().sprite = turnSprite;
        //see which rotation we need to set the turn to be
        //first we see how the head is in relation to the previous body sprite
        //then we use the direction variable to see how we need to rotate the sprite
        float xDifference = snake.transform.position.x - nextBodyPart.x;
        float yDifference = snake.transform.position.y - nextBodyPart.y;
        //head is to the top right
        if(xDifference > 0.5 && yDifference > 0.5)
        {
            if(direction == 0)
            {
                transform.Rotate(0, 0, 180);
            } 
            else if(direction == 3)
            {
                transform.Rotate(0, 0, -270);
            }
            else
            {
                Debug.LogError("something is wrong with the turn pieces. " + direction + ", " + xDifference + ", " + yDifference);
            }
        }
        //head is to the top left
        if(xDifference < -0.5 && yDifference > 0.5)
        {
            if(direction == 0)
            {
                transform.Rotate(0, 0, 90);
            }
            if(direction == 1)
            {
                transform.Rotate(0, 0, 180);
            }
        }
        //head is to the bottom right
        if(xDifference > 0.5 && yDifference < -0.5)
        {
            if(direction == 2)
            {
                transform.Rotate(0, 0, 90);
            }
            if(direction == 3)
            {
                transform.Rotate(0, 0, -180);
            }
        }
        //head is to the bottom left
        if(xDifference < -0.5 && yDifference < -0.5)
        {
            if(direction == 1)
            {
                transform.Rotate(0, 0, 90);
            }
            if(direction == 2)
            {
                transform.Rotate(0, 0, -180);
            }
        }
    }
}
