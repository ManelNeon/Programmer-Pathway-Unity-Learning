using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    Transform player;

    Rigidbody2D enemyRB;

    [SerializeField] float speed = 2.0f;

    [SerializeField] int hitPoints;

    [SerializeField] bool isBoss;

    [SerializeField] int maxGold;

    [SerializeField] int minGold;

    [SerializeField] GameObject gold;

    [SerializeField] GameObject blood;

    [SerializeField] Sprite[] damageSprites;

    int index;

    Vector3 movement;

    private void Start()
    {
        player = GameObject.Find("Player").GetComponent<Transform>();

        enemyRB = GetComponent<Rigidbody2D>();

        index = 0;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 direction = player.position - transform.position;

        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

        enemyRB.rotation = angle;

        direction.Normalize();

        movement = direction;
    }

    void FixedUpdate()
    {
        if (GameManager.Instance.isPlaying)
        {
            enemyRB.MovePosition(transform.position + (movement * speed * Time.deltaTime));
        }
        if (GameManager.Instance.enemyCount == 1 && !isBoss && !GameManager.Instance.isInfinite)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Projectile"))
        {
            Destroy(collision.gameObject);


            if (!GameManager.Instance.chickenMode)
            {
                GameObject bloodEffect = Instantiate(blood, transform.position, blood.transform.rotation);

                bloodEffect.GetComponent<ParticleSystem>().Play();
            }

            if (hitPoints - 1 == 0)
            {
                if (!isBoss)
                {
                    GameObject goldEffect = Instantiate(gold, transform.position, gold.transform.rotation);

                    goldEffect.GetComponent<ParticleSystem>().Play();
                }

                int goldCount = Random.Range(minGold, maxGold + 1);

                GameManager.Instance.AddGold(goldCount);

                SFXManager.Instance.PlayGoldObtainedSound();

                if (!GameManager.Instance.isInfinite)
                {
                    GameManager.Instance.enemyCount--;
                }
                else
                {
                    GameManager.Instance.enemyCount++;
                }

                GameManager.Instance.EnemiesCountSet();

                if (GameManager.Instance.enemyCount == 0 && !GameManager.Instance.isInfinite)
                {
                    GameManager.Instance.EndLevel();
                }

                Destroy(gameObject);

                SFXManager.Instance.PlayDeathEnemySound();

                return;
            }

            hitPoints--;

            if (isBoss)
            {
                SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();

                spriteRenderer.sprite = damageSprites[index];

                index++;
            }
        }
    }
}