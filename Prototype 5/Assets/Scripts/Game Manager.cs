using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
public class GameManager : MonoBehaviour
{
    [SerializeField] List<GameObject> targets;

    [SerializeField] float spawnRate = 1.0f;

    [SerializeField] TextMeshProUGUI scoreText;

    [SerializeField] TextMeshProUGUI gameOverText;

    [SerializeField] GameObject titleScreen;

    [HideInInspector] public bool isGameActive;

    int score = 0;

    void Start()
    {   
        gameOverText.gameObject.SetActive(false);
        titleScreen.SetActive(true);
    }

    public void StartGame(int difficulty)
    {
        spawnRate /= difficulty;
        titleScreen.SetActive(false);
        isGameActive = true;
        StartCoroutine(SpawnTarget());
        score = 0;
        UpdateScore(0);
    }

    IEnumerator SpawnTarget()
    {
        while (isGameActive)
        {
            yield return new WaitForSeconds(spawnRate);
            int index = Random.Range(0, targets.Count);
            Instantiate(targets[index]);
        }
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(0);
    }

    public void GameOver()
    {
        gameOverText.gameObject.SetActive(true);
        isGameActive = false;
    }

    public void UpdateScore(int scoreToAdd)
    {
        score += scoreToAdd;
        scoreText.text = ("Score: " + score);
    }
}
