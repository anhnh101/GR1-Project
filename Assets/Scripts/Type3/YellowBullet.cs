using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class YellowBullet : MonoBehaviour
{

    public float speed;
    public float existTime;

    private Rigidbody2D bullet;

    private void Awake()
    {
        bullet = GetComponent<Rigidbody2D>();
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        bullet.velocity = new Vector3(speed, 0f, 0f);
        DestroyBullet();
    }

    private void DestroyBullet()
    {
        if (gameObject.name == "Yellow Bullet(Clone)")
        {
            Destroy(gameObject, existTime);
        }
    }
}
