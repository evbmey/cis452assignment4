using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Player : MonoBehaviour, ITakeDamage
{
    [SerializeField]
    private int initialHealth;
    private new Rigidbody2D rigidbody;

    public int Health { get; private set; }

    public void Awake()
    {
        Health = initialHealth;
        rigidbody = GetComponent<Rigidbody2D>();
    }

    public void TakeDamage(int damage)
    {
        Health -= damage;

        if (Health <= 0)
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
