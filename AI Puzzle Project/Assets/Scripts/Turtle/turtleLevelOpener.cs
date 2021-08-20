using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class turtleLevelOpener : MonoBehaviour
{
    [SerializeField]
    GameObject[] disabledObjects;
    [SerializeField]
    Sprite closerSprite;
    void Start()
    {
        //change the position to the active camera
        transform.position = Camera.main.transform.position;
        transform.position = new Vector3(transform.position.x, transform.position.y, 0);
        transform.localScale = new Vector3(0, 0, 0);
        //disable all the objects that could get in the way of the text
        for(int i = 0; i < disabledObjects.Length; i++)
        {
            disabledObjects[i].SetActive(false);
        }
        StartCoroutine(levelOpener());
    }

    IEnumerator levelOpener()
    {
        float scale = 0.0f;
        float finalScale = 0.0f;
        float speed = 0.0f;
        //change what scale we need to hit dependant on what camera it is
        if(Camera.main.name == "Grid Camera")
        {
            finalScale = 0.16f;
            speed = 0.005f;
        }
        else
        {
            finalScale = 0.5f;
            speed = 0.015652f;
        }

        //slowly scale up until the scale hits finalScale
        while (scale != finalScale)
        {
            scale += speed;
            if(scale > finalScale)
            {
                scale = finalScale;
            }
            transform.localScale = new Vector3(scale, scale, scale);
            yield return new WaitForSeconds(0.01f);
        }

        //wait for the player to click a button
        bool clicked = false;
        while (!clicked)
        {
            if (Input.anyKey || Input.GetMouseButton(0))
            {
                clicked = true;
            }
            yield return new WaitForEndOfFrame();
        }

        //scale down until the object is invisible
        while (scale != 0.0f)
        {
            scale -= speed;
            if (scale < 0.0f)
            {
                scale = 0.0f;
            }
            transform.localScale = new Vector3(scale, scale, scale);
            yield return new WaitForSeconds(0.01f);
        }
        //reenable everything we hid at the start
        for (int i = 0; i < disabledObjects.Length; i++)
        {
            disabledObjects[i].SetActive(true);
        }
        gameObject.SetActive(false);
    }
    public IEnumerator endLevel()
    {
        //change the sprite to the closer one
        gameObject.GetComponent<SpriteRenderer>().sprite = closerSprite;
        //rescale and reposition the object, just in case
        transform.localScale = new Vector3(0, 0, 0);
        transform.position = Camera.main.transform.position;
        transform.position = new Vector3(transform.position.x, transform.position.y, 0);
        //disable anything that would get in the way
        for (int i = 0; i < disabledObjects.Length; i++)
        {
            disabledObjects[i].SetActive(false);
        }
        float scale = 0.0f;
        float finalScale = 0.0f;
        float speed = 0.0f;
        //set the final scale dependant on what camera it is in front of
        if (Camera.main.name == "Grid Camera")
        {
            finalScale = 0.16f;
            speed = 0.005f;
        }
        else
        {
            finalScale = 0.5f;
            speed = 0.015652f;
        }

        //scale up until the scale is the same as finalScale
        while (scale != finalScale)
        {
            scale += speed;
            if (scale > finalScale)
            {
                scale = finalScale;
            }
            transform.localScale = new Vector3(scale, scale, scale);
            yield return new WaitForSeconds(0.01f);
        }

        //wait for the player to press something
        bool clicked = false;
        while (!clicked)
        {
            if (Input.anyKey || Input.GetMouseButton(0))
            {
                clicked = true;
            }
            yield return new WaitForEndOfFrame();
        }

        //scale down until invisible
        while (scale != 0.0f)
        {
            scale -= speed;
            if (scale < 0.0f)
            {
                scale = 0.0f;
            }
            transform.localScale = new Vector3(scale, scale, scale);
            yield return new WaitForSeconds(0.01f);
        }
        //reenable everything we hid. the scene will change after this, but just in case
        for (int i = 0; i < disabledObjects.Length; i++)
        {
            disabledObjects[i].SetActive(true);
        }
    }
}
