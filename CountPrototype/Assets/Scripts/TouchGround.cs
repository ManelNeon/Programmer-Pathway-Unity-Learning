using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchGround : MonoBehaviour
{
    //getting the manager so that we can change time
    GameManager manager;

    //sound in the unity inspector
    [SerializeField] AudioClip ballLost;

    //audiosource from the box
    AudioSource boxAudio;

    private void Start()
    {
        //getting the audio source
        boxAudio = GameObject.Find("Box").GetComponent<AudioSource>();

        //establishing the manager
        manager = GameObject.Find("Game Manager").GetComponent<GameManager>();
    }

    //Code that deactivates the object when it enters collision
    private void OnCollisionEnter(Collision collision)
    {
        //if the collision isnt the player
        if (!collision.gameObject.CompareTag("Player"))
        {
            //Playing the audio
            boxAudio.PlayOneShot(ballLost, 1.0f);

            //taking off time and disabling object
            manager.time -= 5;
            this.gameObject.SetActive(false);
        }
    }
}
