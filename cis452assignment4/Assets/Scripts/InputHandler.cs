using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(MovementController), typeof(AttackHandler))]
public class InputHandler : MonoBehaviour
{
    private MovementController movementController;
    private AttackHandler attackHandler;

    private float xMovement;
    private bool jumping, attacking, facingLeft;

    public void Awake()
    {
        movementController = GetComponent<MovementController>();
        attackHandler = GetComponent<AttackHandler>();
        jumping = false;
        attacking = false;
    }

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0)) 
        { 
            attacking = true;
        }
        if (Input.GetKeyDown(KeyCode.Space))
        { 
            jumping = true;
        }

        xMovement = Input.GetAxis("Horizontal");
        facingLeft = (Camera.main.ScreenToWorldPoint(Input.mousePosition).x - gameObject.transform.position.x) < 0;
    }

    public void FixedUpdate()
    {
        if (attacking)
        {
            attackHandler.TryAttack(facingLeft);
            attacking = false;
        }
        if (jumping)
        {
            movementController.Jump();
            jumping = false;
        }

        movementController.Move(xMovement * Time.fixedDeltaTime);
    }
}
