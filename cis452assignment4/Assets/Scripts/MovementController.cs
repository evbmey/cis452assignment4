using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class MovementController : MonoBehaviour
{
    [SerializeField]
    private float accelerationRate;
    [SerializeField]
    private float maxSpeed;
    private new Rigidbody2D rigidbody;

    public Vector2 CurrentVelocity { get => rigidbody.velocity; set => rigidbody.velocity = value; }
    public float CurrentSpeed { get => rigidbody.velocity.magnitude; }

    public void Awake()
    {
        rigidbody = GetComponent<Rigidbody2D>();
    }

    public void Update()
    {
        Vector2 direction = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical")).normalized;

        CurrentVelocity += direction * accelerationRate;
        // Mathf.Clamp(-maxSpeed, CurrentSpeed, maxSpeed);

    }
}
