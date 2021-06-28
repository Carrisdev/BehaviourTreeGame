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
        if(spaceUp == null || blocked)
        {
            return null;
        }
        return spaceUp;
    }
    public turtleSpace getDown()
    {
        if (spaceDown == null || blocked)
        {
            return null;
        }
        return spaceDown;
    }
    public turtleSpace getLeft()
    {
        if (spaceLeft == null || blocked)
        {
            return null;
        }
        return spaceLeft;
    }
    public turtleSpace getRight()
    {
        if (spaceRight == null || blocked)
        {
            return null;
        }
        return spaceRight;
    }
}