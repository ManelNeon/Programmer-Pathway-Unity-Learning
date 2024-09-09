using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopManager : MonoBehaviour
{
    public static ShopManager Instance;

    public WeaponScript[] shopWeapons;

    private void Start()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
    }

    public void WeaponBought()
    {
        for (int i = 0; i < shopWeapons.Length; i++)
        {
            if (shopWeapons[i].isBought)
            {
                GameManager.Instance.isBought[i] = true;
            }
        }
    }

    public void CheckWeaponsBought()
    {
        for (int i = 0; i < GameManager.Instance.isBought.Length; i++)
        {
            if (GameManager.Instance.isBought[i])
            {
                shopWeapons[i].isBought = true;
            }
        }
    }
}
