using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class baseButton : MonoBehaviour
{
    bool hovered;
    bool selected;
    [SerializeField]
    GameObject textObject;
    GameObject baseGrid;
    private void Start()
    {
        baseGrid = GameObject.Find("Grid");
    }

    private void OnMouseEnter()
    {
        hovered = true;
    }

    private void OnMouseExit()
    {
        hovered = false;
    }

    private void OnMouseDown()
    {
        if (hovered)
        {
            GameObject newBox = Instantiate(textObject);
            newBox.transform.parent = baseGrid.transform;
        }
    }
}