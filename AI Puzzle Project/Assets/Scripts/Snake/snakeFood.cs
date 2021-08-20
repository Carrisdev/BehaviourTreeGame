using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class snakeFood : MonoBehaviour
{
    [SerializeField]
    GameObject grid;
    public snakeSpace currentSpace;
    snakeSnake snake;
    private void Start()
    {
        //randomize the position of the food at the start of the scene
        int x = Random.Range(1, 9);
        int y = Random.Range(1, 9);
        while((x == 5 && y == 3 ) || (x == 5 && y == 2))
        {
            x = Random.Range(0, 9);
            y = Random.Range(0, 9);
        }
        currentSpace = GameObject.Find(x + "," + y).GetComponent<snakeSpace>();
        transform.position = currentSpace.transform.position;
    }
    //every time the food is picked up, move it to another free space
    public void reshuffle()
    {
        snakeSpace[] gridSpots = grid.GetComponentsInChildren<snakeSpace>();
        List<snakeSpace> openSpaces = new List<snakeSpace>();
        //get all the open spaces
        for(int i = 0; i < gridSpots.Length; i++)
        {
            if(!gridSpots[i].getBlocked())
            {
                openSpaces.Add(gridSpots[i]);
            }
        }
        //pick 1 at random
        int choice = Random.Range(0, openSpaces.Count);
        //move the food to this new, random space
        currentSpace = openSpaces[choice];
        transform.position = currentSpace.transform.position;
    }
}
