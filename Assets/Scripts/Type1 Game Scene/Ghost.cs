using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ghost : MonoBehaviour
{
    private GameObject player;
    private SpriteRenderer spriteRenderer;
    [SerializeField] private float speed = 2.5f;
    private float waitTime = 3f;
    private Vector2 randomPos;
    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        player = GameObject.Find("Player");
        StartCoroutine(GeneratePos());
    }

    // Update is called once per frame
    void Update()
    {
        
        float direction = Vector2.Distance(transform.position ,player.transform.position);
        if (direction < 10)
        {
            UpdateDirection(player.transform.position.x);
            transform.position = Vector2.MoveTowards(transform.position, player.transform.position, speed * Time.deltaTime);
        }
        else
        {
            UpdateDirection(randomPos.x);
            Moving();
        }
        
    }

    IEnumerator GeneratePos()
    {
        while (true)
        {
            yield return new WaitForSeconds(waitTime / 2);
            randomPos = new Vector2(Random.Range(-12f, 12f), Random.Range(-5f, 6f));
            yield return new WaitForSeconds(waitTime);
            randomPos = transform.position;
            //Debug.Log(randomPos);
        }
    }

    private void Moving()
    {
        transform.position = Vector2.MoveTowards(transform.position, randomPos, speed * Time.deltaTime);
    }

    private void UpdateDirection(float positionX)
    {
        if (positionX < 0)
        {
            if ((positionX - transform.position.x) < 0)
            {
                spriteRenderer.flipX = false;
            }
            else
            {
                spriteRenderer.flipX = true;
            }
        }
        else
        {
            if ((positionX - transform.position.x) < 0)
            {
                spriteRenderer.flipX = false;
            }
            else
            {
                spriteRenderer.flipX = true;
            }
        }
    }

}
