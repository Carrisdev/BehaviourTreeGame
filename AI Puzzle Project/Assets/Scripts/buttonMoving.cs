using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class buttonMoving : MonoBehaviour
{
    bool set;
    GameObject camera;
    float[] xPositions = { -2.3f, -2.75f, -3.2f, -3.65f, -4.1f, -4.55f, -5f, -5.45f, -5.9f, -6.35f, -6.8f, -7.25f, -7.7f};
    float[] yPositions = { -11.5f, -11.95f, -12.4f, -12.85f, -13.3f, -13.75f, -14.2f, -14.65f, 
    -15.1f, -15.55f, -16f, -16.45f, -16.9f, -17.35f, -17.8f, -18.25f, -18.7f, -19.15f, -19.6f, -20.05f, -20.5f, -20.95f};
    private void Start()
    {
        set = false;
        camera = GameObject.Find("Grid Camera");
        gameObject.GetComponent<Renderer>().sortingOrder = 1;
    }
    private void Update()
    {
        if(!set)
        {
            Vector2 newPosition = new Vector2(-2.3f, -11.5f);
            transform.position = camera.GetComponent<Camera>().ScreenToWorldPoint(Input.mousePosition);
            for(int i = 0; i < xPositions.Length; i++)
            {
                if(Mathf.Abs(transform.position.x - xPositions[i]) < 0.225)
                {
                    newPosition.x = xPositions[i];
                    break;
                }
            }
            for(int i = 0; i < yPositions.Length; i++)
            {
                if(Mathf.Abs(transform.position.y - yPositions[i]) < 0.225)
                {
                    newPosition.y = yPositions[i];
                    break;
                }
            }
            transform.position = new Vector3(newPosition.x, newPosition.y, 1);
        }
        if(Input.GetMouseButtonUp(0))
        {
            set = true;
        }
    }
    private void OnMouseDown()
    {
        set = false;
    }

}
