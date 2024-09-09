using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AnimalHealthManager : MonoBehaviour
{
    [SerializeField] Image health;

    int healthIndex = 0;

    void Start()
    {
        health.fillAmount = healthIndex;
    }

    public void ChangeHealth()
    {
        if (healthIndex + 34 < 100)
        {
            healthIndex += 34;
            if (healthIndex == 34)
            {
                health.fillAmount = 0.33f;
            }
            else if (healthIndex == 68)
            {
                health.fillAmount = 0.66f;
            }
        }
        else if (healthIndex + 34 >= 100)
        {
            GameObject player = GameObject.Find("Player");
            player.GetComponent<PlayerController>().AddScore();
            Destroy(gameObject);
        }
    }
}
