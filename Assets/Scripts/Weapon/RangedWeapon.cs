using UnityEngine;

public class RangedWeapon : Weapon
{
    public float projectileSpread;
    public float projectileSpeed;
    public int magCapacity;
    public int magAmount;
    public int ammoCapacity;
    public int ammoAmount;
    public AudioClip reloadSound;
    public float reloadRate;
    public float reloadTime;
    public bool isReloading = false;
    public void StartReloadingAmmo()
    {
        isReloading = true;
        ammoAmount = 0;
        playerStatsUI.magAmountText.text = "Mags: Reloading...";
        playerStatsUI.bulletAmountText.text = "Bullets: Reloading...";
    }
    public void ReloadAmmo()
    {
        if (magAmount > 0)
        {
            reloadTime = 0;
            magAmount--;
            ammoAmount = ammoCapacity;
            playerStatsUI.UpdateMagAmount(magAmount, magCapacity);
            playerStatsUI.UpdateBulletAmount(ammoAmount, ammoCapacity);
        }
    }
}
