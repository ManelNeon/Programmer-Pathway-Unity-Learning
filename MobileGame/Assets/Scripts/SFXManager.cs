using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SFXManager : MonoBehaviour
{
    public static SFXManager Instance;

    public AudioSource sfxAudio;

    public AudioClip currentWeaponSound; //starts with the arrow sound, as it is the initial sound

    [SerializeField] AudioClip buttonPress;

    [SerializeField] AudioClip sensitiveWeaponSound;

    [SerializeField] AudioClip weaponBoughtSound;

    [SerializeField] AudioClip weaponCantBuySound;

    [SerializeField] AudioClip equipedWeaponSound;

    [SerializeField] AudioClip stillReloadingSound;

    [SerializeField] AudioClip reloadSound;

    [SerializeField] AudioClip enemyDeathSound;

    [SerializeField] AudioClip sensitiveEnemyDeathSound;

    [SerializeField] AudioClip winLevelSound;

    [SerializeField] AudioClip goldObtained;

    // Start is called before the first frame update
    void Start()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;

        DontDestroyOnLoad(gameObject);

        sfxAudio = GetComponent<AudioSource>();
    }

    public void PlayButtonPress()
    {
        sfxAudio.PlayOneShot(buttonPress);
    }

    public void PlayWeaponSound()
    {
        if (!GameManager.Instance.chickenMode)
        {
            sfxAudio.PlayOneShot(currentWeaponSound);
        }
        else
        {
            sfxAudio.PlayOneShot(sensitiveWeaponSound);
        }
    }

    public void PlayWeaponBought()
    {
        sfxAudio.PlayOneShot(weaponBoughtSound);
    }

    public void PlayWeaponCantBuy()
    {
        sfxAudio.PlayOneShot(weaponCantBuySound);
    }

    public void PlayWeaponEquiped()
    {
        sfxAudio.PlayOneShot(equipedWeaponSound);
    }

    public void PlayStillReloadingSound()
    {
        sfxAudio.PlayOneShot(stillReloadingSound);
    }

    public void PlayReloadSound()
    {
        sfxAudio.PlayOneShot(reloadSound);
    }

    public void PlayDeathEnemySound()
    {
        if (!GameManager.Instance.chickenMode)
        {
            sfxAudio.PlayOneShot(enemyDeathSound);
        }
        else
        {
            sfxAudio.PlayOneShot(sensitiveEnemyDeathSound);
        }
    }

    public void PlayWinLevelSound()
    {
        sfxAudio.PlayOneShot(winLevelSound);
    }

    public void PlayGoldObtainedSound()
    {
        sfxAudio.PlayOneShot(goldObtained);
    }
}
