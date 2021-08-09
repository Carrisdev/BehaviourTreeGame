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
    public void reshuffle()
    {
        snakeSpace[] gridSpots = grid.GetComponentsInChildren<snakeSpace>();
        List<snakeSpace> openSpaces = new List<snakeSpace>();
        for(int i = 0; i < gridSpots.Length; i++)
        {
            if(!gridSpots[i].getBlocked())
            {
                openSpaces.Add(gridSpots[i]);
            }
        }
        int choice = Random.Range(0, openSpaces.Count);
        currentSpace = openSpaces[choice];
        transform.position = currentSpace.transform.position;
    }
}
