using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class treeTranslation : MonoBehaviour
{
    /*current plan. assign all the possible functions numerical values, and assign that number to each
     * of the boxes possible. Is this efficient? fuck no. a binary tree would work better but this is
     * meant to be a prototype so fuck it this'll work for now.
     * TODO: turn the series of if/else commands into an actual binary search tree or think of a better
     * way of doing this.
     */
    [SerializeField]
    turtleCommandList turtleManager;
    [SerializeField]
    turtleTurtle turtle;
    int iteration;
    private void Start()
    {
        int[] treeTESTING;
        treeTESTING = new int[2];
        treeTESTING[0] = 0;
        treeTESTING[1] = 2;
        iteration = 0;
        StartCoroutine(runThroughTree(treeTESTING));
    }
    public void searchTurtleFunctions(int functionNum)
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
            case 4:
                turtleManager.checkUp(turtle);
                break;
            case 5:
                turtleManager.checkDown(turtle);
                break;
            case 6:
                turtleManager.checkLeft(turtle);
                break;
            case 7:
                turtleManager.checkRight(turtle);
                break;
            default:
                Debug.LogError("Function call doesn't match any in list. " + functionNum);
                break;
        }
    }
    IEnumerator runThroughTree(int[] numericalTree)
    {
        while(true)
        {
            searchTurtleFunctions(numericalTree[iteration]);
            iteration++;
            iteration = (iteration % numericalTree.Length + numericalTree.Length) % numericalTree.Length;
            yield return new WaitForSeconds(0.5f);
        }
        /* this will infinitely run the tree loop. eventually I will add an end condition. I will
         * add an end condition at some point but for testing an infinite loop is fine
         */        
        //yield return 0;
    }
}
