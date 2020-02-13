using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackHandler : MonoBehaviour
{
    private const float AttackSpeedFactor = 0.1f;
    private const float AttackArcFactor = 0.5f;

    private Weapon equippedWeapon;

    private bool canAttack = true;

    public Vector3 Position { get => gameObject.transform.position; }
    public Vector3 Forward { get => gameObject.transform.forward; }

    public int Power { get => equippedWeapon.Power; }
    public int Speed { get => equippedWeapon.Speed; }
    public int Range { get => equippedWeapon.Range; }
    public string Name { get => equippedWeapon.Name; }

    public void Attack()
    {
        if (!canAttack) return;

        canAttack = false;
        Invoker.InvokeWithDelay<bool>(Speed * AttackSpeedFactor, (newBool) => canAttack = newBool, true);

        RaycastHit2D[] collisions = Physics2D.CircleCastAll(Position, Range, Forward);
        foreach (RaycastHit2D collision in collisions)
        {
            Vector2 vectorToCollision = Vector3.Normalize(collision.transform.position - Position);
            if (Vector2.Dot(vectorToCollision, Forward) > AttackArcFactor) // 90 degree arc
            {
                // apply damage / knockback
            }
        }
    }



}
