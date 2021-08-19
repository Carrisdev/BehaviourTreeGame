using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraGridFollow : MonoBehaviour
{
    [SerializeField]
    Camera masterCamera;

    private void Update()
    {
        transform.position = masterCamera.transform.position;
    }
}
