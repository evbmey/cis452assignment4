using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D), typeof(BoxCollider2D))]
public class MovementController : MonoBehaviour
{
    [SerializeField] private float movementSpeed;
    [SerializeField] private float jumpSpeed;

    private new Rigidbody2D rigidbody;
    private bool jumping;

    public void Awake()
    {
        rigidbody = GetComponent<Rigidbody2D>();
        jumping = false;
    }

    public void Move(float x)
    {
        Vector2 movement = Vector2.right * x * movementSpeed;
        rigidbody.MovePosition(rigidbody.position + movement);
    }

    public void Jump()
    {
        jumping = true;

        if (rigidbody.velocity.y == 0)
        {
            rigidbody.velocity = Vector2.up * jumpSpeed;
        }
    }

    public void FixedUpdate()
    {
        if (rigidbody.velocity.y > 0)
        {
            if (jumping) rigidbody.gravityScale = 5f;
            else rigidbody.gravityScale = 7.5f;
        }
        else
        {
            rigidbody.gravityScale = 10f;
        }
    }
}
