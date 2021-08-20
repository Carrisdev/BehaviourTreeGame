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

    private void OnMouseOver()
    {
        //if the player is hovering over the button and holding shift, show the assigned help text
        if(Input.GetKey(KeyCode.LeftShift) && transform.position.y > -1.6f)
        {
            gameObject.GetComponent<buttonHelpHover>().show();
        }
        else
        {
            gameObject.GetComponent<buttonHelpHover>().hide();
        }
    }

    private void OnMouseEnter()
    {
        hovered = true;
    }

    private void OnMouseExit()
    {
        hovered = false;
        gameObject.GetComponent<buttonHelpHover>().hide();
    }

    private void OnMouseDown()
    {
        //if the object is pressed, create a new node
        if (hovered && transform.position.y > -1.6f)
        {
            GameObject newBox = Instantiate(textObject);
            newBox.transform.parent = baseGrid.transform;
        }
    }
}