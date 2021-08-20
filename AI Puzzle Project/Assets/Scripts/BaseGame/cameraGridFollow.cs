using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraGridFollow : MonoBehaviour
{
    [SerializeField]
    Camera masterCamera;

    private void Update()
    {
        transform.position = new Vector3(masterCamera.transform.position.x + 0.5f, masterCamera.transform.position.y, masterCamera.transform.position.z);
    }
}
