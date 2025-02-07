using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBoss : MonoBehaviour
{
    private Animator animator;
    private BoxCollider2D boxCl;
    private Rigidbody2D rb;
    [SerializeField] private AudioSource deathSFX;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        boxCl = GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player") || collision.gameObject.CompareTag("Player Bullet"))
        {
            boxCl.enabled = false;
            this.deathSFX.Play();
            this.animator.SetTrigger("death");
            StartCoroutine(DestroyEnemy());
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player") || collision.gameObject.CompareTag("Player Bullet"))
        {
            boxCl.enabled = false;
            rb.bodyType = RigidbodyType2D.Kinematic;
            this.deathSFX.Play();
            this.animator.SetTrigger("death");
            StartCoroutine(DestroyEnemy());
        }
    }
    IEnumerator DestroyEnemy()
    {
        yield return new WaitForSeconds(0.3f);
        Destroy(gameObject);
    }
}
