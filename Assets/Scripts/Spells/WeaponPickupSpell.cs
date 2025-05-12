using UnityEngine;

public class WeaponPickupSpell : Spell
{
    public GameObject weaponPickup;
    protected override void CastSpell()
    {
        base.CastSpell();
        GameObject newWeaponPickup = Instantiate(weaponPickup);
        newWeaponPickup.transform.position = spellLocation;
    }
}
