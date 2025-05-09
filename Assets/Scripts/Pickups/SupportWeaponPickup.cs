using UnityEngine;

public class SupportWeaponPickup : ItemPickup
{
    public Weapon weaponToAdd;
    protected override void OnTriggerEnter2D(Collider2D collision)
    {
        base.OnTriggerEnter2D(collision);
        playerThatPickedUpItem.GetComponentInChildren<WeaponHandler>().supportWeapon = weaponToAdd;
    }
}
