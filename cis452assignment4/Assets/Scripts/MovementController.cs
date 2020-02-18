/*
* Evan Meyer
* MovementController.cs
* CIS452 Assignment 4
*/

using UnityEngine;

[RequireComponent(typeof(Rigidbody2D), typeof(Collider2D))]
public class MovementController : MonoBehaviour
{
    [SerializeField] private float movementSpeed;
    [SerializeField] private float jumpSpeed;

    private new Rigidbody2D rigidbody;
    private new Collider2D collider;

    private const float raycastLength = 0.1f;

    private float distanceFromColliderCenter;

    public bool IsJumping { get; private set; }
    public bool IsGrounded 
    {
        get
        {
           RaycastHit2D hit = Physics2D.Raycast(gameObject.transform.position, -Vector2.up, distanceFromColliderCenter * raycastLength);
            return hit != null;
        }
    }

    public void Awake()
    {
        rigidbody = GetComponent<Rigidbody2D>();
        collider = GetComponent<Collider2D>();

        IsJumping = false;
    }

    public void Start()
    {
        distanceFromColliderCenter = collider.bounds.extents.y ;
    }

    public void Move(float x)
    {
        Vector2 movement = Vector2.right * x * movementSpeed;
        rigidbody.MovePosition(rigidbody.position + movement);
    }

    public void Jump()
    {
        IsJumping = true;

        Debug.Log("try jump");

        if (IsGrounded)
        {
            Debug.Log("grounded");

            rigidbody.velocity += Vector2.up * jumpSpeed;
        }
    }

    public void FixedUpdate()
    {
        if (rigidbody.velocity.y > 0)
        {
            if (IsJumping) rigidbody.gravityScale = 5f;
            else rigidbody.gravityScale = 7.5f;
        }
        else
        {
            rigidbody.gravityScale = 10f;
        }
    }
}
