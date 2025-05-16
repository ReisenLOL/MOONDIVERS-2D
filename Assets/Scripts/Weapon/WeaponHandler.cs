using UnityEngine;

public class WeaponHandler : MonoBehaviour
{
    public PlayerStatsUI playerStatsUI;
    public PlayerController player;
    public AudioSource audioSource;
    public Weapon primaryWeapon;
    public Weapon secondaryWeapon;
    public Weapon supportWeapon;

    public Weapon _primaryWeaponInstance;
    public Weapon _secondaryWeaponInstance;
    public Weapon _supportWeaponInstance;

    public Weapon equippedWeapon;
    public bool isMelee = false;
    public RangedWeapon _equippedRangedWeapon;
    void Start()
    {
        playerStatsUI = FindFirstObjectByType<PlayerStatsUI>();
        audioSource = GetComponentInParent<AudioSource>();
        _primaryWeaponInstance = Instantiate(primaryWeapon, transform);
        equippedWeapon = _primaryWeaponInstance;
        playerStatsUI.UpdateWeaponName(equippedWeapon.weaponName);
        _secondaryWeaponInstance = Instantiate(secondaryWeapon, transform);
        _secondaryWeaponInstance.gameObject.SetActive(false);
        bool hasRanged = _primaryWeaponInstance.TryGetComponent(out _equippedRangedWeapon);
    }
    void Update()
    {
        if ((_equippedRangedWeapon == null || _equippedRangedWeapon != null && !_equippedRangedWeapon.isReloading) && player.canMove)
        {
            if (Input.GetKeyDown(KeyCode.Alpha1))
            {
                SwitchWeapons(_primaryWeaponInstance);
            }
            if (Input.GetKeyDown(KeyCode.Alpha2))
            {
                SwitchWeapons(_secondaryWeaponInstance);
            }
            if (Input.GetKeyDown(KeyCode.Alpha3))
            {
                if (supportWeapon != null)
                {
                    SwitchWeapons(_supportWeaponInstance);
                }
            }
        }
        if (_equippedRangedWeapon != null)
        {
            if (!_equippedRangedWeapon.isReloading && Input.GetKeyDown(KeyCode.R))
            {
                audioSource.PlayOneShot(_equippedRangedWeapon.reloadSound, 1f);
                _equippedRangedWeapon.StartReloadingAmmo();
            }
            else if (_equippedRangedWeapon.isReloading)
            {
                _equippedRangedWeapon.reloadTime += Time.deltaTime;
                if (_equippedRangedWeapon.reloadTime >= _equippedRangedWeapon.reloadRate)
                {
                    _equippedRangedWeapon.ReloadAmmo();
                    _equippedRangedWeapon.isReloading = false;
                }
            }
        }
    }
    public void SwitchWeapons(Weapon weaponToSwitchTo)
    {
        equippedWeapon.gameObject.SetActive(false);
        equippedWeapon = weaponToSwitchTo;
        equippedWeapon.gameObject.SetActive(true);
        playerStatsUI.UpdateWeaponName(weaponToSwitchTo.weaponName);
        bool hasRanged = weaponToSwitchTo.TryGetComponent(out _equippedRangedWeapon);
        isMelee = !hasRanged;
        if (_equippedRangedWeapon != null)
        {
            playerStatsUI.UpdateBulletAmount(_equippedRangedWeapon.ammoAmount, _equippedRangedWeapon.ammoCapacity);
            playerStatsUI.UpdateMagAmount(_equippedRangedWeapon.magAmount, _equippedRangedWeapon.magCapacity);
        }
    }
}
