using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class EnemyLife : MonoBehaviour
{
    private Rigidbody2D rb;
    private Animator animator;
    public GameObject enemy;
    private BoxCollider2D boxCollider;
    [SerializeField] private AudioSource deathSFX;

    //1 enemy = 1 point;
    private int enemyDieCount = 0;

    // Start is called before the first frame update
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        boxCollider = GetComponent<BoxCollider2D>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player") || collision.gameObject.CompareTag("Player Bullet"))
        {
            
            Die();
            
        }
    }

    private void Die()
    {
        enemyDieCount = PlayerPrefs.GetInt("savePoint");
        enemyDieCount++;
        SavePoint(enemyDieCount);
        boxCollider.enabled = false;
        deathSFX.Play();
        rb.bodyType = RigidbodyType2D.Static;
        animator.SetTrigger("death");
        StartCoroutine(DestroyEnemy());
    }

    private IEnumerator DestroyEnemy()
    {
        yield return new WaitForSeconds(0.4f);
        enemy.SetActive(false);
    }

    
    public void SavePoint(int pointCount)
    {
        PlayerPrefs.SetInt("savePoint", pointCount);
    }

    
}
