using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField] GameObject obstaclePrefab;

    [SerializeField] Vector3 spawnPos = new Vector3(25, 0, 0);

    float startDelay = 2;

    float repeatDelay = 2;

    PlayerController playerController;

    void Start()
    {
        InvokeRepeating("SpawnObstacle", startDelay, repeatDelay);

        playerController = GameObject.Find("Player").GetComponent<PlayerController>();
    }

    void SpawnObstacle()
    {
        if (playerController.gameOver == false)
        {
            Instantiate(obstaclePrefab, spawnPos, obstaclePrefab.transform.rotation);
        }
    }
}
