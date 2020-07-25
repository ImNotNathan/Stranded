using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    

    public float moveSpeed = 5f;

    public float sprintSpeed = 10f;

    public Rigidbody2D rb;

    Vector2 movement;

    // Update is called once per frame
    void Update()
    {
        // Input

        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        if (Input.GetKey(KeyCode.LeftShift))
        {
            moveSpeed = sprintSpeed;
        }
        else
        {
            moveSpeed = 5f;
        }


    }

    void FixedUpdate()
    {
        // Movement

        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);

        
            
            

    }
}