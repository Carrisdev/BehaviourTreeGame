using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraButton : MonoBehaviour
{
    bool firstPress = false;
    // Start is called before the first frame update
    public void cameraSwitch()
    {
        if(firstPress)
        {
            //switch camera
            Debug.Log("second click");
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
