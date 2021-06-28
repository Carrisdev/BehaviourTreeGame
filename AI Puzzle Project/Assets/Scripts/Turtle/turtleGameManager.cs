using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class turtleGameManager : MonoBehaviour
{
    //can be hardcoded for now
    //IF I ADD A LEVEL EDITOR THIS HAS TO CHANCE
    [SerializeField]
    turtleTurtle turtle;
    [SerializeField]
    turtleCommandList commandTurtle;
    private void Update()
    {
        //THIS IS SOLELY FOR TESTING PURPOSES
        //THIS IS CLUNKY BUT FUCK IT ITS JUST FOR TESTING
        if (Input.GetKeyDown(KeyCode.W) && !Input.GetKey(KeyCode.LeftShift))
        {
            commandTurtle.move(false, turtle);
        }
        if (Input.GetKeyDown(KeyCode.W) && Input.GetKey(KeyCode.LeftShift))
        {
            commandTurtle.move(true, turtle);
        }
        if (Input.GetKeyDown(KeyCode.A))
        {
            commandTurtle.rotate(true, turtle);
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            commandTurtle.rotate(false, turtle);
        }
    }
}
