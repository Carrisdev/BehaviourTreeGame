using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class titleText : MonoBehaviour
{
    readonly float speed = 3;
    bool movingCamera = false;
    public void buttonManager()
    {
        switch (gameObject.name)
        {
            case "Turtle":
                SceneManager.LoadScene("Level 1");
                break;
            case "Pong":
                SceneManager.LoadScene("Pong");
                break;
            case "Snake":
                SceneManager.LoadScene("Snake");
                break;
            case "Play":
                if(movingCamera)
                {
                    break;
                }
                StartCoroutine(moveGameSelect(movingCamera));
                movingCamera = true;
                break;
            case "Options":
                if (movingCamera)
                {
                    break;
                }
                StartCoroutine(moveOptionSelect(movingCamera));
                movingCamera = true;
                break;
            case "Back":
                if (movingCamera)
                {
                    break;
                }
                StartCoroutine(moveBack1(movingCamera));
                movingCamera = true;
                break;
            case "Back2":
                if (movingCamera)
                {
                    break;
                }
                StartCoroutine(moveBack2(movingCamera));
                movingCamera = true;
                break;
            case "Exit":
                Application.Quit();
                break;
            default:
                Debug.Log("button name not assigned to any command. " + gameObject.name);
                break;
        }
    }
    public IEnumerator moveGameSelect(bool movingCamera)
    {
        float newX = 635;
        while (newX > 323) {
            newX = Camera.main.transform.position.x - speed;
            if (newX < 323)
            {
                newX = 323;
            }
            Camera.main.transform.position = new Vector3(newX, 397, -897.83f);
            if (newX <= 323)
            {
                yield return 0;
            }
            yield return new WaitForSeconds(0.01f);
        }
        movingCamera = false;
    }
    public IEnumerator moveOptionSelect(bool movingCamera)
    {
        float newX = 635;
        while (newX < 945)
        {
            newX = Camera.main.transform.position.x + speed;
            if (newX > 945)
            {
                newX = 945;
            }
            Camera.main.transform.position = new Vector3(newX, 397, -897.83f);
            if (newX >= 945)
            {
                yield return 0;
            }
            yield return new WaitForSeconds(0.01f);
        }
        movingCamera = false;
    }
    public IEnumerator moveBack1(bool movingCamera)
    {
        float newX = 935;
        while (newX > 635)
        {
            newX = Camera.main.transform.position.x - speed;
            if (newX < 635)
            {
                newX = 635;
            }
            Camera.main.transform.position = new Vector3(newX, 397, -897.83f);
            if (newX <= 635)
            {
                yield return 0;
            }
            yield return new WaitForSeconds(0.01f);
        }
        movingCamera = false;
    }
    public IEnumerator moveBack2(bool movingCamera)
    {
        float newX = 323;
        while (newX < 635)
        {
            newX = Camera.main.transform.position.x + speed;
            if (newX > 635)
            {
                newX = 635;
            }
            Camera.main.transform.position = new Vector3(newX, 397, -897.83f);
            if (newX >= 635)
            {
                yield return 0;
            }
            yield return new WaitForSeconds(0.01f);
        }
        movingCamera = false;
    }
}
