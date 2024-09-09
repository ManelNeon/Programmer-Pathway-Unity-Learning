using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    //UI That only appears ingame
    [SerializeField] GameObject inGameUI;

    //Getting the counter object
    [SerializeField] Counter counter;

    //UI that only appeares when game is over
    [SerializeField] GameObject gameOverUI;

    //UI title, buttons and text
    [SerializeField] GameObject titleUI;

    //Countdown text on Ui
    [SerializeField] Text timeText;

    //Variable that determines the time it takes to spawn the first ball
    [SerializeField] float initialSpawn;

    //Variable that determines the time it takes to spawn balls
    [SerializeField] float spawnRate;

    //Countdown time
    [HideInInspector] public int time = 60;

    //Bool checking if the game is playing
    [HideInInspector] public bool gameIsPlaying;

    //sound in the unity inspector
    [SerializeField] AudioClip gameOverSound;

    //audiosource from the box
    AudioSource boxAudio;

    void Start()
    {
        //getting the audio source
        boxAudio = GameObject.Find("Box").GetComponent<AudioSource>();

        //deactivating the UI's that shouldnt be activated at the start, and activating the ones that should
        titleUI.SetActive(true);
        gameOverUI.SetActive(false);
        inGameUI.SetActive(false);
    }

    //Function that starts the game, it needs a difficulty accessor to divide with the spawnrate
    public void StartGame(int difficulty)
    {   
        titleUI.SetActive(false);
        inGameUI.SetActive(true);
        spawnRate /= difficulty;
        gameIsPlaying = true;
        InvokeRepeating("SpawnBalls", initialSpawn, spawnRate);
        //if difficulty is the hardest, two sets of balls will spawn
        if (difficulty == 3)
        {
            InvokeRepeating("SpawnBalls", initialSpawn + 3, spawnRate);
        }
        StartCoroutine(Countdown());
    }

    //Spawning Balls Function
    void SpawnBalls()
    {
        if (gameIsPlaying)
        {
            //Position in which the ball will spawn, Y = 19 because its out of the camera view, and the range is the same as the max and min the player can go to
            Vector3 spawnPos = new Vector3(0, 19, Random.Range(-19, 19));
            //Getting the ball from the ObjectPooler object
            GameObject ball = ObjectPooler.SharedInstance.GetPooledObject();
            //Setting it active
            ball.SetActive(true);
            //Setting it's position the same as the spawnPos
            ball.transform.position = spawnPos;
        }
    }

    //Countdown that counts down the timer, duh
    IEnumerator Countdown()
    {
        //checks if the game is playing
        while (gameIsPlaying)
        {
            //if timer is bigger than 0, it will wait 1 second and take time off
            if (time > 0)
            {
                yield return new WaitForSeconds(1);
                time--;
                timeText.text = ("Time : " + time);
            }
            //if timer is zero or less, it will stop the game
            else
            {
                GameOver();
                yield return null;
            }
        }
    }

    //Function that has the code for when the game is over
    void GameOver()
    {
        //Playing the audio
        boxAudio.PlayOneShot(gameOverSound, 1.0f);

        //getting the count from the counter and keeping it as a score in this code
        int score = counter.count;
        //putting the score in the game over screen
        gameOverUI.GetComponent<TextMeshProUGUI>().text = ("Game Over\r\nScore: "+ score);
        inGameUI.SetActive(false);
        gameIsPlaying = false;
        gameOverUI.SetActive(true);
    }

    //Function that restarts the game
    public void RestartGame()
    {
        SceneManager.LoadScene(0);
    }
}
