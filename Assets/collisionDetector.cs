using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class collisionDetector : MonoBehaviour {
    Color currentColor = Color.yellow;

    public AudioClip mySound;
    public float volume;
    AudioSource audio;

    void Start()
    {
        audio = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
       
    }
    // Update is called once per frame
    private void OnCollisionEnter(Collision collision)
    {
       // print("CollisionNNN BITCH");
       // Shader cube = Shader.Find("cube");
      //  gameObject.GetComponent<Renderer>().material.color = Color.green;
        if(collision.gameObject.name != "Plane") {
            toggleColor();
            if (audio)
            {
                audio.PlayOneShot(mySound, volume);
            }
        }
    }
    private void OnCollisionExit(Collision collision)
    {
        // print("CollisionNNN BITCH");
        // Shader cube = Shader.Find("cube");
        //  gameObject.GetComponent<Renderer>().material.color = Color.green;
        if (collision.gameObject.name != "Plane")
        {
            toggleColor();
        }
    }

    private void toggleColor()
    {
        if(currentColor == Color.yellow){
            gameObject.GetComponent<Renderer>().material.color = Color.green;
            currentColor = Color.green;
        }else {
            gameObject.GetComponent<Renderer>().material.color = Color.yellow;
            currentColor = Color.yellow;
        }
    }


}
