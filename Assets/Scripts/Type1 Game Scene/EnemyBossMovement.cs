using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBossMovement : MonoBehaviour
{
    private Rigidbody2D rb;
    private GameObject player;
    private Animator animator;
    [SerializeField] private float moveSpeed = 5.0f;
    private float directionX;

    private enum MovementState { idle, walk }

    private float waitTime = 2.0f;
    private SpriteRenderer sprite;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        player = GameObject.Find("Player");
        sprite = GetComponent<SpriteRenderer>();
        if (gameObject.CompareTag("Rock"))
        {
            animator = GetComponent<Animator>();
        }
        StartCoroutine(GenerateDirection());
    }

    // Update is called once per frame
    void Update()
    {
        if (gameObject.CompareTag("Rock"))
        {
            UpdateAnimatonState();
        }
        UpdateDirection();
        Moving();
    }
    private void UpdateDirection()
    {
        if (directionX > 0)
        {
            sprite.flipX = true;
        }
        else
        {
            sprite.flipX = false;
        }
    }

    IEnumerator GenerateDirection()
    {
        while (true)
        {
            yield return new WaitForSeconds(waitTime / 2);
            directionX = Random.Range(-1f, 1f);
            yield return new WaitForSeconds(waitTime);
            directionX = 0;
            //Debug.Log(directionX);
        }
    }


    private void Moving()
    {
        rb.velocity = new Vector2(directionX * moveSpeed, rb.velocity.y);
    }

    private void UpdateAnimatonState()
    {
        MovementState state;
        if (directionX < 0 || directionX > 0)
        {
            state = MovementState.walk;
        }

        else
        {
            state = MovementState.idle;
        }
        animator.SetInteger("state", (int) state);
    }
}
