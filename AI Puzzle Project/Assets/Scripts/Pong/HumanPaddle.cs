using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HumanPaddle : MonoBehaviour
{
    float speed = 0.1f;
    private void Update()
    {
        if (Input.GetKey(KeyCode.W)) {
            transform.position = new Vector3(transform.position.x, transform.position.y + speed);
        }
        if (Input.GetKey(KeyCode.S))
        {
            transform.position = new Vector3(transform.position.x, transform.position.y - speed);
        }
    }
}
