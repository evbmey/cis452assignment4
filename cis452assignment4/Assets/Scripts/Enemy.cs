using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D), typeof(Collider2D), typeof(MovementController))]
public class Enemy : MonoBehaviour, ITakeDamage, ITakeKnockback
{
    [SerializeField] private int initialHealth;
    [SerializeField] private Transform playerTransform;
    [SerializeField] private int power;

    private new Rigidbody2D rigidbody;
    private MovementController movementController;

    private const float StunFactor = 0.1f;
    private const float AttackKnockbackMultiplier = 500f;

    public int Power { get => power; }
    public int Health { get; private set; }
    public float StunCooldown { get; private set; }

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
            playerTransform = FindObjectOfType<Player>().transform;
        }
    }

    public void FixedUpdate()
    {
        if (StunCooldown > 0)
        {
            StunCooldown -= Time.fixedDeltaTime;
        }
        else
        {
            Vector3 direction = Vector3.Normalize(playerTransform.position - gameObject.transform.position);
            movementController.Move(direction.x * Time.fixedDeltaTime);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        ITakeDamage objectToDamage;
        if (collision.gameObject.TryGetComponent<ITakeDamage>(out objectToDamage))
        {
            objectToDamage.TakeDamage(Power);
        }

        ITakeKnockback objectToKnockback;
        if (collision.gameObject.TryGetComponent<ITakeKnockback>(out objectToKnockback))
        {
            Vector3 knockbackDirection = Vector3.Normalize(collision.transform.position - transform.position);
            objectToKnockback.TakeKnockback(knockbackDirection * Power * AttackKnockbackMultiplier);
        }
    }

    public void TakeDamage(int damage)
    {
        Health -= damage;
        StunCooldown = StunFactor * damage;

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
