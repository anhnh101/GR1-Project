using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SubmarineMovement : MonoBehaviour
{
    private Rigidbody2D rb;
    private Animator animator;
    //private SpriteRenderer sprite;
    //private Collider2D colld;

    private enum MovementState { idle }

    [SerializeField] private float force = 4f;
    [SerializeField] private AudioSource upSFX;
    [SerializeField] private GameObject pauseUI;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        //sprite = GetComponent<SpriteRenderer>();
        //colld = GetComponent<Collider2D>();
    }

    // Update is called once per frame
    private void Update()
    {
        if (!pauseUI.activeSelf)
        {
            if (rb.bodyType != RigidbodyType2D.Static)
            {
                UpdateAnimationState();
                if (Input.GetKeyDown(KeyCode.Space) == true)
                {
                    upSFX.Play();
                    rb.velocity = Vector2.down * force;
                }
            }
        }
    }

    private void UpdateAnimationState()
    {
        MovementState state;

        state = MovementState.idle;
        animator.SetInteger("state", (int)state);
    }
}
