using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField] int levelEnemyCount;

    [SerializeField] GameObject enemyPrefabs;

    [SerializeField] GameObject bossEnemyPrefab;

    [SerializeField] float spawnRate = 1.5f;

    float spawnPosX;

    float spawnPosY;

    int infiniteEnemyCount;

    void Start()
    {
        GameManager.Instance.enemyCount = levelEnemyCount;

        GameManager.Instance.EnemiesCountSet();

        InvokeRepeating("SpawnEnemies", .5f, spawnRate);
    }

    void SpawnEnemies()
    {
        if (GameManager.Instance.isPlaying)
        {
            //between -13 and 13 in X

            // between 6 or 7 in Y value max

            spawnPosX = Random.Range(-13f, 13f);

            spawnPosY = Random.Range(-7f, -6f);

            if (!GameManager.Instance.isInfinite)
            {
                if (GameManager.Instance.enemyCount > 1)
                {
                    Instantiate(enemyPrefabs, new Vector3(spawnPosX, spawnPosY, 0), enemyPrefabs.transform.rotation);
                }
                else
                {
                    Instantiate(bossEnemyPrefab, new Vector3(spawnPosX, spawnPosY, 0), bossEnemyPrefab.transform.rotation);
                    CancelInvoke("SpawnEnemies");
                }
            }
            else
            {
                if (infiniteEnemyCount % 10 != 0 || infiniteEnemyCount == 0)
                {
                    Instantiate(enemyPrefabs, new Vector3(spawnPosX, spawnPosY, 0), enemyPrefabs.transform.rotation);
                }
                else
                {
                    Instantiate(bossEnemyPrefab, new Vector3(spawnPosX, spawnPosY, 0), bossEnemyPrefab.transform.rotation);
                }

                infiniteEnemyCount++;
            }
        }
    }
}
