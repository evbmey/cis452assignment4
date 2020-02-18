/*
* Evan Meyer
* Weapon.cs
* CIS452 Assignment 4
*/

public abstract class Weapon
{
    public abstract int Power { get; }
    public abstract int Speed { get; }
    public abstract string Name { get; }

    public Weapon WithModifier(WeaponModifier modifier)
    {
        modifier.ModifiedWeapon = this;
        return modifier;
    }

    public Weapon WithModifier<TModifier>() where TModifier : WeaponModifier, new()
    {
        return WithModifier(new TModifier());
    }
}
