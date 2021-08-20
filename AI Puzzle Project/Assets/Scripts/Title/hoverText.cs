using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hoverText : MonoBehaviour
{
    Vector3 scale;
    private void Start()
    {
        //save the scale since i'll need to use this later
        scale = transform.localScale;
        //hide the image
        transform.localScale = new Vector3(0, 0, 0);
    }

    //scale up the image to normal scale
    public void onHover()
    {
        transform.localScale = scale;
    }

    //scale down the image so it's invisible
    public void offHover()
    {
        transform.localScale = new Vector3(0, 0, 0);
    }
}
