using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    Rigidbody2D rb;

    GameObject arrowTemporary;

    bool reloaded;

    // Start is called before the first frame update
    void Start()
    {
        GameManager.Instance.EnemiesCountSet();

        rb = GetComponent<Rigidbody2D>();

        reloaded = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.touchCount > 0 && GameManager.Instance.isPlaying)
        {
            Touch touch = Input.GetTouch(0);

            if (touch.phase == TouchPhase.Began)
            {
                Vector3 touchPosition = Camera.main.ScreenToWorldPoint(new Vector3(touch.position.x, touch.position.y, 0));

                Vector3 direction = touchPosition - transform.position;

                float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

                rb.rotation = angle;

                if (reloaded)
                {
                    StartCoroutine(ReloadShot());
                }
            }
        }
        else if (GameManager.Instance.isPlaying && Input.GetMouseButton(0))
        {
            Vector3 touchPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            Vector3 direction = touchPosition - transform.position;

            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

            rb.rotation = angle;

            if (!reloaded)
            {
                SFXManager.Instance.PlayStillReloadingSound();
            }

            if (reloaded)
            {
                StartCoroutine(ReloadShot());
            }
        }
    }

    IEnumerator ReloadShot()
    {
        yield return new WaitForSeconds(.1f);

        if (GameManager.Instance.isPlaying)
        {
            reloaded = false;

            if (arrowTemporary != null)
            {
                Destroy(arrowTemporary);

                arrowTemporary = null;
            }

            arrowTemporary = Instantiate(GameManager.Instance.currentWeaponPrefab, transform.position, transform.rotation);

            SFXManager.Instance.sfxAudio.Stop();

            if (!SFXManager.Instance.sfxAudio.isPlaying)
            {
                SFXManager.Instance.PlayWeaponSound();
            }

            yield return new WaitForSeconds(GameManager.Instance.currentWeaponReloadTime);

            reloaded = true;
        }

        yield break;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            if (!GameManager.Instance.isInfinite)
            {
                GameManager.Instance.currentGold = 0;

                ButtonManager.Instance.PlayerDiedScreen();
            }
            else
            {
                GameManager.Instance.EndLevel();
            }

        }
    }
}
