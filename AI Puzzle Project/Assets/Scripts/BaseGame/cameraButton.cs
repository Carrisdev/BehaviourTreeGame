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
            //switch camera
            Debug.Log("second click");
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
    IEnumerator waitForSecondPress()
    {
        firstPress = true;
        yield return new WaitForSeconds(1);
        firstPress = false;
        yield return 0;
    }
}
