using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    [HideInInspector] public int enemyCount;

    [HideInInspector] public int gold;

    [HideInInspector] public int currentGold;

    [HideInInspector] public bool[] levelCleared;

    [HideInInspector] public bool[] isBought;

    [HideInInspector] public bool chickenMode;

    public Sprite currentWeaponImage;

    public float currentWeaponReloadTime;

    public GameObject currentWeaponPrefab;

    public bool isPlaying;

    public bool isInfinite;

    // Start is called before the first frame update
    void Start()
    {
        if (Instance != null)
        {
            Destroy(this.gameObject);
            return;
        }

        Instance = this;

        DontDestroyOnLoad(gameObject);

        levelCleared = new bool[30];

        isBought = new bool[ShopManager.Instance.shopWeapons.Length];

        isBought[0] = true;

        ShopManager.Instance.CheckWeaponsBought();
    }

    public void AddGold(int gold)
    {
        this.currentGold += gold;

        GameObject.Find("GoldCount").GetComponent<TextMeshProUGUI>().text = this.currentGold.ToString();
    }

    public void EnemiesCountSet()
    {
        GameObject.Find("EnemiesCount").GetComponent<TextMeshProUGUI>().text = enemyCount.ToString();
    }

    public void EndLevel()
    {
        SFXManager.Instance.PlayWinLevelSound();

        isPlaying = false;

        Time.timeScale = 0;

        if (!isInfinite)
        {
            ButtonManager.Instance.EndLevelScreen();
        }
        else
        {
            ButtonManager.Instance.PlayerDiedScreen();
        }

        int i = SceneManager.GetActiveScene().buildIndex;

        levelCleared[i] = true;

        gold += currentGold;
    }
}
