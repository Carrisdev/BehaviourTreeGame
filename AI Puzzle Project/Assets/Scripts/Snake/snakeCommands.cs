using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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
                if (!snake.getCurrentSpace().getUp()) 
                {
                    //this should kill the game as the snake is trying to move somewhere blocked, aka losing
                    //currently only reloading the scene but it should do something more later
                    SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
                }
                moveUp(infinite, snake);
                break;
            case 1:
                if (!snake.getCurrentSpace().getRight())
                {
                    //currently only reloading the scene but it should do something more later
                    SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
                }
                moveRight(infinite, snake);
                break;
            case 2:
                if (!snake.getCurrentSpace().getDown())
                {
                    //currently only reloading the scene but it should do something more later
                    SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
                }
                moveDown(infinite, snake);
                break;
            case 3:
                if (!snake.getCurrentSpace().getLeft())
                {
                    //currently only reloading the scene but it should do something more later
                    SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
                }
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
        snake.rebuildSnake(snake.getCurrentSpace().getUp(), snake.getCurrentSpace());
        snake.setCurrentSpace(snake.getCurrentSpace().getUp());
        snake.getCurrentSpace().setBlocked(true);
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
        snake.rebuildSnake(snake.getCurrentSpace().getDown(), snake.getCurrentSpace());
        snake.setCurrentSpace(snake.getCurrentSpace().getDown());
        snake.getCurrentSpace().setBlocked(true);
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
        snake.rebuildSnake(snake.getCurrentSpace().getLeft(), snake.getCurrentSpace());
        snake.setCurrentSpace(snake.getCurrentSpace().getLeft());
        snake.getCurrentSpace().setBlocked(true);
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
        snake.rebuildSnake(snake.getCurrentSpace().getRight(), snake.getCurrentSpace());
        snake.setCurrentSpace(snake.getCurrentSpace().getRight());
        snake.getCurrentSpace().setBlocked(true);
        //if it's an infinte move, and the piece can keep going, continue the recursion loop
        if (infinite)
        {
            moveRight(true, snake);
        }
    }

    public void rotate(bool clockwise, snakeSnake snake)
    {
        snake.rotate(clockwise);
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

    /// <summary>
    /// checks whether the food is above or below the snake
    /// </summary>
    /// <returns>0 is the food is above, 1 is the food is below, 2 is the food is on the same row</returns>
    /// <param name="snake">the snake</param>
    public int checkFoodVertical(snakeSnake snake)
    {
        float foodPosition = snake.snakeFood.transform.position.y;
        float snakePosition = snake.transform.position.y;
        float difference = foodPosition - snakePosition;
        if(difference > 0.5f)
        {
            return 0;
        }
        if(difference < -0.5f)
        {
            return 1;
        }
        return 2;
    }
    /// <summary>
    /// checks whether the food is to the left or right of the snake
    /// </summary>
    /// <returns>0 if the food is to the right, 1 if the food is to the left, 2 is the food is on the same column</returns>
    /// <param name="snake">Snake.</param>
    public int checkFoodHorizontal(snakeSnake snake)
    {
        float foodPosition = snake.snakeFood.transform.position.x;
        float snakePosition = snake.transform.position.x;
        float difference = foodPosition - snakePosition;
        if (difference > 0.5f)
        {
            return 0;
        }
        if (difference < -0.5f)
        {
            return 1;
        }
        return 2;
    }

    public int checkSnakeHorizontal(snakeSnake snake)
    {
        string spaceName = snake.getCurrentSpace().name;
        int horizontalSpace = parseSpaceName1(spaceName);
        return horizontalSpace;
    }
    public int checkSnakeVertical(snakeSnake snake)
    {
        string spaceName = snake.getCurrentSpace().name;
        int verticalSpace = parseSpaceName2(spaceName);
        return verticalSpace;
    }
    public int checkFoodExactHorizontal(snakeSnake snake)
    {
        string spaceName = snake.snakeFood.currentSpace.name;
        int horizontalSpace = parseSpaceName1(spaceName);
        return horizontalSpace;
    }
    public int checkFoodExactVertical(snakeSnake snake)
    {
        string spaceName = snake.snakeFood.currentSpace.name;
        int verticalSpace = parseSpaceName2(spaceName);
        return verticalSpace;
    }

    int parseSpaceName1(string spaceName)
    {
        string number = "";
        for(int i = 0; i < spaceName.Length; i++)
        {
            if(spaceName[i] != ',')
            {
                number += spaceName[i];
            }
            else
            {
                return int.Parse(number);
            }
        }
        return 0;
    }
    int parseSpaceName2(string spaceName)
    {
        string number = "";
        bool x = false;
        for(int i = 0; i < spaceName.Length; i++)
        {
            if(x)
            {
                number += spaceName[i];
            }
            else if(spaceName[i] == ',')
            {
                x = true;
            }
        }
        return int.Parse(number);
    }
}
