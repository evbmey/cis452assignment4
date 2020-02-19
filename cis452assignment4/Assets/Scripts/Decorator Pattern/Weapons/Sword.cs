/*
* Evan Meyer
* Sword.cs
* CIS452 Assignment 4
*/

using UnityEngine;

public class Sword : Weapon
{
    public override int Power { get => 3; }
    public override int Speed { get => 3; }
    public override string Name { get => "Sword"; }
    public override Sprite Sprite { get => Resources.Load<Sprite>("sword"); }

}
