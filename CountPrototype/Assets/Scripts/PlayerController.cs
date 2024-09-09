using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    //speed variable
    [SerializeField] float speed;

    GameManager gameManager;

    void Start()
    {
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
    }
    //change to fixed update making movement smoother
    void FixedUpdate()
    {
        if (gameManager.gameIsPlaying)
        {
            Movement();

            Constraints();
        }
    }

    void Constraints()
    {
        //checks if the player is in the furthest left position
        if (transform.position.z < -19)
        {
            //makes it so that he won't leave that position
            transform.position = new Vector3(transform.position.x, transform.position.y, -19);
        }
        //checks if the player is in the furthest right position
        else if (transform.position.z > 19)
        {
            //makes it so that he won't leave that position
            transform.position = new Vector3(transform.position.x, transform.position.y, 19);
        }
    }
    void Movement()
    {
        //getting the input
        float horizontalInput = Input.GetAxisRaw("Horizontal");

        //making the player move in the Z axis
        transform.Translate(Vector3.forward * horizontalInput * speed * Time.deltaTime);
    }
}
