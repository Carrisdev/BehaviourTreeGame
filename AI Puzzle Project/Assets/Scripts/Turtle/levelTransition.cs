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
    private void Update()
    {
        if(turtle.getCurrentSpace() == currentSpace)
        {
            if(SceneManager.GetActiveScene() == SceneManager.GetSceneByName("Level 1"))
            {
                StartCoroutine(transitionLevel("Level 2"));
            }
            if(SceneManager.GetActiveScene() == SceneManager.GetSceneByName("Level 2"))
            {
                StartCoroutine(transitionLevel("Level 3"));
            }
            if(SceneManager.GetActiveScene() == SceneManager.GetSceneByName("Level 3"))
            {
                StartCoroutine(transitionLevel("Title Screen"));
            }
        }
    }
    IEnumerator transitionLevel(string levelName)
    {
        LevelOpener.gameObject.SetActive(true);
        yield return StartCoroutine(LevelOpener.endLevel());
        SceneManager.LoadScene(levelName);
    }
}
