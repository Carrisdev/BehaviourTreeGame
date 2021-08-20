using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hoverText : MonoBehaviour
{
    Vector3 scale;
    private void Start()
    {
        scale = transform.localScale;
        transform.localScale = new Vector3(0, 0, 0);
    }

    public void onHover()
    {
        transform.localScale = scale;
    }

    public void offHover()
    {
        transform.localScale = new Vector3(0, 0, 0);
    }
}
