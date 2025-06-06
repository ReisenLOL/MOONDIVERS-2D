using UnityEngine;

public class ResupplyCrate : ItemPickup
{
    private PlayerStatsUI playerStatsUI;
    public GameObject parent;
    private void Start()
    {
        playerStatsUI = FindFirstObjectByType<PlayerStatsUI>();
    }
    protected override void PickupItem()
    {
        base.PickupItem();
        WeaponHandler playerWeaponHandler = playerThatPickedUpItem.gameObject.GetComponentInChildren<WeaponHandler>();
        if (playerWeaponHandler._primaryWeaponInstance.TryGetComponent(out RangedWeapon isPrimaryRangedWeapon))
        {
            isPrimaryRangedWeapon.magAmount = isPrimaryRangedWeapon.magCapacity;
        }
        if (playerWeaponHandler._secondaryWeaponInstance.TryGetComponent(out RangedWeapon isSecondaryRangedWeapon))
        {
            isSecondaryRangedWeapon.magAmount = isSecondaryRangedWeapon.magCapacity;
        }
        if (playerWeaponHandler._supportWeaponInstance && playerWeaponHandler._supportWeaponInstance.TryGetComponent(out RangedWeapon isSupportRangedWeapon))
        {
            isSupportRangedWeapon.magAmount = isSupportRangedWeapon.magCapacity;
        }
        if (playerWeaponHandler.equippedWeapon.TryGetComponent(out RangedWeapon isEquippedRangedWeapon))
        {
            playerStatsUI.UpdateMagAmount(isEquippedRangedWeapon.magAmount, isEquippedRangedWeapon.magCapacity);
            playerStatsUI.UpdateBulletAmount(isEquippedRangedWeapon.ammoAmount, isEquippedRangedWeapon.ammoCapacity);
        }
        Destroy(parent);
    }
}
