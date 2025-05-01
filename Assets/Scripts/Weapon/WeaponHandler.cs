using UnityEngine;

public class WeaponHandler : MonoBehaviour
{
    public Weapon primaryWeapon;
    public Weapon secondaryWeapon;
    public Weapon supportWeapon;
    public Weapon equippedWeapon;
    void Start()
    {
        Weapon newPrimaryWeapon = Instantiate(primaryWeapon, transform);
        equippedWeapon = newPrimaryWeapon;
        newPrimaryWeapon.isEquipped = true;
        //Weapon newSecondaryWeapon = Instantiate(secondaryWeapon, transform);
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            equippedWeapon.ReloadAmmo();
        }
    }
}
