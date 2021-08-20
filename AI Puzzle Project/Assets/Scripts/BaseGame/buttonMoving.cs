using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class buttonMoving : MonoBehaviour
{
    bool set;
    GameObject camera;
    //all the possible X positions and Y positions. While this may seem impractical, all of this is hard coded in the scene
    //so there's no reason to spend time making a script to systematically do this
    float[] xPositions = {-7.2f, -6.75f, -6.3f, -5.85f, -5.4f, -4.95f, -4.5f, -4.05f, -3.6f, -3.15f, -2.7f,
    -2.25f, -1.8f, -1.35f, -0.9f, -0.45f, 0f, 0.45f, 0.9f, 1.35f, 1.8f, 2.25f, 2.7f, 3.15f, 3.6f, 4.05f, 4.5f,
    4.95f, 5.4f, 5.85f, 6.3f, 6.75f, 7.2f};
    float[] yPositions = {7.4f, 6.95f, 6.5f, 6.05f, 5.6f, 5.15f, 4.7f, 4.25f, 3.8f, 3.35f, 2.9f, 2.45f,
    2f, 1.55f, 1.1f, 0.65f, 0.2f, -0.25f, -0.7f, -1.15f, -1.6f, -2.05f, -2.5f, -2.95f, -3.4f, -3.85f, -4.3f,
    -4.75f, -5.2f, -5.65f, -6.1f, -6.55f, -7f, -7.45f, -7.9f};
    private void Start()
    {
        //when a button is created, put it in front of the background
        set = false;
        camera = GameObject.Find("Grid Camera");
        gameObject.GetComponent<Renderer>().sortingOrder = 1;
    }
    private void Update()
    {
        //if the button isn't set
        if(!set)
        {
            //if the button can't find a valid position to move to, shove it well away from the rest of the grid
            Vector2 newPosition = new Vector2(-20f, -11.5f);
            //move to the mouse position
            transform.position = camera.GetComponent<Camera>().ScreenToWorldPoint(Input.mousePosition);
            //if there's a valid x position close enough to it, set the new position x to that
            for (int i = 0; i < xPositions.Length; i++)
            {
                if(Mathf.Abs(transform.localPosition.x - xPositions[i]) < 0.225)
                {
                    newPosition.x = xPositions[i];
                    break;
                }
            }
            //if there's a valid y position close enough to it, set the new position y to that
            for(int i = 0; i < yPositions.Length; i++)
            {
                if(Mathf.Abs((transform.localPosition.y - 0.225f) - yPositions[i]) < 0.225)
                {
                    newPosition.y = yPositions[i];
                    break;
                }
            }
            //move to the new x and y position. if there wasn't been a valid position chosen, it will just move well away from the grid
            transform.localPosition = new Vector3(newPosition.x, newPosition.y, 1);
        }
        //if the player releases the mouse, stop moving the node
        if(Input.GetMouseButtonUp(0))
        {
            StopAllCoroutines();
            set = true;
        }
    }
    //move the node if it's left clicked
    private void OnMouseDown()
    {
        //this small delay will help stop moving nodes when a player accidentally or purposefully clicks the mouse, but doesn't drag
        //if the player quickly taps the mouse, it doesn't move the node
        //it adds a slight hiccup to the game, but it's not that noticable
        StartCoroutine(slightDelay());
    }
    //delete the node if it's right clicked
    private void OnMouseOver()
    {
        if(Input.GetMouseButtonDown(1))
        {
            Destroy(gameObject);
        }
    }
    //add a small delay to stop clicks from causing the node to move
    IEnumerator slightDelay()
    {
        yield return new WaitForSeconds(0.1f);
        set = false;
    }
}
