using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public float moveSpeed = 5f;

    public Rigidbody2D rb;
    public Animator animator;
    Vector2 movement;

    // Update is called once per frame
    void Update()
    {
        movement = new Vector2 (Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        
        // Combining x and y movement to initiate animation
        // Not ideal, might fix later on
        animator.SetFloat("Speed", Mathf.Abs(movement.x) + Mathf.Abs(movement.y));
        
        if (movement.x < 0)
        {
            transform.rotation = Quaternion.Euler(0,180,0);
        }
        else if (movement.x > 0)
        {
            transform.rotation = Quaternion.Euler(0,0,0);
        }
        
        
    }

    void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
    }
}
