/*
* Evan Meyer
* WeaponModifier.cs
* CIS452 Assignment 4
*/

using UnityEngine;

public abstract class WeaponModifier : Weapon
{
    protected int powerModifier = 0;
    protected int speedModifier = 0;
    protected string nameModifier = "";

    public WeaponModifier(Weapon modifiedWeapon)
    {
        ModifiedWeapon = modifiedWeapon;
    }

    public Weapon ModifiedWeapon { get; set; }

    public override int Power { get => ModifiedWeapon.Power + powerModifier; }
    public override int Speed { get => ModifiedWeapon.Speed + speedModifier; }
    public override string Name { get => nameModifier + ModifiedWeapon.Name; }
    public override Sprite Sprite { get => ModifiedWeapon.Sprite; }

}
