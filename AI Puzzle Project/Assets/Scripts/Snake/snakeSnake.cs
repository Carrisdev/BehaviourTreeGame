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
        if (clockwise) { rotation++; }
        else { rotation--; }
        rotation = modulo(rotation, 4);
    }
    public void returnToStart()
    {
        for(int i = 0; i < bodyPieces.Count; i++)
        {
            bodyPieces[i].GetComponent<snakeBody>().currentSpace.setBlocked(false);
            Destroy(bodyPieces[i]);
        }
        snakeTail.GetComponent<snakeBody>().currentSpace.setBlocked(false);
        currentSpace.setBlocked(false);
        setCurrentSpace(startSpace);
        rotation = 0;
        bodyPieces = new List<GameObject>();
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
        if (bodyPieces.Count == 0)
        {
            gameObject.transform.position = newSpace.transform.position;
            transform.rotation = Quaternion.identity;
            transform.Rotate(0, 0, -rotation * 90);
            if (newSpace == snakeFood.currentSpace)
            {
                FindObjectOfType<soundManager>().playClip("pickup");
                snakeFood.reshuffle();
                foodScore++;
                scoreText.updateScore3(foodScore);
                //need to assign from a variable so it doesn't become a child of the old space
                Vector3 x = oldSpace.transform.position;
                GameObject newBody = Instantiate(snakeBody, x, Quaternion.identity);
                bodyPieces.Add(newBody);
                newBody.GetComponent<snakeBody>().currentSpace = oldSpace;
                return;
            }
            snakeTail.transform.position = oldSpace.transform.position;
            snakeTail.transform.rotation = Quaternion.identity;
            snakeTail.transform.Rotate(0, 0, rotation*-90);
            snakeTail.GetComponent<snakeBody>().currentSpace.setBlocked(false);
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
        else
        {
            snakeFood.reshuffle();
            foodScore++;
            scoreText.updateScore3(foodScore);
        }
        //cant have the same name as the variables above. only one will ever be used tho thanks to that return
        Vector3 y = oldSpace.transform.position;
        GameObject newBody2 = Instantiate(snakeBody, y, Quaternion.identity);
        bodyPieces.Add(newBody2);
        newBody2.GetComponent<snakeBody>().currentSpace = oldSpace;
        gameObject.transform.position = newSpace.transform.position;
        transform.rotation = Quaternion.identity;
        transform.Rotate(0, 0, -rotation * 90);
    }
}