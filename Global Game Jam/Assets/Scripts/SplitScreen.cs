using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SplitScreen : MonoBehaviour
{
     public Camera cam1, cam2;

    private bool isHorizontalSplit = true;

    // Update is called once per frame
    void Update()
    {
        SetSplitScreen();
    }

    public void SetSplitScreen()
    {
        if (isHorizontalSplit)
        {
            cam1.rect = new Rect(0, 0.5f, 1, 0.5f);
            cam2.rect = new Rect(0, 0, 1, 0.5f);
        }
    }
}
