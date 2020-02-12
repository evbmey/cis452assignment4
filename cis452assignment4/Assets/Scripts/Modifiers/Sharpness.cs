
public class Sharpness : WeaponModifier
{
    public Sharpness(Weapon modifiedWeapon) : base(modifiedWeapon)
    {
        powerModifier = 1;
        nameModifier = "Sharp ";
    }
}
