using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GoogleARCore;

public class ImageVisualizer : MonoBehaviour
{

    public AugmentedImage Image;

    void Start()
    {
        
    }

    void Update()
    {
        if (Image == null || Image.TrackingState != TrackingState.Tracking)
        {
            return;
        }

        transform.localScale = new Vector3(Image.ExtentX, Image.ExtentZ, Image.ExtentX);
    }
}
