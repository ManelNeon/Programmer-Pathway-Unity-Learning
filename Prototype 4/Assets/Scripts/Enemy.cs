using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] float speed;

    Rigidbody rb;

    GameObject player;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        player = GameObject.Find("Player");
    }

    void Update() 
    { 
        Vector3 lookDirection = (player.transform.position - transform.position).normalized;

        rb.AddForce(lookDirection * speed);

        if (transform.position.y < -5)
        {
            Destroy(gameObject);
        }
    }
}
