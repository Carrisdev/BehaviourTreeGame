using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraButton : MonoBehaviour
{
    bool firstPress = false;
    bool gridActive = true;
    [SerializeField]
    Camera game;
    [SerializeField]
    Camera grid;
    private void Start()
    {
        grid.enabled = true;
        game.enabled = false;
    }
    public void cameraSwitch()
    {
        if(firstPress)
        {
            firstPress = false;
            StopAllCoroutines();
            //switch active camera
            if(gridActive)
            {
                gridActive = false;
                game.enabled = true;
                grid.enabled = false;
            }
            else
            {
                gridActive = true;
                grid.enabled = true;
                game.enabled = false;
            }
        }
        else
        {
            StartCoroutine(waitForSecondPress());
        }
    }
    //double clicks are only valid if they happen within a second of eachother
    IEnumerator waitForSecondPress()
    {
        firstPress = true;
        yield return new WaitForSeconds(1);
        firstPress = false;
        yield return 0;
    }
}
