using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraGridFollow : MonoBehaviour
{
    [SerializeField]
    Camera masterCamera;

    private void Update()
    {
        //follow the master camera at a slight x position movement, so that the start button is lined up in the game's window
        transform.position = new Vector3(masterCamera.transform.position.x + 0.5f, masterCamera.transform.position.y, masterCamera.transform.position.z);
    }
}
