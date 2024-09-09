using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ButtonManager : MonoBehaviour
{
    public static ButtonManager Instance;

    [SerializeField] GameObject pauseMenuUI;

    [SerializeField] GameObject pauseButton;

    [Header("OptionsInterface")]
    [SerializeField] GameObject optionsInterface;

    [SerializeField] Toggle chickenModeToggle;

    [SerializeField] Slider musicVolume;

    [SerializeField] Slider sfxVolume;

    [SerializeField] GameObject endLevelUI;

    [SerializeField] GameObject playerDiedUI;

    private void Start()
    {
        if (Instance != null)
        {
            Destroy(Instance);
        }
        Instance = this;
    }

    public void EndLevelScreen()
    {
        endLevelUI.SetActive(true);

        SFXManager.Instance.PlayButtonPress();
    }

    public void PlayerDiedScreen()
    {
        playerDiedUI.SetActive(true);

        SFXManager.Instance.PlayButtonPress();
    }

    public void ButtonEndMainMenu()
    {
        Time.timeScale = 1;

        SFXManager.Instance.PlayButtonPress();

        SceneManager.LoadScene(0);
    }

    public void ButtonPauseGame()
    {
        pauseButton.SetActive(false);

        GameManager.Instance.isPlaying = false;

        pauseMenuUI.SetActive(true);

        SFXManager.Instance.PlayButtonPress();
    }

    public void ButtonResumeGame()
    {
        pauseButton.SetActive(true);

        pauseMenuUI.SetActive(false);

        SFXManager.Instance.PlayButtonPress();

        GameManager.Instance.isPlaying = true;
    }

    public void ButtonOptionsMenu()
    {
        chickenModeToggle.isOn = GameManager.Instance.chickenMode;

        musicVolume.value = BackgroundMusicManager.Instance.backgroundMusic.volume;

        sfxVolume.value = SFXManager.Instance.sfxAudio.volume;

        pauseMenuUI.SetActive(false);

        optionsInterface.SetActive(true);

        SFXManager.Instance.PlayButtonPress();
    }

    public void BackButton()
    {
        pauseMenuUI.SetActive(true);

        optionsInterface.SetActive(false);
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
