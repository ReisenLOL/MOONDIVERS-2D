using UnityEngine;

public class ResupplyCrate : MonoBehaviour
{
    private PlayerStatsUI playerStatsUI;
    private void Start()
    {
        playerStatsUI = FindFirstObjectByType<PlayerStatsUI>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        WeaponHandler playerWeaponHandler = collision.gameObject.GetComponentInChildren<WeaponHandler>();
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
        Destroy(gameObject);
    }
}
