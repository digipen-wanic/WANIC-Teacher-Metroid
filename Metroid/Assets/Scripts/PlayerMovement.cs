using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 2.0f;
    public float accelGround = 1.0f;
    public float accelAir = 0.5f;
    public float groundFriction = 0.85f;
    public float airResistance = 0.99f;
    public float jumpSpeed = 10.0f;

    bool grounded = false;
    bool jumped = false;
    bool collisionLeft = false;
    bool collisionRight = false;

    Rigidbody2D body = null;

    // Start is called before the first frame update
    void Start()
    {
        body = this.gameObject.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        var movement = body.velocity;

        // -----------------------------------------------------------

        // Horizontal movement
        var hAxis = Input.GetAxis("Horizontal");

        // Drag
        if (grounded)
            movement.x *= groundFriction;
        else
            movement.x *= airResistance;

        // Increase horizontal velocity if not colliding
        if ((hAxis > 0.0f && !collisionRight) || (hAxis < 0.0f && !collisionLeft))
        {
            if (grounded)
                movement.x += hAxis * accelGround;
            else
                movement.x += hAxis * accelAir;
        }
        else
        {
            movement.x -= hAxis * accelGround;
        }

        // Artificial velocity cap
        movement.x = movement.x > 0.0f ? Mathf.Min(movement.x, moveSpeed)
            : Mathf.Max(movement.x, -moveSpeed);

        // -----------------------------------------------------------

        // Jump
        if (grounded && !jumped && Input.GetAxis("Jump") > 0.0f)
        {
            movement.y += jumpSpeed;

            // Reset grounded flag
            grounded = false;
            jumped = true;
        }

        // Reset jump
        if(Input.GetAxis("Jump") == 0.0f)
            jumped = false;

        body.velocity = movement;
    }

    void FixedUpdate()
    {
        if(collisionLeft)
        {
            // Push towards right
            body.AddForce(new Vector2(0.2f, 0.0f), ForceMode2D.Impulse);
            collisionLeft = false;
        }

        if(collisionRight)
        {
            // Push towards left
            body.AddForce(new Vector2(-0.2f, 0.0f), ForceMode2D.Impulse);
            collisionRight = false;
        }
    }

    void OnCollisionEnter2D(Collision2D collision) 
    {
        // If colliding on bottom
        if(collision.GetContact(0).normal.Equals(new Vector2(0.0f,1.0f)))
        {
            grounded = true;
        }
        // If colliding on left
        else if (collision.GetContact(0).normal.Equals(new Vector2(1.0f, 0.0f)))
        {
            collisionLeft = true;
        }
        // Else, if colliding on right
        else if (collision.GetContact(0).normal.Equals(new Vector2(-1.0f, 0.0f)))
        {
            collisionRight = true;
        }
    }

    void OnCollisionStay2D(Collision2D collision)
    {
        // If colliding on left
        if (collision.GetContact(0).normal.Equals(new Vector2(1.0f, 0.0f)))
        {
            collisionLeft = true;
        }
        // Else, if colliding on right
        else if (collision.GetContact(0).normal.Equals(new Vector2(-1.0f, 0.0f)))
        {
            collisionRight = true;
        }
    }
}
