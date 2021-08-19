using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class treeTranslation : MonoBehaviour
{
    [SerializeField]
    turtleCommandList turtleManager;
    [SerializeField]
    public turtleTurtle turtle;
    [SerializeField]
    snakeCommands snakeManager;
    [SerializeField]
    snakeSnake snake;
    [SerializeField]
    pongCommands pongManager;
    [SerializeField]
    AIPaddle paddle;
    [SerializeField]
    Slider speed;
    [SerializeField]
    snakeScore scoreText;

    public int iteration;
    int stepScore;
    snakeSpace oldSpace;
    snakeSpace newSpace;
    public bool paused = false;
    /// <summary>
    /// Searches turtle tree for the 1 arrowed basic instructions (aka move/rotate)
    /// </summary>
    /// <param name="functionNum">Function number</param>
    public void searchTurtleFunctionsBasic(int functionNum)
    {
        /*possible functions include:
         * moving (0)
         * infinite moving (1)    
         * rotating clockwise (2)
         * rotating counterclockwise (3)
         * check up (4)
         * check down (5)
         * check left (6)
         * check right (7)
         */
        switch (functionNum)
        {
            case -2:
                return;
            case 0:
                turtleManager.move(false, turtle);
                break;
            case 1:
                turtleManager.move(true, turtle);
                break;
            case 2:
                turtleManager.rotate(true, turtle);
                break;
            case 3:
                turtleManager.rotate(false, turtle);
                break;
            //case 4:
            //    turtleManager.checkUp(turtle);
            //    break;
            //case 5:
            //    turtleManager.checkDown(turtle);
            //    break;
            //case 6:
            //    turtleManager.checkLeft(turtle);
            //    break;
            //case 7:
            //turtleManager.checkRight(turtle);
            //break;
            default:
                Debug.LogError("Function call doesn't match any in list. " + functionNum);
                break;
        }
        FindObjectOfType<turtleScore>().updateSteps(stepScore);
    }
    public int searchTurtleFunctionsCheck(float functionNum)
    {
        //get the actual instruction
        float actualInstruction = Mathf.Floor(functionNum / 10000);
        bool result = false;
        switch (actualInstruction)
        {
            case 4:
                result = turtleManager.checkUp(turtle);
                break;
            case 5:
                result = turtleManager.checkDown(turtle);
                break;
            case 6:
                result = turtleManager.checkLeft(turtle);
                break;
            case 7:
                result = turtleManager.checkRight(turtle);
                break;
            default:
                Debug.LogError("Function call doesn't match any in list. " + functionNum);
                break;
        }
        //if the tree needs to go down the "yes" path
        if(result)
        {
            //the next step along the "yes" branch is found here: 0XX00
            //get rid of the X0000 number
            functionNum -= Mathf.Floor(functionNum / 10000) * 10000;
            //get rid of the 000XX number
            functionNum = Mathf.Floor(functionNum / 100);
            //return the next iteration value
            return (int)functionNum;
        }
        //if the tree needs to go down the "no" path
        //the next step along the "no" branch is found here: 000XX
        //get rid of the XXX00 numbers
        functionNum -= Mathf.Floor(functionNum / 100) * 100;
        return (int)functionNum;
    }
    public void searchSnakeFunctionsBasic(float functionNum)
    {
        switch(functionNum)
        {
        /*possible functions include:
         * ignore node (-2)
         * moving (0) 
         * rotating clockwise (1)
         * rotating counterclockwise (2)
         * move directly upwards (3)
         * move directly downwards (4)
         * move directly to the left (5)
         * move directly to the right (6)
         */
            case -2:
                return;
            case 0:
                snakeManager.move(false, snake);
                break;
            case 1:
                snakeManager.rotate(true, snake);
                break;
            case 2:
                snakeManager.rotate(false, snake);
                break;
            case 3:
                snakeManager.moveUp(false, snake);
                break;
            case 4:
                snakeManager.moveDown(false, snake);
                break;
            case 5:
                snakeManager.moveLeft(false, snake);
                break;
            case 6:
                snakeManager.moveRight(false, snake);
                break;
            default:
                Debug.LogError("current functionnum is not assigned. " + functionNum);
                break;
        }
    }

    public int searchSnakeFunctionsCompare(float functionNum)
    {
        //get the actual instruction
        float actualInstruction = Mathf.Floor(functionNum / 1000000);
        int result = -1;
        switch (actualInstruction)
        {
            /*possible functions include:
            * compare food vertical (7)
            * compare food horizontal (8)        
            */
            case 7:
                result = snakeManager.checkFoodVertical(snake);
                break;
            case 8:
                result = snakeManager.checkFoodHorizontal(snake);
                break;
        }
        //if the tree needs to go down the "above" path
        if (result == 0)
        {
            //the next step along the "yes" branch is found here: 0XX00
            //get rid of the X000000 number
            functionNum -= Mathf.Floor(functionNum / 1000000) * 1000000;
            //get rid of the 000XXXX numbers
            functionNum = Mathf.Floor(functionNum / 10000);
            //return the next iteration value
            return (int)functionNum;
        }
        //if the tree needs to go down the "same" path
        if(result == 1)
        {
            //the next step along the "same" branch is found here: 000XX00
            //get rid of the XXX0000 numbers
            functionNum -= Mathf.Floor(functionNum / 10000) * 10000;
            //get rid of the 00000XX numbers
            functionNum = Mathf.Floor(functionNum / 100);
            return (int)functionNum;
        }
        //if the tree needs to go down the "below" path
        //the next step along the "below" branch is found here: 00000XX
        //get rid of the XXXXX00 numbers
        functionNum -= Mathf.Floor(functionNum / 100) * 100;
        return (int)functionNum;
    }

    public int searchSnakeFunctionsCheck(float functionNum)
    {
        int actualInstructions = Mathf.FloorToInt(functionNum / 10000);
        bool result = false;
        //as this section contains input fields, we can't use switch cases
        //i'll be modifying the actualInstructions field consistently throughout this section, so stacked if statements are better
        /*possible functions include:
         * checkFoodRow(9)
         * checkFoodColumn(10)
         * checkSnakeRow(11)
         * checkSnakeColumn(12)
         */
         if(Mathf.FloorToInt(actualInstructions/100) == 9)
         {
            result = snakeManager.checkFoodRow(snake, (int)actualInstructions-900);
         }
         else if (Mathf.FloorToInt(actualInstructions / 100) == 10)
         {
            result = snakeManager.checkFoodColumn(snake, (int)actualInstructions - 1000);
         }
         else if (Mathf.FloorToInt(actualInstructions / 100) == 11)
         {
            result = snakeManager.checkSnakeRow(snake, (int)actualInstructions - 1100);
         }
         else if (Mathf.FloorToInt(actualInstructions / 100) == 12)
         {
            result = snakeManager.checkSnakeColumn(snake, (int)actualInstructions - 1200);
         }
         else if(actualInstructions == 13)
         {
            result = snakeManager.checkUp(snake);
         }
         else if(actualInstructions == 14)
         {
            result = snakeManager.checkDown(snake);
         }
         else if(actualInstructions == 15)
        {
            result = snakeManager.checkLeft(snake);
        }
         else if(actualInstructions == 16)
        {
            result = snakeManager.checkRight(snake);
        }
        if (result)
        {
            //the next step along the "yes" branch is found here: 0XX00
            //get rid of the X0000 number
            functionNum -= Mathf.Floor(functionNum / 10000) * 10000;
            //get rid of the 000XX number
            functionNum = Mathf.Floor(functionNum / 100);
            //return the next iteration value
            return (int)functionNum;
        }
        //if the tree needs to go down the "no" path
        //the next step along the "no" branch is found here: 000XX
        //get rid of the XXX00 numbers
        functionNum -= Mathf.Floor(functionNum / 100) * 100;
        return (int)functionNum;
    }

    public void searchPongFunctionsBasic(float functionNum)
    {
        if(functionNum == -2)
        {
            return;
        }
        if(functionNum == 3)
        {
            pongManager.moveUp(paddle);
        }
        if(functionNum == 4)
        {
            pongManager.moveDown(paddle);
        }
        if(Mathf.FloorToInt(functionNum/100) == 5)
        {
            pongManager.moveToInput(paddle, (int)functionNum - 500);
        }
    }

    public int searchPongFunctionsCheck(float functionNum)
    {
        float actualInstruction = Mathf.Floor(functionNum / 10000);
        bool result = false;
        if (actualInstruction == 6)
        {
            result = pongManager.checkBall(paddle);
        }
        if(Mathf.FloorToInt(actualInstruction/100) == 7)
        {
            result = pongManager.checkBallInput(paddle, actualInstruction - 700);
        }
        if(Mathf.FloorToInt(actualInstruction / 100) == 8)
        {
           result = pongManager.checkBallInputX(paddle, actualInstruction - 800);
        }

        if (result)
        {
            //the next step along the "yes" branch is found here: 0XX00
            //get rid of the X0000 number
            functionNum -= Mathf.Floor(functionNum / 10000) * 10000;
            //get rid of the 000XX number
            functionNum = Mathf.Floor(functionNum / 100);
            //return the next iteration value
            return (int)functionNum;
        }
        //if the tree needs to go down the "no" path
        //the next step along the "no" branch is found here: 000XX
        //get rid of the XXX00 numbers
        functionNum -= Mathf.Floor(functionNum / 100) * 100;
        return (int)functionNum;
    }

    public IEnumerator runThroughTree(List<int> numericalTree)
    {
        stepScore = 0;
        while (true)
        {
            if (!paused)
            {
                //if we've reached a kill number, restart the iteration counter
                if (numericalTree[iteration] == -1)
                {
                    iteration = 0;
                    //no need to wait on doing nothing
                    yield return new WaitForEndOfFrame();
                }
                else
                {
                    Scene scene = SceneManager.GetActiveScene();
                    //if the scene is a turtle scene
                    if (scene.name == "Level 1" || scene.name == "Level 2" || scene.name == "Level 3")
                    {
                        //if it needs to run the basic search function
                        if (numericalTree[iteration] < 4)
                        {
                            searchTurtleFunctionsBasic(numericalTree[iteration]);
                            iteration++;
                            //modulo function to keep the iteration from continually climbing
                            iteration = (iteration % numericalTree.Count + numericalTree.Count) % numericalTree.Count;
                        }
                        //if it needs to run the more complicated search function
                        if (numericalTree[iteration] > 3)
                        {
                            iteration = searchTurtleFunctionsCheck(numericalTree[iteration]);
                        }
                    }
                    //if the scene is a snake scene
                    else if (scene.name == "Snake")
                    {
                        if (numericalTree[iteration] < 7)
                        {
                            searchSnakeFunctionsBasic(numericalTree[iteration]);
                            iteration++;
                            //modulo function to keep the iteration from continually climbing
                            iteration = (iteration % numericalTree.Count + numericalTree.Count) % numericalTree.Count;
                        }
                        //if there's a compare node instead
                        if (numericalTree[iteration] / 1000000 > 6 && numericalTree[iteration] / 1000000 < 9)
                        {
                            iteration = searchSnakeFunctionsCompare(numericalTree[iteration]);
                        }
                        if (numericalTree[iteration] / 10000 > 8)
                        {
                            iteration = searchSnakeFunctionsCheck(numericalTree[iteration]);
                        }
                    }
                    //if the scene is a pong scene
                    else if (scene.name == "Pong")
                    {
                        if (numericalTree[iteration] < 1000)
                        {
                            searchPongFunctionsBasic(numericalTree[iteration]);
                            iteration++;
                            //modulo function to keep the iteration from continually climbing
                            iteration = (iteration % numericalTree.Count + numericalTree.Count) % numericalTree.Count;
                        }
                        else
                        {
                            iteration = searchPongFunctionsCheck(numericalTree[iteration]);
                        }
                    }
                    //if the scene hasn't been assigned yet or i've spelled a name wrong
                    else
                    {
                        Debug.LogError("Scene not assigned a path in runThroughTree. Scene named " + scene.name);
                    }
                    stepScore++;
                    if (scoreText != null)
                    {
                        scoreText.updateScore2(stepScore);
                    }
                    //if the scene is pong, we can't use the slider value as the game is played in real time
                    //every other scene will tho
                    if (scene.name == "Pong")
                    {
                        yield return new WaitForEndOfFrame();
                    }
                    else
                    {
                        yield return new WaitForSeconds(speed.value);
                    }
                }

            }
            //if the game is paused, let the loop yield every frame to not cause a crash
            else
            {
                yield return new WaitForEndOfFrame();
            }
        }
        /* this will infinitely run the tree loop. the end condition is when the coroutine is killed externally
         * or the player reaches the goal, and the scene changes, killing the coroutine anyway       
         */
    }
}
