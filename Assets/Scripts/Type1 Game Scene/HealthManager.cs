using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthManager : MonoBehaviour
{
    [SerializeField] private Image healthBar;
    [SerializeField] private float healthAmount = 100f;
    [SerializeField] private float playerBulletDamage = 5f;
    [SerializeField] private float bossWeakBulletDamage = 10f;
    [SerializeField] private float bossStrongBulletDamage = 15f;
    [SerializeField] private float enemyDamage = 20f;
    [SerializeField] private float bossDamage = 30f;
    [SerializeField] private float healAmount = 15f;
    [SerializeField] private AudioSource collectHeart = null;
    
    private Boss boss;
    private PlayerLife playerLife;
    // Start is called before the first frame update
    void Start()
    {
        boss = GetComponent<Boss>();
        playerLife = GetComponent<PlayerLife>();
    }

    // Update is called once per frame
    void Update()
    {
        if (gameObject.CompareTag("Boss"))
        {
            if (healthBar.fillAmount == 0)
            {
                this.enabled = false;
                boss.Die();
            }
        }

        if (gameObject.CompareTag("Player"))
        {
            if (healthBar.fillAmount == 0)
            {
                this.enabled = false;
                playerLife.Die();
            }
        }
        
    }

    public void TakeDamage(float damage)
    {
        healthAmount -= damage;
        healthAmount = Mathf.Clamp(healthAmount, 0, 100);
        healthBar.fillAmount = healthAmount / 100f;
    }

    public void Heal(float healAmount)
    {
        healthAmount += healAmount;
        healthAmount = Mathf.Clamp(healthAmount, 0, 100);

        healthBar.fillAmount = healthAmount / 100f;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (gameObject.CompareTag("Player"))
        {
            if (collision.gameObject.CompareTag("Boss Weak Bullet"))
            {
                TakeDamage(bossWeakBulletDamage);
            }

            if (collision.gameObject.CompareTag("Boss Strong Bullet"))
            {
                TakeDamage(bossStrongBulletDamage);
            }


            if (collision.gameObject.CompareTag("Boss"))
            {
                TakeDamage(bossDamage);
            }

            if (collision.gameObject.CompareTag("Ghost"))
            {
                TakeDamage(enemyDamage);
            }

            if (collision.gameObject.CompareTag("Heart"))
            {
                collectHeart.Play();
                Heal(healAmount);
                Destroy(collision.gameObject);
            }
        }

        if (gameObject.CompareTag("Boss"))
        {
            if (collision.gameObject.CompareTag("Player Bullet"))
            {
                TakeDamage(playerBulletDamage);
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (gameObject.CompareTag("Player"))
        {
            if (collision.gameObject.CompareTag("Rock") || collision.gameObject.CompareTag("Slime"))
            {
                TakeDamage(enemyDamage);
            }

        }
    }
}
