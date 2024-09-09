using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class WeaponScript : MonoBehaviour
{
    [SerializeField] string weaponName;

    [SerializeField] int weaponCost;

    [SerializeField] Sprite weaponImage;

    [SerializeField] float reloadTime;

    [SerializeField] GameObject weaponPrefab;

    [SerializeField] AudioClip weaponSound;

    [SerializeField] TextMeshProUGUI weaponNameUI;

    [SerializeField] TextMeshProUGUI weaponCostUI;

    [SerializeField] GameObject coinUI;

    [SerializeField] Image weaponImageUI;

    [SerializeField] GameObject isBoughtCheckmark;

    public bool isBought;

    private void OnEnable()
    {
        isBoughtCheckmark.SetActive(isBought);

        coinUI.SetActive(!isBought);

        if (isBought)
        {
            weaponCostUI.text = "BOUGHT";
        }
        else
        {
            weaponCostUI.text = weaponCost.ToString();
        }

        weaponNameUI.text = weaponName;

        weaponImageUI.sprite = weaponImage;
    }

    public void OnClick()
    {
        if (isBought)
        {
            GameManager.Instance.currentWeaponImage = weaponImage;

            GameManager.Instance.currentWeaponReloadTime = reloadTime;

            GameManager.Instance.currentWeaponPrefab = weaponPrefab;

            SFXManager.Instance.currentWeaponSound = weaponSound;

            MainMenuManager.Instance.ChangeWeaponSprite();

            SFXManager.Instance.PlayWeaponEquiped();
        }
        else
        {
            if (GameManager.Instance.gold >= weaponCost)
            {
                GameManager.Instance.gold -= weaponCost;

                MainMenuManager.Instance.ChangeGoldText();

                SFXManager.Instance.PlayWeaponBought();

                isBoughtCheckmark.SetActive(true);

                coinUI.SetActive(false);

                isBought = true;

                ShopManager.Instance.WeaponBought();

                weaponCostUI.text = "BOUGHT";
            }
            if (GameManager.Instance.gold < weaponCost)
            {
                SFXManager.Instance.PlayWeaponCantBuy();
            }
        }
    }
}
