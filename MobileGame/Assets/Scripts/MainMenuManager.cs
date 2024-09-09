using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuManager : MonoBehaviour
{
    public static MainMenuManager Instance;

    [Header("Play Button UI")]
    [SerializeField] GameObject playButton;

    [SerializeField] GameObject playOptions;

    [Header("Level UI")]
    [SerializeField] GameObject levelsInterface;

    [SerializeField] GameObject[] levelsCheck;

    [Header("MainMenuInterface")]
    [SerializeField] GameObject mainMenuInterface;

    [Header("UpgradeInterface")]
    [SerializeField] GameObject shopInterface;

    [SerializeField] TextMeshProUGUI goldText;

    [SerializeField] Image currentWeaponImage;

    [Header("OptionsInterface")]
    [SerializeField] GameObject optionsInterface;

    [SerializeField] Toggle chickenModeToggle;

    [SerializeField] Slider musicVolume;

    [SerializeField] Slider sfxVolume;

    private void Start()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }

    public void OnPlayPress()
    {
        playButton.SetActive(false);

        playOptions.SetActive(true);

        SFXManager.Instance.PlayButtonPress();
    }

    public void OnLevelsButtonPress() 
    {
        mainMenuInterface.SetActive(false);

        for (int i = 0; i < GameManager.Instance.levelCleared.Length; i++)
        {
            if (GameManager.Instance.levelCleared[i])
            {
                levelsCheck[i - 1].SetActive(true);
            }
        }

        levelsInterface.SetActive(true);

        SFXManager.Instance.PlayButtonPress();
    }

    public void OnOptionsPress()
    {
        chickenModeToggle.isOn = GameManager.Instance.chickenMode;

        musicVolume.value = BackgroundMusicManager.Instance.backgroundMusic.volume;

        sfxVolume.value = SFXManager.Instance.sfxAudio.volume;

        mainMenuInterface.SetActive(false);

        optionsInterface.SetActive(true);

        SFXManager.Instance.PlayButtonPress();
    }

    public void OnBackPress()
    {
        playOptions.SetActive(false);

        playButton.SetActive(true);

        mainMenuInterface.SetActive(true);

        optionsInterface.SetActive(false);

        levelsInterface.SetActive(false);

        shopInterface.SetActive(false);

        SFXManager.Instance.PlayButtonPress();
    }

    public void OnLevelPress(int level) 
    {
        GameManager.Instance.isPlaying = true;

        GameManager.Instance.currentGold = 0;

        SFXManager.Instance.PlayButtonPress();

        SceneManager.LoadScene(level);
    }

    public void OnUpgradePress()
    {
        ShopManager.Instance.CheckWeaponsBought();

        mainMenuInterface.SetActive(false);

        shopInterface.SetActive(true);

        ChangeGoldText();

        ChangeWeaponSprite();

        SFXManager.Instance.PlayButtonPress();
    }

    public void ChangeGoldText()
    {
        goldText.text = GameManager.Instance.gold.ToString();
    }

    public void OnInfinitePress()
    {
        GameManager.Instance.isInfinite = true;

        GameManager.Instance.currentGold = 0;

        GameManager.Instance.isPlaying = true;

        SFXManager.Instance.PlayButtonPress();

        SceneManager.LoadScene("LevelInfinite");
    }

    public void ChangeWeaponSprite()
    {
        currentWeaponImage.sprite = GameManager.Instance.currentWeaponImage;
    }

    public void MusicVolumeChange()
    {
        BackgroundMusicManager.Instance.backgroundMusic.volume = musicVolume.value;
    }

    public void SFXVolumeChange()
    {
        SFXManager.Instance.sfxAudio.volume = sfxVolume.value;
    }

    public void ToggleChickenMode()
    {
        GameManager.Instance.chickenMode = chickenModeToggle.isOn;
    }

}
