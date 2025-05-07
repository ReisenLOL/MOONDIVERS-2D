using UnityEngine;

public class ResupplyCrate : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        WeaponHandler playerWeaponHandler = collision.gameObject.GetComponentInChildren<WeaponHandler>();
        if (playerWeaponHandler._primaryWeaponInstance.TryGetComponent(out RangedWeapon isPrimaryRangedWeapon))
        {
            isPrimaryRangedWeapon.ammoAmount = isPrimaryRangedWeapon.ammoCapacity;
        }
        if (playerWeaponHandler._secondaryWeaponInstance.TryGetComponent(out RangedWeapon isSecondaryRangedWeapon))
        {
            isSecondaryRangedWeapon.ammoAmount = isSecondaryRangedWeapon.ammoCapacity;
        }
        if (playerWeaponHandler._supportWeaponInstance && playerWeaponHandler._supportWeaponInstance.TryGetComponent(out RangedWeapon isSupportRangedWeapon))
        {
            isSupportRangedWeapon.ammoAmount = isSupportRangedWeapon.ammoCapacity;
        }
    }
}
