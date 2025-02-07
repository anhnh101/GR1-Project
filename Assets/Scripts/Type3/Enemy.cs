using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed;
    public float existTime;
    [Header("Shooting Time Range")]
    public float min = 0.5f;
    public float max = 1.5f;

    private Rigidbody2D enemyRb;

    [SerializeField] private GameObject bullet;

    private void Awake()
    {
        enemyRb = GetComponent<Rigidbody2D>();
    }
    // Start is called before the first frame update
    private void Start()
    {
        StartCoroutine(EnemyShoot());
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        if (enemyRb.bodyType != RigidbodyType2D.Static)
        {
            enemyRb.velocity = new Vector3(-speed, 0f, 0f);
        }
        DestroyEnemy();
    }

    IEnumerator EnemyShoot()
    {
        yield return new WaitForSeconds(Random.Range(min, max));

        Vector3 temp = transform.position;
        temp.x -= 1.3f;
        temp.y -= 0.6f;
        Instantiate(bullet, temp, Quaternion.identity);
        StartCoroutine(EnemyShoot());
    }

    private void DestroyEnemy()
    {
        if (gameObject.name == "Enemy(Clone)")
        {
            Destroy(gameObject, existTime);
        }
    }
}
