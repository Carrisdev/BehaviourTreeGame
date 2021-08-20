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
        LevelOpener.gameObject.SetActive(true);
        FindObjectOfType<soundManager>().playClip("levelPassed");
        yield return StartCoroutine(LevelOpener.endLevel());
        SceneManager.LoadScene(levelName);
    }
}
