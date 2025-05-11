using UnityEngine;

public class SupportWeaponPickup : ItemPickup
{
    public Weapon weaponToAdd;
    protected override void OnTriggerEnter2D(Collider2D collision)
    {
        base.OnTriggerEnter2D(collision);
        WeaponHandler playerWeaponHandler = playerThatPickedUpItem.GetComponentInChildren<WeaponHandler>();
        playerWeaponHandler.supportWeapon = weaponToAdd;
        playerWeaponHandler._supportWeaponInstance = Instantiate(weaponToAdd, playerWeaponHandler.transform);
        playerWeaponHandler._supportWeaponInstance.gameObject.SetActive(false);
        Destroy(gameObject);
    }
}
