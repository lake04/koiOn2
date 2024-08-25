using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float sprintSpeed = 8f;
    private float currentSpeed;
    public float jumpPower = 10f;

    private bool isGrounded;
    private float curTime;
    public Transform pos;
    public Transform pos2;
    public Vector2 boxSize;

    private Rigidbody2D rb;
    private SpriteRenderer spriteRenderer;

    void Start()
    {
        currentSpeed = moveSpeed;
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        Jump();
        Attack();
        UpdateCooldown();
    }

    private void FixedUpdate()
    {
        Move();
    }

    private void Move()
    {
        float h = Input.GetAxisRaw("Horizontal");
        Vector2 dir = new Vector2(h, 0f).normalized;
        rb.velocity = new Vector2(dir.x * currentSpeed, rb.velocity.y);
        spriteRenderer.flipX = dir.x < 0;

        currentSpeed = Input.GetKey(KeyCode.LeftShift) ? sprintSpeed : moveSpeed;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = false;
        }
    }

    private void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpPower);
            isGrounded = false; // Prevent further jumps until grounded again
        }
    }

    private void Attack()
    {
        if (Input.GetKeyDown(KeyCode.RightShift) && curTime <= 0)
        {
            Vector2 attackPosition = spriteRenderer.flipX ? pos2.position : pos.position;
            Debug.Log(spriteRenderer.flipX ? "Attacking Right" : "Attacking Left");
            Collider2D[] colliders = Physics2D.OverlapBoxAll(attackPosition, boxSize, 0);

            foreach (Collider2D collider in colliders)
            {
                Debug.Log(collider.tag);
            }

            curTime = 3f;
        }
    }

    private void UpdateCooldown()
    {
        if (curTime > 0)
        {
            curTime -= Time.deltaTime;
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireCube(pos.position, boxSize);

        Gizmos.color = Color.blue;
        Gizmos.DrawWireCube(pos2.position, boxSize);
    }
}