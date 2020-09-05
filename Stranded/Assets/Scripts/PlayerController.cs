using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    
    public float NonSprint = 10f;

    private float moveSpeed = 10f;

    public float sprintSpeed = 20f;

    public Rigidbody2D rb;

    Vector2 movement;

    Vector3 PlayerScale;
    private void Start()
    {
        PlayerScale = transform.localScale;
    }

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
            moveSpeed = NonSprint;
        }

        if (movement.x > 0) transform.localScale = PlayerScale;
        if (movement.x < 0) transform.localScale = new Vector3(-PlayerScale.x, PlayerScale.y, PlayerScale.z);
    }

    void FixedUpdate()
    {
        // Movement

        // rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
        rb.velocity = new Vector2(movement.x, movement.y) * moveSpeed;
        transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.y);
    }
}