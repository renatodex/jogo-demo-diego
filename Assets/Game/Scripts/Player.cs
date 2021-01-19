using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Rigidbody2D rigidBody2D;
    private SpriteRenderer spriteRenderer;
    private Animator animator;

    public float speed;
    public float jumpForce;
    private Vector2 velocity;

    // Start is called before the first frame update
    void Start()
    {
        rigidBody2D = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        float horizontalMovement = Input.GetAxisRaw("Horizontal");

        Vector2 newVelocity = new Vector2(
            speed * horizontalMovement,
            rigidBody2D.velocity.y
        );

        rigidBody2D.velocity = newVelocity;

        if (Input.GetKeyDown(KeyCode.Space)) {
            Vector2 jumpForceVector = new Vector2(0f, jumpForce);
            rigidBody2D.AddForce(jumpForceVector);
        }

        spriteRenderer.flipX = (horizontalMovement < 0);

        animator.SetBool("movement", horizontalMovement != 0);
    }
}
