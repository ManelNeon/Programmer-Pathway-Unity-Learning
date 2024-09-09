using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [Header("Animals")]
    [SerializeField] GameObject[] animalPrefabs;

    [Header("Spawn Settings")]
    [SerializeField] float spawnRangeX = 20;

    [SerializeField] float spawnPosZ = 20;

    [SerializeField] float startDelay = 2;

    [SerializeField] float spawnInterval = 1.5f;

    void Start()
    {
        InvokeRepeating("AnimalSpawn", startDelay, spawnInterval);
    }

    //Spawn Animals
    void AnimalSpawn()
    {
        int animalIndex = Random.Range(0, animalPrefabs.Length);

        //random number para decidir se vai nascer em cima, ou dos lados
        int random = Random.Range(0, 3);

        if (random == 0)
        {
            Vector3 spawnPos = new Vector3(-24, 0, Random.Range(0, 15));

            Instantiate(animalPrefabs[animalIndex], spawnPos, animalPrefabs[animalIndex].transform.rotation * Quaternion.Euler(0, -90, 0));
        }
        else if (random == 1)
        {
            Vector3 spawnPos = new Vector3(24, 0, Random.Range(0, 15));

            Instantiate(animalPrefabs[animalIndex], spawnPos, animalPrefabs[animalIndex].transform.rotation * Quaternion.Euler(0, 90, 0));
        }
        else if (random == 2)
        {
            Vector3 spawnPos = new Vector3(Random.Range(-spawnRangeX, spawnRangeX), 0, spawnPosZ);

            Instantiate(animalPrefabs[animalIndex], spawnPos, animalPrefabs[animalIndex].transform.rotation);
        }
    }
}
