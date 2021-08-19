using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//This holds all the possible command functions to keep them in one place, organized, and accessible to all parts of the code
public class turtleCommandList : MonoBehaviour
{

    //the base move command
    public bool move(bool infinite, turtleTurtle turtle)
    {
        //if the move is not possible, just return false entirely.
        //if the move is possible, start to move the piece in the right direction

        //are switch statements into if statements good coding practice? who knows but it works so ¯\_(ツ)_/¯
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
        //USED FOR INFINITE MOVES THIS DOESN'T RETURN FOR NORMAL MOVES
        //checks if the infinite move is over. if it is, end recursion
        if (turtle.getCurrentSpace().getUp() == null)
        {
            return;
        }
        turtle.transform.position = turtle.getCurrentSpace().getUp().transform.position;
        turtle.setCurrentSpace(turtle.getCurrentSpace().getUp());
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
        //USED FOR INFINITE MOVES THIS DOESN'T RETURN FOR NORMAL MOVES
        //checks if the infinite move is over. if it is, end recursion
        if (turtle.getCurrentSpace().getDown() == null)
        {
            return;
        }
        turtle.transform.position = turtle.getCurrentSpace().getDown().transform.position;
        turtle.setCurrentSpace(turtle.getCurrentSpace().getDown());
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
        //USED FOR INFINITE MOVES THIS DOESN'T RETURN FOR NORMAL MOVES
        //checks if the infinite move is over. if it is, end recursion
        if (turtle.getCurrentSpace().getLeft() == null)
        {
            return;
        }
        turtle.transform.position = turtle.getCurrentSpace().getLeft().transform.position;
        turtle.setCurrentSpace(turtle.getCurrentSpace().getLeft());
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
        //USED FOR INFINITE MOVES THIS DOESN'T RETURN FOR NORMAL MOVES
        //checks if the infinite move is over. if it is, end recursion
        if (turtle.getCurrentSpace().getRight() == null)
        {
            return;
        }
        //move the piece and change the current position variable
        turtle.transform.position = turtle.getCurrentSpace().getRight().transform.position;
        turtle.setCurrentSpace(turtle.getCurrentSpace().getRight());
        //if it's an infinte move, and the piece can keep going, continue the recursion loop
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
        if (checkedMove == null)
        {
            return false;
        }
        return true;
    }
}
