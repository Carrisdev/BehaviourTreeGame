using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class escapeMenu : MonoBehaviour
{
    [SerializeField]
    GameObject[] disabledObjects;
    [SerializeField]
    treeTranslation tree;
    bool paused = false;
    [SerializeField]
    GameObject background1;
    [SerializeField]
    GameObject background2;

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            if(paused)
            {
                closePause();
            }
            else
            {
                openPause();
            }
        }
        if(paused)
        {
            //within resume menu
            if(Input.mousePosition.x > 444 && Input.mousePosition.x < 948 &&
            Input.mousePosition.y > 384 && Input.mousePosition.y < 477)
            {
                if(Input.GetMouseButtonDown(0))
                {
                    closePause();
                }
            }
            //within exit menu
            if (Input.mousePosition.x > 530 && Input.mousePosition.x < 871 &&
            Input.mousePosition.y > 222 && Input.mousePosition.y < 304)
            {
                if (Input.GetMouseButtonDown(0))
                {
                    SceneManager.LoadScene("Title Screen");
                }
            }
        }
    }
    void openPause()
    {
        background1.transform.localScale = new Vector3(6, 5.1f, 1);
        background2.transform.localScale = new Vector3(2.3f, 2, 1);
        for (int i = 0; i < disabledObjects.Length; i++)
        {
            disabledObjects[i].SetActive(false);
        }
        //used for pong since velocity moves the ball
        Time.timeScale = 0f;
        tree.paused = true;
        paused = true;
    }

    void closePause()
    {
        background1.transform.localScale = new Vector3(0, 0, 0);
        background2.transform.localScale = new Vector3(0, 0, 0);
        for(int i = 0; i < disabledObjects.Length; i++)
        {
            disabledObjects[i].SetActive(true);
        }
        Time.timeScale = 1.0f;
        tree.paused = false;
        paused = false;
    }
}
