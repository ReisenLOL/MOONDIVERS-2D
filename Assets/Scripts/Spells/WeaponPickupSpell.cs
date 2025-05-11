using UnityEngine;

public class WeaponPickupSpell : Spell
{
    public SupportWeaponPickup weaponPickup;
    protected override void CastSpell()
    {
        base.CastSpell();
        SupportWeaponPickup newWeaponPickup = Instantiate(weaponPickup);
        newWeaponPickup.transform.position = spellLocation;
    }
}
