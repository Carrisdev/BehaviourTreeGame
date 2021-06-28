using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class treeReader : MonoBehaviour
{
    GameObject parentGrid;
    private void Start()
    {
        parentGrid = GameObject.Find("Grid");
    }
    int[] readTree(int[] currentArray)
    {
        Transform nextStep = transform.Find("nextStep");
        Transform[] objects = parentGrid.GetComponentsInChildren<Transform>();
        GameObject nextPiece = null;
        for(int i = 0; i < objects.Length; i++)
        {
            if (Mathf.Abs(transform.position.x - objects[i].position.x) < 0.225 && 
            Mathf.Abs(transform.position.y - objects[i].position.y) < 0.225)
            {
                nextPiece = objects[i].gameObject;
            }
        }
        if(nextPiece == null)
        {
            return currentArray;
        }


        return currentArray;
    }
}
