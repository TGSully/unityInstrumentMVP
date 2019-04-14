using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class collisionDetector : MonoBehaviour {
    //////Color currentColor = Color.yellow;
    Color origColor;
    Color currentColor;
    public AudioClip mySound;
    public float volume;
    public AudioSource audio;

    void Start()
    {
        audio = GetComponent<AudioSource>();
        currentColor = gameObject.GetComponent<Renderer>().material.color;
        origColor = currentColor;
    }

    // Update is called once per frame
    void Update()
    {
       
    }
    // Update is called once per frame
    private void OnCollisionEnter(Collision collision)
    {
        print("Collision enter");
        // print("CollisionNNN BITCH");
        // Shader cube = Shader.Find("cube");
        //  gameObject.GetComponent<Renderer>().material.color = Color.green;
        if (collision.gameObject.name != "Plane") {
            toggleColor();
            PlaySound();
        }
    }

    //private void OnMouseExit()
    //{
    //    print("Mouse exit");
    //    toggleColor();
    //    PlaySound();
    //}

    //private void OnMouseEnter()
    //{
    //    print("Mouse enter");
    //    toggleColor();
    //}

    void OnMouseDown()
    {
        print("Mouse down");
        toggleColor();
        PlaySound();
    }

    void OnMouseUp()
    {
        print("Mouse up");
        toggleColor();
    }

    public void PlaySound()
    {
        if (audio)
        {
            audio.PlayOneShot(mySound, volume);
        }
    }
    private void OnCollisionExit(Collision collision)
    {
        print("Collision exit");
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
        if(currentColor == origColor){
            gameObject.GetComponent<Renderer>().material.color = Color.green;
            currentColor = Color.green;
        }else {
            gameObject.GetComponent<Renderer>().material.color = origColor;
            currentColor = origColor;
        }
    }


}
