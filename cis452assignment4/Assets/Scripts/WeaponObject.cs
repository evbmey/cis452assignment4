/*
* Evan Meyer
* WeaponObject.cs
* CIS452 Assignment 4
*/

using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
public class WeaponObject : MonoBehaviour
{
    [SerializeField]
    private Transform transformToOrbit;
    private Weapon weapon;
    private Vector3 startingPosition;
    private Quaternion startingRotation;

    private const float KnockbackMultiplier = 100f;

    public int Power { get => weapon.Power; }
    public int Speed { get => weapon.Speed; }
    public string Name { get => weapon.Name; }

    public void Awake()
    {
        startingPosition = gameObject.transform.localPosition;
        startingRotation = gameObject.transform.localRotation;
        Equip<Stick>();
    }

    public void Start()
    {
        gameObject.SetActive(false);
    }

    public void OnDisable()
    {
        gameObject.transform.localPosition = startingPosition;
        gameObject.transform.localRotation = startingRotation;
    }

    public void OnTriggerEnter2D(Collider2D collider)
    {
        ITakeDamage objectToDamage;
        if (collider.gameObject.TryGetComponent<ITakeDamage>(out objectToDamage))
        {
            objectToDamage.TakeDamage(Power);
        }

        ITakeKnockback objectToKnockback;
        if (collider.gameObject.TryGetComponent<ITakeKnockback>(out objectToKnockback))
        {
            Vector3 knockbackDirection = Vector3.Normalize(collider.transform.position - transformToOrbit.position);
            objectToKnockback.TakeKnockback(knockbackDirection * Power * KnockbackMultiplier);
        }
    }

    public void Equip(Weapon newWeapon)
    {
        weapon = newWeapon;
    }

    public void Equip<TWeapon>() where TWeapon : Weapon, new()
    {
        Equip(new TWeapon());
    }

    public void Modify(WeaponModifier modifier)
    {
        Equip(weapon.WithModifier(modifier));
    }

    public void Modify<TModifier>() where TModifier : WeaponModifier, new()
    {
        Modify(new TModifier());
    }
}
