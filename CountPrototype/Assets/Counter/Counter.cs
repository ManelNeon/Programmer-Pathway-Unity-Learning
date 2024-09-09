using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Counter : MonoBehaviour
{
    //Counter text in the UI
    public Text CounterText;

    //Counter
    [HideInInspector] public int count = 0;

    //Manger to get the time
    GameManager manager;

    //sound in unity inspector
    [SerializeField] AudioClip gotBall;

    //audio source
    AudioSource playerAudio;

    private void Start()
    {
        //getting audio source component
        playerAudio = GetComponent<AudioSource>();
        //establishing the manager
        manager = GameObject.Find("Game Manager").GetComponent<GameManager>();
        count = 0;
    }
    private void OnCollisionEnter(Collision collision)
    {
        //playing the gotball sound
        playerAudio.PlayOneShot(gotBall, 1.0f);
        //setting the ball false
        collision.gameObject.SetActive(false);
        //getting more time when getting a ball
        manager.time += 5;
        //getting one more on the count
        count += 1;
        //changing the text in the UI
        CounterText.text = "Count : " + count;
    }
}
