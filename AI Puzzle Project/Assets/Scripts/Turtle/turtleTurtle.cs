using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class turtleTurtle : MonoBehaviour
{
    turtleSpace[] turtleSpaces;
    //the starting space has been cardcoded in as it is known where the turtle will start
    //IF A LEVEL EDITOR IS ADDED IN POST THIS MAY NEED TO BE CHANGED
    [SerializeField]
    turtleSpace currentSpace;
    [SerializeField]
    turtleSpace startSpace;
    /// <summary>
    /// 0 is up, 1 is left, 2 is down, 3 is right
    /// </summary>
    int rotation = 0;
    // Start is called before the first frame update
    void Start()
    {
        //finds all the possible board positions the turtle could be in
        turtleSpaces = FindObjectsOfType<turtleSpace>();
    }
    //return the space the turtle is occupying
    public turtleSpace getCurrentSpace()
    {
        return currentSpace;
    }
    public void setCurrentSpace(turtleSpace space)
    {
        currentSpace = space;
    }
    public int getRotation()
    {
        return rotation;
    }
    public void rotate(bool clockwise)
    {
        //add or remove from rotate dependant on if the turtle is going clockwise or counter clockwise
        if(clockwise) { rotation++; }
        else { rotation--; }
        //keep rotation between 0 and 3
        rotation = modulo(rotation, 4);
        //rotate the turtle sprite appropriately
        transform.rotation = Quaternion.identity;
        if(rotation == 1)
        {
            transform.Rotate(0, 0, 270);
        } else if(rotation == 2)
        {
            transform.Rotate(0, 0, 180);
        } else if(rotation == 3)
        {
            transform.Rotate(0, 0, 90);
        }
    }
    //reset the turtle back to the start point
    public void returnToStart()
    {
        setCurrentSpace(startSpace);
        transform.position = startSpace.transform.position;
        transform.rotation = Quaternion.identity;
    }
    //modulo function
    int modulo(int x, int m)
    {
        return (x % m + m) % m;
    }
}
