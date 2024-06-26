using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CarSounds : MonoBehaviour
{

    public AudioSource acceleration;
    public AudioSource breaking;


    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.W))
        {
            acceleration.Play();
        }
        if (Input.GetKeyUp(KeyCode.W)) 
        {
            acceleration.Stop();
        }
        if (Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.Space))
        {
            breaking.Play();
        }
        if (Input.GetKeyUp(KeyCode.S) || Input.GetKeyUp(KeyCode.Space))
        {
            breaking.Stop();    
        }
    }
}
