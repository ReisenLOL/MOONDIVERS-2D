using UnityEngine;

public class Weapon : MonoBehaviour
{
    public float damage;
    public float projectileSpeed;
    public float fireRate;
    public int magCapacity;
    public int magAmount;
    public int ammoCapacity;
    public int ammoAmount;
    public void ReloadAmmo()
    {
        if (magAmount > 0)
        {
            magAmount--;
            ammoAmount = ammoCapacity;
        }
    }
}
