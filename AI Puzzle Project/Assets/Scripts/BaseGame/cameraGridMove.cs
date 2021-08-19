using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraGridMove : MonoBehaviour
{
    [SerializeField]
    GameObject scrollMarker;
    [SerializeField]
    GameObject pullTab;
    [SerializeField]
    GameObject grid;
    [SerializeField]
    float maxPullTab;
    float oldX = -1f,
        oldY = -1f,
        newX = -1f,
        newY = -1f,
        mouseOldX = -1f,
        mouseOldY = -1f,
        mouseNewX = -1f,
        mouseNewY = -1f,
        scrollY;
    private void Update()
    {
        //only do all this if the grid camera is active
        if(Camera.main.name != "Grid Camera")
        {
            return;
        }

        //if the node select menu is pulled out
        if (pullTab.transform.localPosition.x < 350)
        {
            //if the mouse is within the bounds of the node select menu
            if (Input.mousePosition.x > 1023 && Input.mousePosition.y > 400)
            {
                scrollY = scrollMarker.transform.localPosition.y + (Input.mouseScrollDelta.y * -0.4f);
                if(scrollY < 0)
                {
                    scrollY = 0;
                }
                if(scrollY > maxPullTab)
                {
                    scrollY = maxPullTab;
                }
                scrollMarker.transform.localPosition = new Vector3(scrollMarker.transform.localPosition.x, scrollY, scrollMarker.transform.localPosition.z);
                return;
            }
        }
        //on the frame the user right clicks, store the old position for the mouse and the grid
        if(Input.GetMouseButtonDown(1))
        {
            //set all our start positions
            oldX = grid.transform.position.x;
            oldY = grid.transform.position.y;
            mouseOldX = Camera.main.ScreenToWorldPoint(Input.mousePosition).x;
            mouseOldY = Camera.main.ScreenToWorldPoint(Input.mousePosition).y;
            //we don't want to move the grid on the first frame, just incase
            return;
        }
        //on the frame the user lets go of right click, set all the positions back to null
        if (Input.GetMouseButtonUp(1))
        {
            oldX = -1f;
            oldY = -1f;
            mouseOldX = -1f;
            mouseOldY = -1f;
            //now that the position is set back to a neutral state, we don't want to move anything anymore
            return;
        }
        if(Input.GetMouseButton(1))
        {
            mouseNewX = Camera.main.ScreenToWorldPoint(Input.mousePosition).x;
            mouseNewY = Camera.main.ScreenToWorldPoint(Input.mousePosition).y;
            float differenceX = mouseNewX - mouseOldX;
            float differenceY = mouseNewY - mouseOldY;
            newX = oldX + differenceX;
            newY = oldY + differenceY;
            //side barriers that can be changed easily if needed
            if(newX < -28.41f)
            {
                newX = -28.41f;
            }
            if(newX > -20.3f)
            {
                newX = -20.3f;
            }
            if(newY > 4.75f)
            {
                newY = 4.75f;
            }
            if(newY < -7.18f)
            {
                newY = -7.18f;
            }
            grid.transform.position = new Vector3(newX, newY, 0);
        }
    }
}
