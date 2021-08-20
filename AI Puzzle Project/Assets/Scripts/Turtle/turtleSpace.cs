using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class turtleSpace : MonoBehaviour
{
    //currently the board is hard coded
    //IF A LEVEL EDITOR IS ADDED THIS WILL NEED TO CHANGE
    [SerializeField]
    turtleSpace spaceUp;
    [SerializeField]
    turtleSpace spaceDown;
    [SerializeField]
    turtleSpace spaceLeft;
    [SerializeField]
    turtleSpace spaceRight;
    [SerializeField]
    bool blocked;

    /*as the board is hardcoded, using getters rather than public variables allows us to ensure
    that the board variables aren't accidentally changed for whatever reason*/
    public turtleSpace getUp()
    {
        //return the space above if it exists
        if(spaceUp == null || spaceUp.blocked)
        {
            return null;
        }
        return spaceUp;
    }
    public turtleSpace getDown()
    {
        //return the space below if it exists
        if (spaceDown == null || spaceDown.blocked)
        {
            return null;
        }
        return spaceDown;
    }
    public turtleSpace getLeft()
    {
        //return the space to the left if it exists
        if (spaceLeft == null || spaceLeft.blocked)
        {
            return null;
        }
        return spaceLeft;
    }
    public turtleSpace getRight()
    {
        //return the space to the right if it exists
        if (spaceRight == null || spaceRight.blocked)
        {
            return null;
        }
        return spaceRight;
    }
}