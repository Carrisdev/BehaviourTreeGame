using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class buttonHelpHover : MonoBehaviour
{
    [SerializeField]
    GameObject helpText;

    public void show()
    {
        helpText.SetActive(true);
    }

    public void hide()
    {
        helpText.SetActive(false);
    }
}
