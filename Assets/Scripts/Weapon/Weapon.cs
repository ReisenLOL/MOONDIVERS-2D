using UnityEngine;

public class Weapon : MonoBehaviour
{
    public string weaponName;
    public PlayerStatsUI playerStatsUI;
    public float damage;
    public float fireRate;
    public float fireTime;
    public float maxRange;
    public bool canFire = true;
    public Attack attack;
    public AudioClip attackSound;
}
