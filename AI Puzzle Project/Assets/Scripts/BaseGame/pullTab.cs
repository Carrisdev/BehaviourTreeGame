using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class pullTab : MonoBehaviour
{
    [SerializeField]
    GameObject SelectMenu;
    bool pulledOut;
    float speed = 100f;
    public void moveSelectMenu()
    {
        //if the menu hasn't been pulled out yet
        if (!pulledOut)
        {
            //move the button
            gameObject.transform.localScale = new Vector3(0, 0, 0);
            StartCoroutine(pullOut());
            gameObject.GetComponentInChildren<Text>().text = "->";
            pulledOut = true;
        }
        else
        {
            gameObject.transform.localScale = new Vector3(0, 0, 0);
            StartCoroutine(pushIn());
            gameObject.GetComponentInChildren<Text>().text = "<-";
            pulledOut = false;
        }
    }
    public IEnumerator pullOut()
    {
        while (SelectMenu.transform.localPosition.x > 285)
        {
            float newX = SelectMenu.transform.localPosition.x - speed;
            //if it reached the end position, set the position to the end position
            if (newX < 285)
            {
                newX = 285;
            }
            //slowly move the node into place
            SelectMenu.transform.localPosition = new Vector3(newX, SelectMenu.transform.localPosition.y, SelectMenu.transform.localPosition.z);
            yield return new WaitForSeconds(0.01f);
        }
        //move the button into its new place
        gameObject.transform.localPosition = new Vector3(160, transform.localPosition.y, transform.localPosition.z);
        //show the button again
        gameObject.transform.localScale = new Vector3(1, 1, 1);
        yield return 0;
    }
    public IEnumerator pushIn()
    {
        while (SelectMenu.transform.localPosition.x < 520)
        {
            float newX = SelectMenu.transform.localPosition.x + speed;
            //if it reached the end position, set the position to the end position
            if (newX > 520)
            {
                newX = 520;
            }
            //slowly move the node into place
            SelectMenu.transform.localPosition = new Vector3(newX, SelectMenu.transform.localPosition.y, SelectMenu.transform.localPosition.z);
            yield return new WaitForSeconds(0.01f);
        }
        //move the button into its new place
        gameObject.transform.localPosition = new Vector3(373, transform.localPosition.y, transform.localPosition.z);
        //slow the button again
        gameObject.transform.localScale = new Vector3(1, 1, 1);
        yield return 0;
    }
}
