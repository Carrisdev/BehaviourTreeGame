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
        if (!pulledOut)
        {
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
            if (newX < 285)
            {
                newX = 285;
            }
            SelectMenu.transform.localPosition = new Vector3(newX, SelectMenu.transform.localPosition.y, SelectMenu.transform.localPosition.z);
            yield return new WaitForSeconds(0.01f);
        }
        gameObject.transform.localPosition = new Vector3(160, transform.localPosition.y, transform.localPosition.z);
        gameObject.transform.localScale = new Vector3(1, 1, 1);
        yield return 0;
    }
    public IEnumerator pushIn()
    {
        while (SelectMenu.transform.localPosition.x < 520)
        {
            float newX = SelectMenu.transform.localPosition.x + speed;
            if (newX > 520)
            {
                newX = 520;
            }
            SelectMenu.transform.localPosition = new Vector3(newX, SelectMenu.transform.localPosition.y, SelectMenu.transform.localPosition.z);
            yield return new WaitForSeconds(0.01f);
        }
        gameObject.transform.localPosition = new Vector3(373, transform.localPosition.y, transform.localPosition.z);
        gameObject.transform.localScale = new Vector3(1, 1, 1);
        yield return 0;
    }
}
