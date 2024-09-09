using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("PlayerMovement")]

    [SerializeField] float speed = 20;

    [SerializeField] float turnSpeed = 45;

    float horizontalInput;

    float verticalInput;

    void Update()
    {
        PlayerMovement();
    }

    void PlayerMovement()
    {
        horizontalInput = Input.GetAxisRaw("Horizontal");

        verticalInput = Input.GetAxisRaw("Vertical");

        //Control the speed of the Player, forward
        transform.Translate(Vector3.forward * Time.deltaTime * speed * verticalInput);

        //Control the rotation of the Player, sides
        transform.Rotate(Vector3.up, turnSpeed * Time.deltaTime * horizontalInput);
    }
}
