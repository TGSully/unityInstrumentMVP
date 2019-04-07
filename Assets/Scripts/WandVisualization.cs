using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WandVisualization : MonoBehaviour
{

    void OnEnable()
    {
        PositionProducer.OnNewPosition += Move;
    }


    void OnDisable()
    {
        PositionProducer.OnNewPosition -= Move;
    }


    void Move(Vector3 position)
    {
        print(position);
    }
}
