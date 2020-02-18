using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D), typeof(Collider2D), typeof(MovementController))]
public class Enemy : MonoBehaviour, ITakeDamage, ITakeKnockback
{
    [SerializeField] private int initialHealth;
    [SerializeField] private Transform playerTransform;

    private new Rigidbody2D rigidbody;
    private MovementController movementController;

    public int Health { get; private set; }

    public void Awake()
    {
        Health = initialHealth;
        rigidbody = GetComponent<Rigidbody2D>();
        movementController = GetComponent<MovementController>();
    }

    public void Start()
    {
        if(playerTransform == null)
        {
            playerTransform = GameObject.FindWithTag("Player").transform;
        }
    }

    public void FixedUpdate()
    {
        Vector3 direction = Vector3.Normalize(playerTransform.position - gameObject.transform.position);
        movementController.Move(direction.x * Time.fixedDeltaTime);
    }

    public void TakeDamage(int damage)
    {
        Health -= damage;
        if(Health <= 0)
        {
            Die();
        }
    }

    public void TakeKnockback(Vector2 knockback)
    {
        knockback.y = Mathf.Abs(knockback.y) * 5f;
        rigidbody.AddForce(knockback);
    }

    public void Die()
    {
        Destroy(gameObject);
    }
}
