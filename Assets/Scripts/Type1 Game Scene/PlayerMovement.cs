using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour, IDataPersistence
{
    private Rigidbody2D rb;
    private Animator animator;
    private SpriteRenderer sprite;
    private BoxCollider2D colld;

    private float directionX = 0f;
    private Vector2 spawnPos;
    public bool isRight;
    public bool isShoot = false;
    [SerializeField] private float moveSpeed = 7f;
    [SerializeField] private float jumpForce = 16f;

    [SerializeField] private bool isBossStage = false;
    [SerializeField] private float attackCooldown;
    private float cooldownTimer = Mathf.Infinity;
    //[SerializeField] private GameObject bulletPrefab = null;
    //private Bullet bullet;
    private float dirIndex = 1f;
    [SerializeField] private GameObject[] bullets = null;

    private enum MovementState {idle, walk, jump, fall, idleToShoot, walkToShoot}

    [SerializeField] private LayerMask jumpableGround;

    [SerializeField] private AudioSource jumpSFX;

    [SerializeField] private GameObject pauseUI = null;

    public void LoadData(GameData data)
    {
        this.transform.position = data.playerPosition;
        //Debug.Log(transform.position);
    }

    public void SaveData(GameData data)
    {
        data.playerPosition = this.transform.position;
    }

    // Start is called before the first frame update
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        sprite = GetComponent<SpriteRenderer>();
        colld = GetComponent<BoxCollider2D>();
        spawnPos = new Vector2(transform.position.x + 0.8f, transform.position.y);
        //bullet = GameObject.FindGameObjectWithTag("Player Bullet").GetComponent<Bullet>();
    }

    // Update is called once per frame
    private void Update()
    {
        if (!pauseUI.activeSelf)
        {
            if (rb.bodyType != RigidbodyType2D.Static)
            {
                SetPlayerDirection();
                directionX = Input.GetAxis("Horizontal");
                
                rb.velocity = new Vector2(directionX * moveSpeed, rb.velocity.y);
                UpdateAnimationState();
                if (Input.GetButtonDown("Jump") && IsGrounded())
                    {
                        jumpSFX.Play();
                        rb.velocity = new Vector2(rb.velocity.x, jumpForce);
                    }
                if (isBossStage)
                {
                    if (Input.GetKeyDown(KeyCode.L) && cooldownTimer > attackCooldown)
                    {
                        //launch the bullet
                        isShoot = true;
                        Shoot();
                    }
                    cooldownTimer += Time.deltaTime;
                }
            }
        }
        
    }

    private void UpdateAnimationState()
    {
        MovementState state;

        if (directionX > 0f)
        {
            
            //if (Input.GetKeyDown(KeyCode.L))
            //{
            //    state = MovementState.walkToShoot;
            //    sprite.flipX = false;
            //}
            //else
            {
                state = MovementState.walk;
                sprite.flipX = false;
            }

        }

        else if (directionX < 0f)
        {
            //if (Input.GetKeyDown(KeyCode.L))
            //{
            //    state = MovementState.walkToShoot;
            //    sprite.flipX = true;
            //}
            //else
            {
                state = MovementState.walk;
                sprite.flipX = true;
            }
            
        }

        else
        {
            //if (Input.GetKeyDown(KeyCode.L))
            //{
            //    state = MovementState.idleToShoot;
            //}
            //else
            {
                state = MovementState.idle;
            }
            
        }

        if (rb.velocity.y > .1f)
        {
            //if (Input.GetKeyDown(KeyCode.L))
            //{
            //    state = MovementState.walkToShoot;
            //}
            //else
            {
                state = MovementState.jump;
            }

        }

        if (rb.velocity.y < -.1f)
        {
            //if (Input.GetKeyDown(KeyCode.L))
            //{
            //    state = MovementState.walkToShoot;
            //}
            //else
            {
                state = MovementState.fall;
            }    
        }

        animator.SetInteger("state", (int) state);
    }

    private void UpdateShootAnimationState()
    {
        MovementState state;
        if (directionX > 0 || directionX < 0 || rb.velocity.y > .1f || rb.velocity.y < -.1f)
        {
            state = MovementState.walkToShoot;
        }
        else
        {
            state = MovementState.idleToShoot;
        }
        animator.SetInteger("state", (int)state);
    }
    private bool IsGrounded()
    {
        return Physics2D.BoxCast(colld.bounds.center, colld.bounds.size, 0f, Vector2.down, .1f, jumpableGround);
    }

    private Vector2 UpdateSpawnPos()
        {
            if (isRight)
            {
                spawnPos = new Vector2(transform.position.x + 0.8f, transform.position.y);
            }
            if (!isRight)
            {
                spawnPos = new Vector2(transform.position.x - 0.8f, transform.position.y);
            }
            return spawnPos;
        }
    private bool SetPlayerDirection()
    {
        if (directionX > 0)
        {
            isRight = true;
            dirIndex = 1f;
        }
        if (directionX < 0)
        {
            isRight = false;
            dirIndex = -1f;
        }
        //Debug.Log(isRight);
        return isRight;
    }
    private void Shoot()
    {
        UpdateShootAnimationState();
        cooldownTimer = 0;
        bullets[FindBullet()].transform.position = UpdateSpawnPos();
        bullets[FindBullet()].GetComponent<PlayerBullet>().SetDirection(dirIndex);
        //Instantiate(bulletPrefab, UpdateSpawnPos(), bulletPrefab.transform.rotation);
        isShoot = false;
    }

    private int FindBullet()
    {
        for (int i = 0; i < bullets.Length; i++)
        {
            if (!bullets[i].activeInHierarchy)
            {
                return i;
            }
        }
        return 0;
    }
}