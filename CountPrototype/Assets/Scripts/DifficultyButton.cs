using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DifficultyButton : MonoBehaviour
{
    //difficulty, established in each button
    [SerializeField] int difficulty;

    //getting the button component
    Button button;

    //getting the manager to start the game
    GameManager gameManager;

    //sound in the unity inspector
    [SerializeField] AudioClip clickedButton;

    //audiosource from the box
    AudioSource boxAudio;

    void Start()
    {
        //getting the audio source
        boxAudio = GameObject.Find("Box").GetComponent<AudioSource>();

        //establishing the manager
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();

        //establishing the button
        button = GetComponent<Button>();

        //adding an onclick event that does the DifficultySet function
        button.onClick.AddListener(DifficultySet);
    }

    //function that sets the difficulty and starts the game
    void DifficultySet()
    {
        //Playing the audio
        boxAudio.PlayOneShot(clickedButton, 1.0f);

        gameManager.StartGame(difficulty);
    }
}
