/*
* Evan Meyer
* WeaponObject.cs
* CIS452 Assignment 4
*/

using UnityEngine;

[RequireComponent(typeof(BoxCollider2D), typeof(SpriteRenderer))]
public class WeaponObject : MonoBehaviour
{
    [SerializeField]
    private Transform transformToOrbit;
    private Weapon weapon;
    private Vector3 startingPosition;
    private Quaternion startingRotation;

    private SpriteRenderer spriteRenderer;

    private const float KnockbackMultiplier = 50f;

    public int Power { get => weapon.Power; }
    public int Speed { get => weapon.Speed; }
    public string Name { get => weapon.Name; }

    public void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        startingPosition = gameObject.transform.localPosition;
        startingRotation = gameObject.transform.localRotation;
        Equip<Sword>();
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
        spriteRenderer.sprite = weapon.Sprite;
    }

    public void Equip<TWeapon>() where TWeapon : Weapon, new()
    {
        Equip(new TWeapon());
    }

    public void Equip(string weaponName)
    {
        switch(weaponName)
        {
            case nameof(Sword): Equip<Sword>(); break;
            case nameof(Axe): Equip<Axe>(); break;
            case nameof(Dagger): Equip<Dagger>(); break;
        }
    }

    public void Modify(string modifierName)
    {
        switch (modifierName)
        {
            case nameof(Sharpness): weapon = new Sharpness(weapon); break;
            case nameof(Swiftness): weapon = new Swiftness(weapon); break;
        }
    }
}
