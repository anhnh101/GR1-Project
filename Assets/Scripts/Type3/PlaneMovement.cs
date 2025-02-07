using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaneMovement : MonoBehaviour,IDataPersistence
{
    private Rigidbody2D rb;
    private Animator animator;

    private float directionX = 0f;
    private float directionY = 0f;
    [SerializeField] private float moveSpeed = 7f;
    [SerializeField] private bool isPlayer = true;

    [SerializeField] private GameObject bullet = null;
    private bool canShoot = true;

    private enum MovementState { idle }
    [SerializeField] private GameObject pauseUI;

    // Start is called before the first frame update
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        UpdateAnimationState();
        if (isPlayer)
        {
            if (!pauseUI.activeSelf)
            {
                if (rb.bodyType != RigidbodyType2D.Static)
                {
                    directionX = Input.GetAxis("Horizontal");
                    rb.velocity = new Vector2(directionX * moveSpeed, rb.velocity.y);
                    directionY = Input.GetAxis("Vertical");
                    rb.velocity = new Vector2(rb.velocity.x, directionY * moveSpeed);
                    
                }
            }
        }
    }

    private void Update()
    {
        if(Input.GetKey(KeyCode.Space)) 
        {
            if (canShoot)
            {
                StartCoroutine(Shoot());
            }
        }
    }

    public void LoadData(GameData data)
    {
        this.transform.position = data.playerPosition;
    }

    public void SaveData(GameData data)
    {
        data.playerPosition = this.transform.position;
    }
    private void UpdateAnimationState()
    {
        MovementState state;
        state = MovementState.idle;
        animator.SetInteger("state", (int)state);
    }

    IEnumerator Shoot()
    {
        canShoot = false;

        Vector3 temp = transform.position;
        temp.x += 1.3f;
        temp.y -= 0.6f;
        Instantiate(bullet, temp, Quaternion.identity);
        yield return new WaitForSeconds(0.5f);
        canShoot = true;
    }
}
