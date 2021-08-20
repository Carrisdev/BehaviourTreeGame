using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class snakeGameManager : MonoBehaviour
{
    //can be hardcoded for now
    //IF I ADD A LEVEL EDITOR THIS HAS TO CHANCE
    [SerializeField]
    snakeSnake snake;
    [SerializeField]
    snakeCommands commandSnake;
    //THIS WAS A TEST FILE SOLELY USED TO TEST WHETHER THE SNAKE COULD MOVE AROUND PROPERLY
    //private void Update()
    //{
    //    ////temp for testing
    //    //if(Input.GetKeyDown(KeyCode.W))
    //    //{
    //    //    commandSnake.move(false, snake);
    //    //}
    //    //if(Input.GetKeyDown(KeyCode.A))
    //    //{
    //    //    commandSnake.rotate(false, snake);
    //    //}
    //    //if(Input.GetKeyDown(KeyCode.D))
    //    //{
    //    //    commandSnake.rotate(true, snake);
    //    //}
    //}
}
