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
        //toggle the pause menu when escape is pressed
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
            //if the player presses on resume, close the pause menu
            if(Input.mousePosition.x > Screen.width * 0.29f && Input.mousePosition.x < Screen.width * 0.7f &&
            Input.mousePosition.y > Screen.height * 0.465f && Input.mousePosition.y < Screen.height * 0.586f)
            {
                if(Input.GetMouseButtonDown(0))
                {
                    closePause();
                }
            }
            //if the player presses on exit, return to the title screen
            if (Input.mousePosition.x > Screen.width * 0.36f && Input.mousePosition.x < Screen.width * 0.64f &&
            Input.mousePosition.y > Screen.height * 0.28f && Input.mousePosition.y < Screen.height * 0.38f)
            {
                if (Input.GetMouseButtonDown(0))
                {
                    //this is mainly to make sure the timescale is set back to 1
                    closePause();
                    SceneManager.LoadScene("Title Screen");
                }
            }
        }
    }
    void openPause()
    {
        //scale the pause menu up to where they need to be
        background1.transform.localScale = new Vector3(6, 5.1f, 1);
        background2.transform.localScale = new Vector3(2.3f, 2, 1);
        for (int i = 0; i < disabledObjects.Length; i++)
        {
            disabledObjects[i].SetActive(false);
        }
        //used for pong mainly since velocity moves the ball
        Time.timeScale = 0f;
        tree.paused = true;
        paused = true;
    }

    void closePause()
    {
        //hide the pause menu
        background1.transform.localScale = new Vector3(0, 0, 0);
        background2.transform.localScale = new Vector3(0, 0, 0);
        for(int i = 0; i < disabledObjects.Length; i++)
        {
            disabledObjects[i].SetActive(true);
        }
        //reset the time
        Time.timeScale = 1.0f;
        tree.paused = false;
        paused = false;
    }
}
