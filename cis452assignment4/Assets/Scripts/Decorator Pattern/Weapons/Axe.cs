/*
* Evan Meyer
* Axe.cs
* CIS452 Assignment 4
*/

using UnityEngine;

public class Axe : Weapon
{
    public override int Power { get => 5; }
    public override int Speed { get => 1; }
    public override string Name { get => "Axe"; }
    public override Sprite Sprite { get => Resources.Load<Sprite>("axe"); }

}
