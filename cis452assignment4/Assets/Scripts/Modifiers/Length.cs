
public class Length : WeaponModifier
{
    public Length(Weapon modifiedWeapon) : base(modifiedWeapon)
    {
        rangeModifier = 1;
        nameModifier = "Long ";
    }
}
