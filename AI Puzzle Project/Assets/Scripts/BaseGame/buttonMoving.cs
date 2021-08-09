using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class buttonMoving : MonoBehaviour
{
    bool set;
    GameObject camera;
    float[] xPositions = {-27.06f, -26.61f, -26.16f, -25.71f, -25.26f, -24.81f, -24.36f, -23.91f, -23.46f, -23.01f, -22.56f, -22.11f, -21.66f};
    float[] yPositions = { -11.725f, -12.175f, -12.625f, -13.075f, -13.525f, -13.975f, -14.425f, -14.875f, 
    -15.325f, -15.775f, -16.225f, -16.675f, -17.125f, -17.575f, -18.025f, -18.475f, -18.925f, -19.375f, -19.825f, -20.275f, -20.725f, -21.175f};
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
            for (int i = 0; i < xPositions.Length; i++)
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
