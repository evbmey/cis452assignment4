
public abstract class WeaponModifier : Weapon
{
    private Weapon modifiedWeapon;

    protected int powerModifier = 0;
    protected int speedModifier = 0;
    protected int rangeModifier = 0;
    protected string nameModifier = "";

    public WeaponModifier(Weapon modifiedWeapon)
    {
        this.modifiedWeapon = modifiedWeapon;
    }

    public override int Power { get => modifiedWeapon.Power + powerModifier; }

    public override int Speed { get => modifiedWeapon.Speed + speedModifier; }

    public override int Range { get => modifiedWeapon.Range + rangeModifier; }

    public override string Name { get => nameModifier + modifiedWeapon.Name; }
}
