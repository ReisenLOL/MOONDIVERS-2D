using UnityEngine;

public class SupportWeaponPickup : ItemPickup
{
    public Weapon weaponToAdd;
    public GameObject parent;
    protected override void PickupItem()
    {
        base.PickupItem();
        WeaponHandler playerWeaponHandler = playerThatPickedUpItem.GetComponentInChildren<WeaponHandler>();
        playerWeaponHandler.supportWeapon = weaponToAdd;
        playerWeaponHandler._supportWeaponInstance = Instantiate(weaponToAdd, playerWeaponHandler.transform);
        playerWeaponHandler._supportWeaponInstance.gameObject.SetActive(false);
        Destroy(parent);
    }
}
