using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementScript : MonoBehaviour
{
    public float speed;
    private Rigidbody2D rigibody;
    private Animator animator;


    // Start is called before the first frame update
    void Start()
    {
        // Sets the rigidbody 
        rigibody = GetComponent<Rigidbody2D>();

        // Sets the animator to the first childs animator
        animator = transform.GetChild(0).GetComponent<Animator>();
    
    }

    public void Move()
    {
        // Gets the horizontal input 
        float horizontal = Input.GetAxisRaw("Horizontal");

        if (Input.GetAxisRaw("Horizontal") != 0)
        {
            // Sets players velocity 
            rigibody.velocity = new Vector2(Vector2.right.x * horizontal * speed * Time.deltaTime, rigibody.velocity.y);
            
            // Rotates the player
            transform.localScale = new Vector3(horizontal, 1, 1);

            // Switches to walk-animation
            animator.SetBool("isWalking", true);
        }
        else 
        {
            // Sets the velocity to zero and keeps the vertical speed
            rigibody.velocity = new Vector2(0, rigibody.velocity.y);

            // Switches to idle-animation
            animator.SetBool("isWalking", false);
        }
    }
  
    void FixedUpdate()
    {
        // Calls the Move() method
        Move();
    }
}
