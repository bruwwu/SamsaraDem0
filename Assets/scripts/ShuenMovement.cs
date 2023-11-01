using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShuenMovement : MonoBehaviour
{
    public float moveSpeed;
    public Rigidbody2D rb;
    private Vector2 moveInput;
    bool facingRight = true;
    public Animator animator;

    // Start is called before the first frame update
    void Start()
    {
       
    }


    void FixedUpdate()
    {
        moveInput.x = Input.GetAxisRaw("Horizontal");
        moveInput.y = Input.GetAxisRaw("Vertical");

        rb.MovePosition(rb.position + moveInput.normalized * moveSpeed * Time.fixedDeltaTime);

        animator.SetFloat("Horizontal", moveInput.x);
        animator.SetFloat("Vertical", moveInput.y);
        animator.SetFloat("Speed", moveInput.sqrMagnitude);

        if (moveInput.x != 0)
        {
            rb.AddForce(new Vector2(moveInput.x * moveSpeed, 0f));
        }
        if(moveInput.y != 0)
        {
            rb.AddForce(new Vector2(moveInput.y * moveSpeed, 0f));
        }
        if (moveInput.x > 0 && !facingRight)
        {
            Flip();
        }
        if (moveInput.x < 0 && facingRight)
        {
            Flip();
        }
       
    }

        void Flip()
        {
            Vector3 currentScale = gameObject.transform.localScale;
            currentScale.x *= -1;
            gameObject.transform.localScale = currentScale;

            facingRight = !facingRight;
        }
    }