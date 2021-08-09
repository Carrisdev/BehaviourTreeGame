using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraGridMove : MonoBehaviour
{
    private void Update()
    {
        float newY = transform.position.y + (Input.mouseScrollDelta.y * 0.8f);
        if(newY > -13.39f)
        {
            newY = -13.39f;
        } else if(newY < -19.08f)
        {
            newY = -19.08f;
        }
        transform.position = new Vector3(transform.position.x, newY, transform.position.z);
    }
}
