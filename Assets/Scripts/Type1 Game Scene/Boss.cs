using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class Boss : MonoBehaviour
{
    //private Rigidbody2D bossRb;
    private GameObject player;
    private Animator animator;
    private SpriteRenderer spriteRenderer;

    [SerializeField] private AudioSource deathSFX;
    [SerializeField] private AudioSource hitSFX;
    [SerializeField] private AudioSource finishSFX;
    [SerializeField] private GameObject finishUI = null;

    [SerializeField] private float speed = 20f;
    private float delayTimeWeakBullet;
    private float delayTimeStrongBullet;

    [SerializeField] private GameObject weakBullets;
    [SerializeField] private GameObject strongBullets;
    // Start is called before the first frame update
    void Start()
    {
        //bossRb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        player = GameObject.Find("Player");
        PlayerPrefs.SetInt("currentStage", SceneManager.GetActiveScene().buildIndex);
    }

    // Update is called once per frame
    void Update()
    {
        if (finishUI != null)
        {
            PressToCont();
        }
        UpdateDirection();
        transform.position = Vector2.MoveTowards(transform.position, player.transform.position, speed * Time.deltaTime);
        delayTimeWeakBullet += Time.deltaTime;
        delayTimeStrongBullet += Time.deltaTime;

        if (delayTimeStrongBullet > 6)
        {
            delayTimeStrongBullet = 0;
            ShootStrongBullet();
        }

        if (delayTimeWeakBullet > Random.Range(1.5f, 3))
        {
            delayTimeWeakBullet = 0;
            ShootWeakBullet();
        }
        
    }

    private void ShootWeakBullet()
    {
        Instantiate(weakBullets, transform.position, Quaternion.identity);
    }

    private void ShootStrongBullet()
    {
        Instantiate(strongBullets, transform.position, Quaternion.identity);
    }
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player") || collision.gameObject.CompareTag("Player Bullet"))
        {
            hitSFX.Play();
            animator.SetTrigger("hit");
        }
    }

    private void BackToIdle()
    {
        animator.Play("Boss_Idle");
    }
    public void Die()
    {
        PlayerPrefs.SetInt("unlockStage", PlayerPrefs.GetInt("currentStage"));
        deathSFX.Play();
        animator.SetTrigger("death");
        StartCoroutine(DestroyBoss());
        finishSFX.Play();
    }

    IEnumerator DestroyBoss()
    {
        yield return new WaitForSeconds(0.5f);
        //gameObject.SetActive(false);
        FinishStage();
    }

    public void FinishStage()
    {

        finishUI.SetActive(true);
        Time.timeScale = 0.0f;
    }

    private void PressToCont()
    {
        if (Input.anyKeyDown && finishUI.activeSelf == true)
        {
            Time.timeScale = 1f;
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);

        }
    }
    private void UpdateDirection()
    {
        if (player.transform.position.x < 0)
        {
            if ((player.transform.position.x - transform.position.x) < 0)
            {
                spriteRenderer.flipX = true;
            }
            else
            {
                spriteRenderer.flipX = false;
            }
        }
        else
        {
            if ((player.transform.position.x - transform.position.x) < 0)
            {
                spriteRenderer.flipX = true;
            }
            else
            {
                spriteRenderer.flipX = false;
            }
        }
    }
}
