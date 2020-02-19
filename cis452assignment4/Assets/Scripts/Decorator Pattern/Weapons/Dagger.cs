/*
* Evan Meyer
* Dagger.cs
* CIS452 Assignment 4
*/

using UnityEngine;

public class Dagger : Weapon
{
    public override int Power { get => 1; }
    public override int Speed { get => 5; }
    public override string Name { get => "Dagger"; }
    public override Sprite Sprite { get => Resources.Load<Sprite>("dagger"); }
}
