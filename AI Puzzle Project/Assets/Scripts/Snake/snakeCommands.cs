using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class snakeCommands : MonoBehaviour
{
    //the base move command
    public bool move(bool infinite, snakeSnake snake)
    {
        //if the move is not possible, just return false entirely.
        //if the move is possible, start to move the piece in the right direction

        //are switch statements into if statements good coding practice? who knows but it works so ¯\_(ツ)_/¯
        switch (snake.getRotation())
        {
            case 0:
                if (!snake.getCurrentSpace().getUp()) { return false; }
                moveUp(infinite, snake);
                break;
            case 1:
                if (!snake.getCurrentSpace().getRight()) { return false; }
                moveRight(infinite, snake);
                break;
            case 2:
                if (!snake.getCurrentSpace().getDown()) { return false; }
                moveDown(infinite, snake);
                break;
            case 3:
                if (!snake.getCurrentSpace().getLeft()) { return false; }
                moveLeft(infinite, snake);
                break;
            default:
                Debug.LogError("Snake had a rotation variable out of bounds, " + snake.getRotation());
                break;
        }
        return true;
    }

    /// <summary>
    /// Change the position of the piece upwards
    /// </summary>
    /// <param name="infinite">If set to <c>true</c> the piece will keep moving up until it hits a wall.</param>
    public void moveUp(bool infinite, snakeSnake snake)
    {
        //USED FOR INFINITE MOVES THIS DOESN'T RETURN FOR NORMAL MOVES
        //checks if the infinite move is over. if it is, end recursion
        if (snake.getCurrentSpace().getUp() == null)
        {
            return;
        }
        snake.transform.position = snake.getCurrentSpace().getUp().transform.position;
        snake.setCurrentSpace(snake.getCurrentSpace().getUp());
        if (infinite)
        {
            moveUp(true, snake);
        }
    }

    /// <summary>
    /// Change the position of the piece downards
    /// </summary>
    /// <param name="infinite">If set to <c>true</c> the piece will keep moving down until it hits a wall.</param>
    public void moveDown(bool infinite, snakeSnake snake)
    {
        //USED FOR INFINITE MOVES THIS DOESN'T RETURN FOR NORMAL MOVES
        //checks if the infinite move is over. if it is, end recursion
        if (snake.getCurrentSpace().getDown() == null)
        {
            return;
        }
        snake.transform.position = snake.getCurrentSpace().getDown().transform.position;
        snake.setCurrentSpace(snake.getCurrentSpace().getDown());
        if (infinite)
        {
            moveDown(true, snake);
        }
    }

    /// <summary>
    /// Change the position of the piece to the left
    /// </summary>
    /// <param name="infinite">If set to <c>true</c> the piece will keep moving left until it hits a wall.</param>
    public void moveLeft(bool infinite, snakeSnake snake)
    {
        //USED FOR INFINITE MOVES THIS DOESN'T RETURN FOR NORMAL MOVES
        //checks if the infinite move is over. if it is, end recursion
        if (snake.getCurrentSpace().getLeft() == null)
        {
            return;
        }
        snake.transform.position = snake.getCurrentSpace().getLeft().transform.position;
        snake.setCurrentSpace(snake.getCurrentSpace().getLeft());
        if (infinite)
        {
            moveLeft(true, snake);
        }
    }

    /// <summary>
    /// Change the position of the piece to the right
    /// </summary>
    /// <param name="infinite">If set to <c>true</c> the piece will keep moving right until it hits a wall.</param>
    public void moveRight(bool infinite, snakeSnake snake)
    {
        //USED FOR INFINITE MOVES THIS DOESN'T RETURN FOR NORMAL MOVES
        //checks if the infinite move is over. if it is, end recursion
        if (snake.getCurrentSpace().getRight() == null)
        {
            return;
        }
        //move the piece and change the current position variable
        snake.transform.position = snake.getCurrentSpace().getRight().transform.position;
        snake.setCurrentSpace(snake.getCurrentSpace().getRight());
        //if it's an infinte move, and the piece can keep going, continue the recursion loop
        if (infinite)
        {
            moveRight(true, snake);
        }
    }


    /// <summary>
    /// Checks if the space above the turtle is free to move onto
    /// </summary>
    /// <returns><c>true</c> if the space above the turtle is free, <c>false</c> otherwise.</returns>
    public bool checkUp(snakeSnake snake)
    {
        snakeSpace checkedMove;
        checkedMove = snake.getCurrentSpace().getUp();
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
    public bool checkDown(snakeSnake snake)
    {
        snakeSpace checkedMove;
        checkedMove = snake.getCurrentSpace().getDown();
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
    public bool checkLeft(snakeSnake snake)
    {
        snakeSpace checkedMove;
        checkedMove = snake.getCurrentSpace().getLeft();
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
    public bool checkRight(snakeSnake snake)
    {
        snakeSpace checkedMove;
        checkedMove = snake.getCurrentSpace().getRight();
        if (checkedMove == null)
        {
            return false;
        }
        return true;
    }
}
