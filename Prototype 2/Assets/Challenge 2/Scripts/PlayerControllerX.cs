using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerX : MonoBehaviour
{
    public GameObject dogPrefab;

    //timer que vai ver quanto tempo passou depois de spawnar um cão
    float dogCooldownTimer;

    //timer que diz quanto cooldown é que há entre spawns de cães
    [SerializeField] float dogCooldown = 1f;

    // Update is called once per frame
    void Update()
    {
        dogCooldownTimer += Time.deltaTime;

        // On spacebar press, send dog
        if (Input.GetKeyDown(KeyCode.Space) && dogCooldownTimer > dogCooldown)
        {
            Instantiate(dogPrefab, transform.position, dogPrefab.transform.rotation);

            dogCooldownTimer = 0f;
        }
    }
}
