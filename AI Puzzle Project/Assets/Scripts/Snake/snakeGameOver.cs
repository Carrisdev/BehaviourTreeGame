using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class snakeGameOver : MonoBehaviour
{
    //hide the gameover text when i press the end button
    public void hideText()
    {
        gameObject.SetActive(false);
    }
}
