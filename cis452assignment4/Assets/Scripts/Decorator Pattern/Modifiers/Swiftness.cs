/*
* Evan Meyer
* Swiftness.cs
* CIS452 Assignment 4
*/

public class Swiftness : WeaponModifier
{
    public Swiftness(Weapon modifiedWeapon) : base(modifiedWeapon)
    {
        speedModifier = 1;
        nameModifier = "Swift ";
    }
}
