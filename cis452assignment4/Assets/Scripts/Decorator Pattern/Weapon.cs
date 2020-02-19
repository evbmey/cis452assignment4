/*
* Evan Meyer
* Weapon.cs
* CIS452 Assignment 4
*/

using UnityEngine;

public abstract class Weapon
{
    public abstract int Power { get; }
    public abstract int Speed { get; }
    public abstract string Name { get; }
    public abstract Sprite Sprite { get; }

}
