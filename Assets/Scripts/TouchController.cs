using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GoogleARCore;

public class TouchController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        for (var i = 0; i < Input.touchCount; ++i)
        {
            if (Input.GetTouch(i).phase == TouchPhase.Began)
            {

                // Construct a ray from the current touch coordinates
                Ray ray = Camera.main.ScreenPointToRay(Input.GetTouch(i).position);
                // Create a particle if hit
                RaycastHit hit;
                print("Sending Raycast");
                if (Physics.Raycast(ray, out hit))
                {
                    print("Hit");
                    if (hit.collider == null)
                    {
                        return;
                    }

                    GameObject collided = hit.collider.gameObject;
                    if (collided.tag == "Note")
                    {
                        collisionDetector det = collided.GetComponent<collisionDetector>();
                        //do something
                        det.PlaySound();
                    }
                }

            }
        }

    }
}
