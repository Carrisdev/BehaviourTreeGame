using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HumanPaddle : MonoBehaviour
{
    float speed = 0.1f;
    public bool started = false;
    private void Update()
    {
        if(!started)
        {
            return;
        }
        //move the paddle up with W and the paddle down with S
        if (Input.GetKey(KeyCode.W)) {
            transform.position = new Vector3(transform.position.x, transform.position.y + speed);
            if (transform.position.y > 4.15f)
            {
                transform.position = new Vector3(transform.position.x, 4.15f);
            }
        }
        if (Input.GetKey(KeyCode.S))
        {
            transform.position = new Vector3(transform.position.x, transform.position.y - speed);
            if (transform.position.y < -4.15f)
            {
                transform.position = new Vector3(transform.position.x, -4.15f);
            }
        }
    }
}
