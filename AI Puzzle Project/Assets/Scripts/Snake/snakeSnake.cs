using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class snakeSnake : MonoBehaviour
{
    snakeSpace[] snakeSpaces;
    //the starting space has been cardcoded in as it is known where the turtle will start
    //IF A LEVEL EDITOR IS ADDED IN POST THIS MAY NEED TO BE CHANGED
    [SerializeField]
    snakeSpace currentSpace;
    [SerializeField]
    snakeSpace startSpace;
    [SerializeField]
    snakeSpace tailStartSpace;
    [SerializeField]
    GameObject snakeBody;
    [SerializeField]
    GameObject snakeTail;
    [SerializeField]
    public snakeFood snakeFood;
    [SerializeField]
    snakeScore scoreText;
    int foodScore = 0;
    /// <summary>
    /// 0 is up, 1 is right, 2 is down, 3 is left
    /// </summary>
    public int rotation = 0;
    public List<GameObject> bodyPieces;
    // Start is called before the first frame update
    void Start()
    {
        //finds all the possible board positions the snake could be in
        snakeSpaces = FindObjectsOfType<snakeSpace>();
        snakeTail.GetComponent<snakeBody>().currentSpace = currentSpace;
    }
    public snakeSpace getCurrentSpace()
    {
        return currentSpace;
    }
    public void setCurrentSpace(snakeSpace space)
    {
        currentSpace = space;
    }
    public int getRotation()
    {
        return rotation;
    }
    public void rotate(bool clockwise)
    {
        //add or remove from the rotation whether the snake is moving clockwise or counter clockwise
        if (clockwise) { rotation++; }
        else { rotation--; }
        //keep the rotation between 0 and 3
        rotation = modulo(rotation, 4);
    }
    public void returnToStart()
    {
        //remove all the body pieces from the scene since the food score will go back to 0
        for(int i = 0; i < bodyPieces.Count; i++)
        {
            bodyPieces[i].GetComponent<snakeBody>().currentSpace.setBlocked(false);
            Destroy(bodyPieces[i]);
        }
        //reset the blocked bool on the spaces you're currently taking up
        snakeTail.GetComponent<snakeBody>().currentSpace.setBlocked(false);
        currentSpace.setBlocked(false);
        //move back to the start space
        setCurrentSpace(startSpace);
        //set the rotation back to forward
        rotation = 0;
        //reset the body pieces list
        bodyPieces = new List<GameObject>();
        //rebuild the snake in the new start position
        rebuildSnake(startSpace, tailStartSpace);
        foodScore = 0;

    }
    public void resetScore()
    {
        foodScore = 0;
        scoreText.updateScore3(foodScore);
    }
    int modulo(int x, int m)
    {
        return (x % m + m) % m;
    }
    public void rebuildSnake(snakeSpace newSpace, snakeSpace oldSpace)
    {
        //if the snake has no body, we can't use the body pieces as reference
        //cuz of this we have to section off this part of the code to stop an error from happening
        if (bodyPieces.Count == 0)
        {
            //move the head to the new position
            gameObject.transform.position = newSpace.transform.position;
            //rotate the head
            transform.rotation = Quaternion.identity;
            transform.Rotate(0, 0, -rotation * 90);
            //if the snake just ate some food
            if (newSpace == snakeFood.currentSpace)
            {
                //play the pickup sound
                FindObjectOfType<soundManager>().playClip("pickup");
                //move the food and add 1 to the food score
                snakeFood.reshuffle();
                foodScore++;
                scoreText.updateScore3(foodScore);
                //need to assign the position from a variable so it doesn't become a child of the old space
                Vector3 x = oldSpace.transform.position;
                //add the first body space
                GameObject newBody = Instantiate(snakeBody, x, Quaternion.identity);
                bodyPieces.Add(newBody);
                newBody.GetComponent<snakeBody>().currentSpace = oldSpace;
                //if the snake just gained a body space there's no need to move the tail, so just return
                return;
            }
            //move the tail
            snakeTail.transform.position = oldSpace.transform.position;
            //rotate the tail
            snakeTail.transform.rotation = Quaternion.identity;
            snakeTail.transform.Rotate(0, 0, rotation*-90);
            //free up the space the tail just stopped occupying
            snakeTail.GetComponent<snakeBody>().currentSpace.setBlocked(false);
            //set the tail's currentSpace to the head's old position
            snakeTail.GetComponent<snakeBody>().currentSpace = oldSpace;
            return;
        }
        //move the tail forward if the snake doesn't have to grow
        if(newSpace != snakeFood.currentSpace)
        {
            //move the tail to the oldest body position
            snakeTail.transform.position = bodyPieces[0].transform.position;
            snakeTail.GetComponent<snakeBody>().currentSpace.setBlocked(false);
            snakeTail.GetComponent<snakeBody>().currentSpace = bodyPieces[0].GetComponent<snakeBody>().currentSpace;
            //reset the tail back to a 0, 0, 0 rotation, then rotate the snaketail as the previous body was
            snakeTail.transform.rotation = Quaternion.identity;
            snakeTail.transform.Rotate(0, 0, bodyPieces[0].GetComponent<snakeBody>().direction * 90);
            //save a reference to the object before removing it, so it can be destroyed
            GameObject deleteThis = bodyPieces[0];
            //remove the oldest body position
            bodyPieces.RemoveAt(0);
            //delete the last body piece
            Destroy(deleteThis);
        }
        //if the snake had body pieces already and just ate some food, modify the score
        else
        {
            snakeFood.reshuffle();
            foodScore++;
            scoreText.updateScore3(foodScore);
        }
        //cant have the same name as the variables above. only one will ever be used tho thanks to that return
        //add a new body piece with its position from a variable to stop it being a child of the space
        Vector3 y = oldSpace.transform.position;
        GameObject newBody2 = Instantiate(snakeBody, y, Quaternion.identity);
        //add this new body piece to the list
        bodyPieces.Add(newBody2);
        newBody2.GetComponent<snakeBody>().currentSpace = oldSpace;
        //finally move the head to the new position, and rotate it as needed
        gameObject.transform.position = newSpace.transform.position;
        transform.rotation = Quaternion.identity;
        transform.Rotate(0, 0, -rotation * 90);
    }
}