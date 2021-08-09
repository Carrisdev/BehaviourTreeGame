using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class levelTransition : MonoBehaviour
{
    [SerializeField]
    turtleSpace currentSpace;
    [SerializeField]
    turtleTurtle turtle;
    private void Update()
    {
        if(turtle.getCurrentSpace() == currentSpace)
        {
            if(SceneManager.GetActiveScene() == SceneManager.GetSceneByName("Level 1"))
            {
                SceneManager.LoadScene("Level 2");
            }
            if(SceneManager.GetActiveScene() == SceneManager.GetSceneByName("Level 2"))
            {
                SceneManager.LoadScene("Level 3");
            }
            if(SceneManager.GetActiveScene() == SceneManager.GetSceneByName("Level 3"))
            {
                SceneManager.LoadScene("Title Screen");
            }
        }
    }
}
