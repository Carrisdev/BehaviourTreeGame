using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//This holds all the possible command functions to keep them in one place, organized, and accessible to all parts of the code
public class turtleCommandList : MonoBehaviour
{

    //the base move command
    public bool move(bool infinite, turtleTurtle turtle)
    {
        //if the move is not possible, just return false.
        //if the move is possible, start to move the piece in the right direction
        switch (turtle.getRotation())
        {
            case 0:
                if (!turtle.getCurrentSpace().getUp()) { return false; }
                moveUp(infinite, turtle);
                break;
            case 1:
                if (!turtle.getCurrentSpace().getRight()) { return false; }
                moveRight(infinite, turtle);
                break;
            case 2:
                if (!turtle.getCurrentSpace().getDown()) { return false; }
                moveDown(infinite, turtle);
                break;
            case 3:
                if (!turtle.getCurrentSpace().getLeft()) { return false; }
                moveLeft(infinite, turtle);
                break;
            default:
                Debug.LogError("Turtle had a rotation variable out of bounds, " + turtle.getRotation());
                break;
        }
        return true;
    }

    /// <summary>
    /// Change the position of the piece upwards
    /// </summary>
    /// <param name="infinite">If set to <c>true</c> the piece will keep moving up until it hits a wall.</param>
    public void moveUp(bool infinite, turtleTurtle turtle)
    {
        //checks if the player can move. if they can't, return
        if (turtle.getCurrentSpace().getUp() == null)
        {
            return;
        }
        //change the position of the turtle, then change the turtle's new currentSpace to the new space.
        turtle.transform.position = turtle.getCurrentSpace().getUp().transform.position;
        turtle.setCurrentSpace(turtle.getCurrentSpace().getUp());
        //if the move is an infinite move, continue the recursion
        if (infinite)
        {
            moveUp(true, turtle);
        }
    }

    /// <summary>
    /// Change the position of the piece downards
    /// </summary>
    /// <param name="infinite">If set to <c>true</c> the piece will keep moving down until it hits a wall.</param>
    public void moveDown(bool infinite, turtleTurtle turtle)
    {
        //checks if the turtle can move. if it can't, return
        if (turtle.getCurrentSpace().getDown() == null)
        {
            return;
        }
        //change the position of the turtle, then change the turtle's new currentSpace to the new space.
        turtle.transform.position = turtle.getCurrentSpace().getDown().transform.position;
        turtle.setCurrentSpace(turtle.getCurrentSpace().getDown());
        //if the move is an infinite move, continue the recursion
        if (infinite)
        {
            moveDown(true, turtle);
        }
    }

    /// <summary>
    /// Change the position of the piece to the left
    /// </summary>
    /// <param name="infinite">If set to <c>true</c> the piece will keep moving left until it hits a wall.</param>
    public void moveLeft(bool infinite, turtleTurtle turtle)
    {
        //checks if the turtle can move. if it can't, return
        if (turtle.getCurrentSpace().getLeft() == null)
        {
            return;
        }
        //change the position of the turtle, then change the turtle's new currentSpace to the new space.
        turtle.transform.position = turtle.getCurrentSpace().getLeft().transform.position;
        turtle.setCurrentSpace(turtle.getCurrentSpace().getLeft());
        //if the move is an infinite move, continue the recursion
        if (infinite)
        {
            moveLeft(true, turtle);
        }
    }

    /// <summary>
    /// Change the position of the piece to the right
    /// </summary>
    /// <param name="infinite">If set to <c>true</c> the piece will keep moving right until it hits a wall.</param>
    public void moveRight(bool infinite, turtleTurtle turtle)
    {
        //checks if the turtle can move. if it can't, return
        if (turtle.getCurrentSpace().getRight() == null)
        {
            return;
        }
        //change the position of the turtle, then change the turtle's new currentSpace to the new space.
        turtle.transform.position = turtle.getCurrentSpace().getRight().transform.position;
        turtle.setCurrentSpace(turtle.getCurrentSpace().getRight());
        //if the move is an infinite move, continue the recursion
        if (infinite)
        {
            moveRight(true, turtle);
        }
    }
    /// <summary>
    /// Rotates the game piece. While this might seem pointless, this is simply to keep consistency with all
    /// commands being within the game manager rather than scattered about.
    /// </summary>
    /// <param name="clockwise">If set to <c>true</c> rotate the turtle clockwise.</param>
    public void rotate(bool clockwise, turtleTurtle turtle)
    {
        turtle.rotate(clockwise);
    }

    /// <summary>
    /// Checks if the space above the turtle is free to move onto
    /// </summary>
    /// <returns><c>true</c> if the space above the turtle is free, <c>false</c> otherwise.</returns>
    public bool checkUp(turtleTurtle turtle)
    {
        turtleSpace checkedMove = null;
        //since this node is affected by rotation, we need to change which space to check dependant on the rotation
        switch(turtle.getRotation())
        {
            case 0:
                checkedMove = turtle.getCurrentSpace().getUp();
                break;
            case 1:
                checkedMove = turtle.getCurrentSpace().getRight();
                break;
            case 2:
                checkedMove = turtle.getCurrentSpace().getDown();
                break;
            case 3:
                checkedMove = turtle.getCurrentSpace().getLeft();
                break;
        }
        //return the result
        if (checkedMove == null)
        {
            return false;
        }
        return true;
    }
    /// <summary>
    /// Checks if the space below the turtle is free to move onto
    /// </summary>
    /// <returns><c>true</c> if the space below the turtle is free, <c>false</c> otherwise.</returns>
    public bool checkDown(turtleTurtle turtle)
    {
        turtleSpace checkedMove = null;
        //since this node is affected by rotation, we need to change which space to check dependant on the rotation
        switch (turtle.getRotation())
        {
            case 0:
                checkedMove = turtle.getCurrentSpace().getDown();
                break;
            case 1:
                checkedMove = turtle.getCurrentSpace().getLeft();
                break;
            case 2:
                checkedMove = turtle.getCurrentSpace().getUp();
                break;
            case 3:
                checkedMove = turtle.getCurrentSpace().getRight();
                break;
        }
        //return the result
        if (checkedMove == null)
        {
            return false;
        }
        return true;
    }
    /// <summary>
    /// Checks if the space to the left of the turtle is free to move onto
    /// </summary>
    /// <returns><c>true</c> if the space to the left of the turtle is free, <c>false</c> otherwise.</returns>
    public bool checkLeft(turtleTurtle turtle)
    {
        turtleSpace checkedMove = null;
        //since this node is affected by rotation, we need to change which space to check dependant on the rotation
        switch (turtle.getRotation())
        {
            case 0:
                checkedMove = turtle.getCurrentSpace().getLeft();

                break;
            case 1:
                checkedMove = turtle.getCurrentSpace().getUp();
                break;
            case 2:
                checkedMove = turtle.getCurrentSpace().getRight();
                break;
            case 3:
                checkedMove = turtle.getCurrentSpace().getDown();
                break;
        }
        //return the result
        if (checkedMove == null)
        {
            return false;
        }
        return true;
    }
    /// <summary>
    /// Checks if the space to the right of the turtle is free to move onto
    /// </summary>
    /// <returns><c>true</c> if the space to the right of the turtle is free, <c>false</c> otherwise.</returns>
    public bool checkRight(turtleTurtle turtle)
    {
        turtleSpace checkedMove = null;
        //since this node is affected by rotation, we need to change which space to check dependant on the rotation
        switch (turtle.getRotation())
        {
            case 0:
                checkedMove = turtle.getCurrentSpace().getRight();
                break;
            case 1:
                checkedMove = turtle.getCurrentSpace().getDown();
                break;
            case 2:
                checkedMove = turtle.getCurrentSpace().getLeft();
                break;
            case 3:
                checkedMove = turtle.getCurrentSpace().getUp();
                break;
        }
        //check the result
        if (checkedMove == null)
        {
            return false;
        }
        return true;
    }
}
