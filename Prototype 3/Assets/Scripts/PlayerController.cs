using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("Player Jump")]

    [SerializeField] float jumpForce;

    [SerializeField] float gravityModifier;

    bool grounded;

    [HideInInspector] public bool gameOver;

    Rigidbody rb;

    Animator playerAnim;

    [Header("Particle")]

    [SerializeField] ParticleSystem explosionParticle;

    [SerializeField] ParticleSystem runningParticle;

    [Header("Audio Clips")]

    [SerializeField] AudioClip jumpSound;

    [SerializeField] AudioClip crashSound;

    AudioSource playerAudio;

    void Start()
    {
        playerAnim = GetComponent<Animator>();
        playerAudio = GetComponent<AudioSource>();
        rb = GetComponent<Rigidbody>();
        Physics.gravity *= gravityModifier;
        gameOver = false;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && grounded && !gameOver)
        {
            playerAudio.PlayOneShot(jumpSound, 1.0f);
            runningParticle.Stop();
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            grounded = false;
            playerAnim.SetTrigger("Jump_trig");
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            runningParticle.Play();
            grounded = true;
        }
        else if (collision.gameObject.CompareTag("Obstacle"))
        {
            gameOver = true;
            Debug.Log("Game Over!");
            playerAnim.SetBool("Death_b", true);
            playerAnim.SetInteger("DeathType_int", 1);
            explosionParticle.Play();
            runningParticle.Stop();
            playerAudio.PlayOneShot(crashSound, 1.0f);
        }
    }
}
