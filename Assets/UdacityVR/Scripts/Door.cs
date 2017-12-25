using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour 
{
    // Create a boolean value called "locked" that can be checked in OnDoorClicked() 
    private bool locked = true;

    // Create a boolean value called "opening" that can be checked in Update() 
    private bool opening = false;

    // Sounds Variables
    public AudioClip doorLocked;
    public AudioClip doorOpened;
    public AudioSource player;

    void Update() {
        // If the door is opening and it is not fully raised
        if (opening)
        {
            // Animate the door raising up
            transform.Translate(0, 2.5f * Time.deltaTime, 0, Space.World);

            // Checking to see of the has finished opening
            if (transform.position.y >= 9)
            {
                opening = false;
            }
        }
    }

    public void OnDoorClicked() {
        // If the door is clicked and unlocked
        if (locked == false)
        {
            // Set the "opening" boolean to true
            opening = true;

            // Play a sound to indicate the door is unlocked
            player.clip = doorOpened;
            player.Play();
        }
        // (optionally) Else
        else
        {
            // Play a sound to indicate the door is locked
            player.clip = doorLocked;
            player.Play();
        }
    }

    public void Unlock()
    {
        // You'll need to set "locked" to false here
        locked = false;
    }
}
