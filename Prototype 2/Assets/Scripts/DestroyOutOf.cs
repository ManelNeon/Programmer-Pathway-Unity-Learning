using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOutOf : MonoBehaviour
{
    float topBound = 30;

    float lowerBound = -10;

    float leftBound = -25;

    float rightBound = 25;
    void Update()
    {
        if (transform.position.z > topBound)
        {
            Destroy(gameObject);
        }
        else if (transform.position.z < lowerBound)
        {
            Debug.Log("Game Over!");
            Destroy(gameObject);
        }
        else if (transform.position.x < leftBound)
        {
            Destroy(gameObject);
        }
        else if (transform.position.x > rightBound)
        {
            Destroy(gameObject);
        }
    }
}
