using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIPaddle : MonoBehaviour
{
    //set the speed as double the humans
    //this is to compensate for having to wait a frame after reading every single node
    float speed = 0.1f;
    public void moveUp()
    {
        transform.position = new Vector3(transform.position.x, transform.position.y + speed);
        if (transform.position.y > 4.15f)
        {
            transform.position = new Vector3(transform.position.x, 4.15f);
        }
    }
    public void moveDown()
    {
        transform.position = new Vector3(transform.position.x, transform.position.y - speed);
        if (transform.position.y < -4.15f)
        {
            transform.position = new Vector3(transform.position.x, -4.15f);
        }
    }
}
