using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    [Header("PlayerMovement")]

    [SerializeField] float speed = 10;

    float horizontalInput;
    
    float verticalInput;

    [Header("PlayerPosition")]

    //Variable that sees the max range the player can go to
    [SerializeField] float xRange = 10;

    [SerializeField] float yRangeMax = 15;

    [SerializeField] float yRangeMin = -2f;

    [SerializeField] GameObject projectilePrefab;

    [Header("PlayerScoreLife")]
    
    [SerializeField] int lives;

    int score = 0;

    [SerializeField] TextMeshProUGUI livesScoreUI;

    void Start()
    {
        ChangeUI();
    }

    void Update()
    {
        Movement();

        FixPosition();

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Instantiate(projectilePrefab,transform.position, projectilePrefab.transform.rotation);
        }
    }

    //Code that moves the player
    void Movement()
    {
        horizontalInput = Input.GetAxisRaw("Horizontal");

        verticalInput = Input.GetAxisRaw("Vertical");

        Vector3 zValue = new Vector3(0,0,1);

        transform.Translate(Vector3.right * horizontalInput * speed * Time.deltaTime);

        transform.Translate(zValue * verticalInput * speed * Time.deltaTime);
    }

    //Code that fixes the player position if he gets out of camera
    void FixPosition()
    {
        if (transform.position.x < -xRange)
        {
            transform.position = new Vector3(-xRange, transform.position.y, transform.position.z);
        }
        else if (transform.position.z < yRangeMin)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, yRangeMin);
        }
        else if (transform.position.z > yRangeMax)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, yRangeMax);
        }
        else if (transform.position.x > xRange)
        {
            transform.position = new Vector3(xRange, transform.position.y, transform.position.z);
        }
    }

    public void AddScore()
    {
        score++;
        ChangeUI();
    }

    public void TakeLife()
    {
        if (lives - 1 != 0)
        {
            lives--;
            ChangeUI();
        }
        else if (lives - 1 == 0)
        {
            SceneManager.LoadScene(0);
        }
    }

    void ChangeUI()
    {
        livesScoreUI.text = ("Score : " + score + " \nLives : " + lives);
    }
}
