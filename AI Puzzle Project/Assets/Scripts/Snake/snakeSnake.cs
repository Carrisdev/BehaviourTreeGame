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
    /// <summary>
    /// 0 is up, 1 is left, 2 is down, 3 is right
    /// </summary>
    int rotation = 0;
    public List<snakeSpace> bodyPieces;
    // Start is called before the first frame update
    void Start()
    {
        //finds all the possible board positions the turtle could be in
        snakeSpaces = FindObjectsOfType<snakeSpace>();
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
        setCurrentSpace(startSpace);
        transform.position = startSpace.transform.position;
    }
    int modulo(int x, int m)
    {
        return (x % m + m) % m;
    }
}