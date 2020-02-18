/*
* Evan Meyer
* AttackHandler.cs
* CIS452 Assignment 4
*/

using UnityEngine;

public class AttackHandler : MonoBehaviour
{
    [SerializeField]
    private WeaponObject weaponObject;

    private const float AttackSpeedMultiplier = 75f;
    private const float FullSwingAngle = 120f;
    private float currentAngle;
    private bool swingingLeft;

    public bool TryAttack(bool facingLeft)
    {
        if (weaponObject.gameObject.activeSelf)
        {
            return false;
        }
        else
        {
            Attack(facingLeft);
            return true;
        }
    }

    public void Attack(bool facingLeft)
    {
        weaponObject.gameObject.SetActive(true);
        currentAngle = 0f;
        swingingLeft = facingLeft;
    }

    public void FixedUpdate()
    {
        if (weaponObject.gameObject.activeSelf)
        {
            bool rotating = true;

            float angleIncrement = weaponObject.Speed * AttackSpeedMultiplier * Time.fixedDeltaTime;
            currentAngle += angleIncrement;

            if (currentAngle >= FullSwingAngle)
            {
                angleIncrement -= currentAngle - FullSwingAngle;
                rotating = false;
            }

            if (!swingingLeft) angleIncrement = -angleIncrement;

            weaponObject.gameObject.transform.RotateAround(gameObject.transform.position, Vector3.forward, angleIncrement);
            weaponObject.gameObject.SetActive(rotating);
        }
    }

}
