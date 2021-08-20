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
    [SerializeField]
    turtleLevelOpener LevelOpener;
    bool transitioning = false;
    private void Update()
    {
        //if the turtle is standing on the right space and the level isn't already transitioning
        //start transitioning the scene to the next one
        if(turtle.getCurrentSpace() == currentSpace && !transitioning)
        {
            if(SceneManager.GetActiveScene() == SceneManager.GetSceneByName("Level 1"))
            {
                StartCoroutine(transitionLevel("Level 2"));
                transitioning = true;
            }
            if(SceneManager.GetActiveScene() == SceneManager.GetSceneByName("Level 2"))
            {
                StartCoroutine(transitionLevel("Level 3"));
                transitioning = true;
            }
            if(SceneManager.GetActiveScene() == SceneManager.GetSceneByName("Level 3"))
            {
                StartCoroutine(transitionLevel("Title Screen"));
                transitioning = true;
            }
        }
    }
    IEnumerator transitionLevel(string levelName)
    {
        //show the level opener, then wait for the player to close it, then load the next scene
        LevelOpener.gameObject.SetActive(true);
        FindObjectOfType<soundManager>().playClip("levelPassed");
        yield return StartCoroutine(LevelOpener.endLevel());
        SceneManager.LoadScene(levelName);
    }
}
