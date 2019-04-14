using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WandVisualization : MonoBehaviour
{
    private Vector3 reportedPosition = Vector3.zero;

    private void Update()
    {
        print(reportedPosition.ToString("F4"));
        //float width = transform.parent.GetComponent<Transform>();
        var newPosition = new Vector3(2f * (-reportedPosition.x + 0.5f), 3.14f * reportedPosition.z - 3.14f / 2, 1.5f * (-reportedPosition.y + 0.5f));
        transform.localPosition = newPosition * 2f * 2f;

    }
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
        reportedPosition = position;
    }
}
