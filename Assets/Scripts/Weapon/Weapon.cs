using UnityEngine;

public class Weapon : MonoBehaviour
{
    public PlayerStatsUI playerStatsUI;

    public float damage;
    public float projectileSpeed;
    public float fireRate;
    public float fireTime;
    public int magCapacity;
    public int magAmount;
    public int ammoCapacity;
    public int ammoAmount;
    public float maxRange;
    public bool isEquipped = false;
    public Attack attack;
    public void ReloadAmmo()
    {
        if (magAmount > 0)
        {
            magAmount--;
            ammoAmount = ammoCapacity;
            playerStatsUI.UpdateMagAmount(magAmount, magCapacity);
            playerStatsUI.UpdateBulletAmount(ammoAmount, ammoCapacity);
        }
    }
}
