using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveSprite : MonoBehaviour
{
    public float moveSpeed = 5f; // Speed of movement
    private SpriteRenderer spriteRenderer;
    private Animator animator;

    void Start()
    {
        // Get the SpriteRenderer and Animator components attached to the GameObject
        spriteRenderer = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        // Get input from WASD keys
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        // Create a movement vector
        Vector2 movement = new Vector2(moveHorizontal, moveVertical);

        // Move the GameObject
        transform.Translate(movement * moveSpeed * Time.deltaTime);

        // Flip the sprite based on horizontal movement
        if (moveHorizontal < 0)
        {
            // Moving left
            spriteRenderer.flipX = true;
        }
        else if (moveHorizontal > 0)
        {
            // Moving right
            spriteRenderer.flipX = false;
        }

        // Check if the character is moving
        bool isMoving = movement.magnitude > 0;

        // Set the animator's parameters
        animator.SetBool("isMoving", isMoving);
    }
}
