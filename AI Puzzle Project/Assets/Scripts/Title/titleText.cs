using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class titleText : MonoBehaviour
{
    public void buttonManager()
    {
        //check which button is being pressed. Depending on that, either move the camera, load a different scene, or leave the game
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
                Camera.main.transform.position = new Vector3(323, Camera.main.transform.position.y, Camera.main.transform.position.z);
                break;
            case "Options":
                Camera.main.transform.position = new Vector3(945, Camera.main.transform.position.y, Camera.main.transform.position.z);
                break;
            case "Credits":
                Camera.main.transform.position = new Vector3(Camera.main.transform.position.x, 178, Camera.main.transform.position.z);
                break;
            case "Back":
                Camera.main.transform.position = new Vector3(635, Camera.main.transform.position.y, Camera.main.transform.position.z);
                break;
            case "Back2":
                Camera.main.transform.position = new Vector3(635, Camera.main.transform.position.y, Camera.main.transform.position.z);
                break;
            case "Back3":
                Camera.main.transform.position = new Vector3(Camera.main.transform.position.x, 397, Camera.main.transform.position.z);
                break;
            case "Exit":
                Application.Quit();
                break;
                //if i accidentally add a button that's not assigned, just throw an error.
            default:
                Debug.Log("button name not assigned to any command. " + gameObject.name);
                break;
        }
    }
    //i tried to make the camera scroll to the other options, but when i reloaded the scene after
    //exiting a level it would just break. i don't know why and I don't have the patience to fix it
    //public IEnumerator moveGameSelect(bool movingCamera)
    //{
    //    float newX = 635;
    //    while (newX > 323) {
    //        newX = Camera.main.transform.position.x - speed;
    //        if (newX < 323)
    //        {
    //            newX = 323;
    //        }
    //        Camera.main.transform.position = new Vector3(newX, 397, -897.83f);
    //        if (newX <= 323)
    //        {
    //            yield return 0;
    //        }
    //        yield return new WaitForSeconds(0.01f);
    //    }
    //}
    //public IEnumerator moveOptionSelect(bool movingCamera)
    //{
    //    float newX = 635;
    //    while (newX < 945)
    //    {
    //        newX = Camera.main.transform.position.x + speed;
    //        if (newX > 945)
    //        {
    //            newX = 945;
    //        }
    //        Camera.main.transform.position = new Vector3(newX, 397, -897.83f);
    //        if (newX >= 945)
    //        {
    //            yield return 0;
    //        }
    //        yield return new WaitForSeconds(0.01f);
    //    }
    //}
    //public IEnumerator moveCredits(bool movingCamera)
    //{
    //    float newY = 397;
    //    while (newY > 178)
    //    {
    //        newY = Camera.main.transform.position.y - speed;
    //        if (newY < 178)
    //        {
    //            newY = 178;
    //        }
    //        Camera.main.transform.position = new Vector3(635, newY, -897.83f);
    //        if (newY >= 178)
    //        {
    //            yield return 0;
    //        }
    //        yield return new WaitForSeconds(0.01f);
    //    }
    //}
    //public IEnumerator moveBack1(bool movingCamera)
    //{
    //    float newX = 935;
    //    while (newX > 635)
    //    {
    //        newX = Camera.main.transform.position.x - speed;
    //        if (newX < 635)
    //        {
    //            newX = 635;
    //        }
    //        Camera.main.transform.position = new Vector3(newX, 397, -897.83f);
    //        if (newX <= 635)
    //        {
    //            yield return 0;
    //        }
    //        yield return new WaitForSeconds(0.01f);
    //    }
    //}
    //public IEnumerator moveBack2(bool movingCamera)
    //{
    //    float newX = 323;
    //    while (newX < 635)
    //    {
    //        newX = Camera.main.transform.position.x + speed;
    //        if (newX > 635)
    //        {
    //            newX = 635;
    //        }
    //        Camera.main.transform.position = new Vector3(newX, 397, -897.83f);
    //        if (newX >= 635)
    //        {
    //            yield return 0;
    //        }
    //        yield return new WaitForSeconds(0.01f);
    //    }
    //}
    //public IEnumerator moveBack3(bool movingCamera)
    //{
    //    float newY = 178;
    //    while (newY < 397)
    //    {
    //        newY = Camera.main.transform.position.y + speed;
    //        if (newY > 397)
    //        {
    //            newY = 397;
    //        }
    //        Camera.main.transform.position = new Vector3(635, newY, -897.83f);
    //        if (newY >= 397)
    //        {
    //            yield return 0;
    //        }
    //        yield return new WaitForSeconds(0.01f);
    //    }
    //}
}
