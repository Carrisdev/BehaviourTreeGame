using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class snakeSpace : MonoBehaviour
{
    //currently the board is hard coded
    //IF A LEVEL EDITOR IS ADDED THIS WILL NEED TO CHANGE
    [SerializeField]
    snakeSpace spaceUp;
    [SerializeField]
    snakeSpace spaceDown;
    [SerializeField]
    snakeSpace spaceLeft;
    [SerializeField]
    snakeSpace spaceRight;
    [SerializeField]
    bool blocked;
    List<snakeSpace> bodyPieces;
    snakeSpace tailPiece;

    /*as the board is hardcoded, using getters rather than public variables allows us to ensure
    that the board variables aren't accidentally changed for whatever reason*/
    public snakeSpace getUp()
    {
        if (spaceUp == null || spaceUp.blocked)
        {
            return null;
        }
        return spaceUp;
    }
    public snakeSpace getDown()
    {
        if (spaceDown == null || spaceDown.blocked)
        {
            return null;
        }
        return spaceDown;
    }
    public snakeSpace getLeft()
    {
        if (spaceLeft == null || spaceLeft.blocked)
        {
            return null;
        }
        return spaceLeft;
    }
    public snakeSpace getRight()
    {
        if (spaceRight == null || spaceRight.blocked)
        {
            return null;
        }
        return spaceRight;
    }
}
