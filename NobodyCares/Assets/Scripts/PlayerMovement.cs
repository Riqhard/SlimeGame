using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PlayerMovement : MonoBehaviour
{
    public event Action OnPlayerFlip;

    public float moveSpeed = 10f;
    Vector2 movement;
    private bool canMove = true;

    Rigidbody2D rb;
    public Animator animator;

    [HideInInspector]
    public static PlayerMovement instance;

    public Transform graphixTransform;



    private bool m_FacingRight = true;

    public void Awake()
    {
        instance = this;
    }

    void Start()
    {
        if (FindObjectsOfType<PlayerMovement>().Length > 1)
        {
            Destroy(this.gameObject);
        }

        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {

        if (canMove)
        {
            movement.x = Input.GetAxisRaw("Horizontal");
            movement.y = Input.GetAxisRaw("Vertical");
        }
        animator.SetFloat("Speed", movement.magnitude);
    }

    private void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
        
        // If the input is moving the player right and the player is facing left...
        if (movement.x > 0 && !m_FacingRight)
        {
            // ... flip the player.
            Flip();
        }
        // Otherwise if the input is moving the player left and the player is facing right...
        else if (movement.x < 0 && m_FacingRight)
        {
            // ... flip the player.
            Flip();
        }
    }

    public void TeleportTo(Vector2 position)
    {
        transform.position = position;
    }
    public void StopMovement()
    {
        canMove = false;
        movement.x = 0;
        movement.y = 0;
    }
    public void AlloweMovement()
    {
        canMove = true;
    }

    private void Flip()
    {
        if (OnPlayerFlip != null)
        {
            OnPlayerFlip();
        }
        //GetComponentInChildren<FollowMouse>().Flip();
        // Switch the way the player is labelled as facing.
        m_FacingRight = !m_FacingRight;
        graphixTransform.Rotate(0f, 180f, 0f);
    }





    
}

