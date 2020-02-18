/*
* Evan Meyer
* InputHandler.cs
* CIS452 Assignment 4
*/

using UnityEngine;

[RequireComponent(typeof(MovementController), typeof(AttackHandler))]
public class InputHandler : MonoBehaviour
{
    private MovementController movementController;
    private AttackHandler attackHandler;

    private float xMovement;
    public bool IsJumping { get; private set; }
    public bool IsAttacking { get; private set; }
    public bool IsFacingLeft { get => (Camera.main.ScreenToWorldPoint(Input.mousePosition).x - gameObject.transform.position.x) < 0; }

    public void Awake()
    {
        movementController = GetComponent<MovementController>();
        attackHandler = GetComponent<AttackHandler>();
        IsJumping = false;
        IsAttacking = false;
    }

    public void Update()
    {
        if (Input.GetKey(KeyCode.Mouse0)) 
        { 
            IsAttacking = true;
        }

        if (Input.GetKeyDown(KeyCode.Space))
        { 
            IsJumping = true;
        }

        xMovement = Input.GetAxis("Horizontal");
    }

    public void FixedUpdate()
    {
        if (IsAttacking)
        {
            attackHandler.TryAttack(IsFacingLeft);
            IsAttacking = false;
        }

        if (IsJumping)
        {
            movementController.Jump();
            IsJumping = false;
        }

        movementController.Move(xMovement * Time.fixedDeltaTime);
    }
}
