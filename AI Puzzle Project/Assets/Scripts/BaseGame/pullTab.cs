using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pullTab : MonoBehaviour
{
    [SerializeField]
    GameObject SelectMenu;
    bool pulledOut;
    float speed = 0.2f;
    public void moveSelectMenu()
    {
        if (!pulledOut)
        {
            gameObject.transform.localScale = new Vector3(0, 0, 0);
            StartCoroutine(pullOut());
            pulledOut = true;
        }
        else
        {
            gameObject.transform.localScale = new Vector3(0, 0, 0);
            StartCoroutine(pushIn());
            pulledOut = false;
        }
    }
    public IEnumerator pullOut()
    {
        while (SelectMenu.transform.position.x > -21.79f)
        {
            float newX = SelectMenu.transform.position.x - speed;
            if (newX < -21.79f)
            {
                newX = -21.79f;
            }
            SelectMenu.transform.position = new Vector3(newX, SelectMenu.transform.position.y, SelectMenu.transform.position.z);
            yield return new WaitForSeconds(0.01f);
        }
        gameObject.transform.position = new Vector3(-23, -11.5f, 0);
        gameObject.transform.localScale = new Vector3(1, 1, 1);
        yield return 0;
    }
    public IEnumerator pushIn()
    {
        while (SelectMenu.transform.position.x < -20f)
        {
            float newX = SelectMenu.transform.position.x + speed;
            if (newX > -20f)
            {
                newX = -20f;
            }
            SelectMenu.transform.position = new Vector3(newX, SelectMenu.transform.position.y, SelectMenu.transform.position.z);
            yield return new WaitForSeconds(0.01f);
        }
        gameObject.transform.position = new Vector3(-21.21f, -11.5f, 0);
        gameObject.transform.localScale = new Vector3(1, 1, 1);
        yield return 0;
    }
}
