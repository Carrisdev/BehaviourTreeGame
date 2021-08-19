using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class turtleLevelOpener : MonoBehaviour
{
    [SerializeField]
    GameObject[] disabledObjects;
    [SerializeField]
    Sprite closerSprite;
    // Start is called before the first frame update
    void Start()
    {
        transform.position = Camera.main.transform.position;
        transform.position = new Vector3(transform.position.x, transform.position.y, 0);
        transform.localScale = new Vector3(0, 0, 0);
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

        bool clicked = false;
        while (!clicked)
        {
            if (Input.anyKey || Input.GetMouseButton(0))
            {
                clicked = true;
            }
            yield return new WaitForEndOfFrame();
        }

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
        for (int i = 0; i < disabledObjects.Length; i++)
        {
            disabledObjects[i].SetActive(true);
        }
        gameObject.SetActive(false);
    }
    public IEnumerator endLevel()
    {
        gameObject.GetComponent<SpriteRenderer>().sprite = closerSprite;
        transform.localScale = new Vector3(0, 0, 0);
        transform.position = Camera.main.transform.position;
        transform.position = new Vector3(transform.position.x, transform.position.y, 0);
        for (int i = 0; i < disabledObjects.Length; i++)
        {
            disabledObjects[i].SetActive(false);
        }
        float scale = 0.0f;
        float finalScale = 0.0f;
        float speed = 0.0f;
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

        bool clicked = false;
        while (!clicked)
        {
            if (Input.anyKey || Input.GetMouseButton(0))
            {
                clicked = true;
            }
            yield return new WaitForEndOfFrame();
        }

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
        for (int i = 0; i < disabledObjects.Length; i++)
        {
            disabledObjects[i].SetActive(true);
        }
    }
}
