using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class snakeCommands : MonoBehaviour
{
    [SerializeField]
    GameObject gameOverText;
    //the base move command
    public bool move(bool infinite, snakeSnake snake)
    {
        //if the move is not possible, just return false entirely.
        //if the move is possible, start to move the piece in the right direction
        switch (snake.getRotation())
        {
            case 0:
                moveUp(infinite, snake);
                break;
            case 1:
                moveRight(infinite, snake);
                break;
            case 2:
                moveDown(infinite, snake);
                break;
            case 3:
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
        //if the player runs into a wall or themself
        if (snake.getCurrentSpace().getUp() == null)
        {
            //play the death sound effect
            FindObjectOfType<soundManager>().playClip("hit");
            //stop the tree from running as the game is over until the player resets
            gameObject.GetComponent<treeTranslation>().paused = true;
            //display the game over text
            gameOverText.SetActive(true);
            return;
        }
        //set the rotation
        snake.rotation = 0;
        //rebuild the snake in the new position
        snake.rebuildSnake(snake.getCurrentSpace().getUp(), snake.getCurrentSpace());
        //set the snake's currentSpace to the new space
        snake.setCurrentSpace(snake.getCurrentSpace().getUp());
        snake.getCurrentSpace().setBlocked(true);
    }

    /// <summary>
    /// Change the position of the piece downards
    /// </summary>
    /// <param name="infinite">If set to <c>true</c> the piece will keep moving down until it hits a wall.</param>
    public void moveDown(bool infinite, snakeSnake snake)
    {
        //if the player runs into a wall or themself
        if (snake.getCurrentSpace().getDown() == null)
        {
            //play the death sound effect
            FindObjectOfType<soundManager>().playClip("hit");
            //stop the tree from running as the game is over until the player resets
            gameObject.GetComponent<treeTranslation>().paused = true;
            //display the game over text
            gameOverText.SetActive(true);
            return;
        }
        //set the rotation
        snake.rotation = 2;
        //rebuild the snake in the new position
        snake.rebuildSnake(snake.getCurrentSpace().getDown(), snake.getCurrentSpace());
        //set its new currentSpace
        snake.setCurrentSpace(snake.getCurrentSpace().getDown());
        snake.getCurrentSpace().setBlocked(true);
    }

    /// <summary>
    /// Change the position of the piece to the left
    /// </summary>
    /// <param name="infinite">If set to <c>true</c> the piece will keep moving left until it hits a wall.</param>
    public void moveLeft(bool infinite, snakeSnake snake)
    {
        if (snake.getCurrentSpace().getLeft() == null)
        {
            //play the death sound effect
            FindObjectOfType<soundManager>().playClip("hit");
            //stop the tree from running as the game is over until the player resets
            gameObject.GetComponent<treeTranslation>().paused = true;
            //display the game over text
            gameOverText.SetActive(true);
            return;
        }
        //set the rotation
        snake.rotation = 3;
        //rebuild the snake
        snake.rebuildSnake(snake.getCurrentSpace().getLeft(), snake.getCurrentSpace());
        //set its new currentPosition
        snake.setCurrentSpace(snake.getCurrentSpace().getLeft());
        snake.getCurrentSpace().setBlocked(true);
    }

    /// <summary>
    /// Change the position of the piece to the right
    /// </summary>
    /// <param name="infinite">If set to <c>true</c> the piece will keep moving right until it hits a wall.</param>
    public void moveRight(bool infinite, snakeSnake snake)
    {
        if (snake.getCurrentSpace().getRight() == null)
        {
            //play the death sound effect
            FindObjectOfType<soundManager>().playClip("hit");
            //stop the tree from running as the game is over until the player resets
            gameObject.GetComponent<treeTranslation>().paused = true;
            //display the game over text
            gameOverText.SetActive(true);
            return;
        }
        //set the rotation
        snake.rotation = 1;
        //rebuild the snake
        snake.rebuildSnake(snake.getCurrentSpace().getRight(), snake.getCurrentSpace());
        //set its new currentPosition
        snake.setCurrentSpace(snake.getCurrentSpace().getRight());
        snake.getCurrentSpace().setBlocked(true);
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
    /// <returns>0 if the food is above, 1 if the food is on the same row, 2 if the food is below</returns>
    /// <param name="snake">the snake</param>
    public int checkFoodVertical(snakeSnake snake)
    {
        //get the snake and food's Y positions
        float foodPosition = snake.snakeFood.transform.position.y;
        float snakePosition = snake.transform.position.y;
        float difference = snakePosition - foodPosition;
        //if the food is above the snake
        if(difference < -0.5f)
        {
            return 0;
        }
        //if the food is below the snake
        if(difference > 0.5f)
        {
            return 2;
        }
        return 1;
    }
    /// <summary>
    /// checks whether the food is to the left or right of the snake
    /// </summary>
    /// <returns>0 if the food is to the right, 1 is the food is on the same column, 2 if the food is to the left</returns>
    /// <param name="snake">Snake.</param>
    public int checkFoodHorizontal(snakeSnake snake)
    {
        //get the snake and food's X position
        float foodPosition = snake.snakeFood.transform.position.x;
        float snakePosition = snake.transform.position.x;
        float difference = snakePosition - foodPosition;
        //if the food is to the left
        if (difference > 0.5f)
        {
            return 0;
        }
        //if the food is to the right
        if (difference < -0.5f)
        {
            return 2;
        }
        return 1;
    }

    public int checkSnakeHorizontal(snakeSnake snake)
    {
        //get the name of the space the snake is in
        string spaceName = snake.getCurrentSpace().name;
        //get the 2nd number in it, as that's the horizontal space we want to return
        int horizontalSpace = parseSpaceName2(spaceName);
        return horizontalSpace;
    }

    public int checkSnakeVertical(snakeSnake snake)
    {
        //get the name of the space the snake is in
        string spaceName = snake.getCurrentSpace().name;
        //get the 1st number in it, as that's the vertical space we want to return
        int verticalSpace = parseSpaceName1(spaceName);
        return verticalSpace;
    }

    public int checkFoodExactHorizontal(snakeSnake snake)
    {
        //get the name of the space the food is in
        string spaceName = snake.snakeFood.currentSpace.name;
        //get the 2nd number in it, as that's the horizontal space we want to return
        int horizontalSpace = parseSpaceName2(spaceName);
        return horizontalSpace;
    }

    public int checkFoodExactVertical(snakeSnake snake)
    {
        //get the name of the space the snake is in
        string spaceName = snake.snakeFood.currentSpace.name;
        //get the 1st number in it, as that's the vertical space we want to return
        int verticalSpace = parseSpaceName1(spaceName);
        return verticalSpace;
    }

    public bool checkFoodRow(snakeSnake snake, int row)
    {
        if(checkFoodExactHorizontal(snake) == row)
        {
            return true;
        }
        return false;
    }

    public bool checkFoodColumn(snakeSnake snake, int column)
    {

        if (checkFoodExactVertical(snake) == column)
        {
            return true;
        }
        return false;
    }

    public bool checkSnakeRow(snakeSnake snake, int row)
    {
        if (checkSnakeHorizontal(snake) == row)
        {
            return true;
        }
        return false;
    }

    public bool checkSnakeColumn(snakeSnake snake, int column)
    {
        if (checkSnakeVertical(snake) == column)
        {
            return true;
        }
        return false;
    }

    int parseSpaceName1(string spaceName)
    {
        string number = "";
        for(int i = 0; i < spaceName.Length; i++)
        {
            //reads the string until it sees a comma, then sends that number back as an int
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
        //reads the string once it sees a comma, then sends that back as an int
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
