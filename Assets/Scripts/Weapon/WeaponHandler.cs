using UnityEngine;

public class WeaponHandler : MonoBehaviour
{
    public Weapon primaryWeapon;
    public Weapon secondaryWeapon;
    public Weapon supportWeapon;
    void Start()
    {
        Weapon newPrimaryWeapon = Instantiate(primaryWeapon, transform);
        Weapon newSecondaryWeapon = Instantiate(secondaryWeapon, transform);
    }
    void Update()
    {
        
    }
}
