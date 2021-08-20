using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class inputBoundaries : MonoBehaviour
{
    [SerializeField]
    int min;
    [SerializeField]
    int max;
    InputField input;

    private void Start()
    {
        input = gameObject.GetComponent<InputField>();
    }

    public void checkBoundaries()
    {
        //if the player removes all the text, just return
        if(input.text == "")
        {
            return;
        }
        //if the user inputs a value higher than the max, set the user generated value to the max
        if (int.Parse(input.text) > max)
        {
            input.text = max.ToString();
        }
        //if hte user inputs a value lower than the min, set the user generated value to the min
        if (int.Parse(input.text) < min)
        {
            input.text = min.ToString();
        }
    }
}
