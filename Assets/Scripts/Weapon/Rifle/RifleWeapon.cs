using UnityEngine;

public class RifleWeapon : RangedWeapon
{
    public AudioSource audioSource;
    public bool automaticFiring = true;
    void Start()
    {
        audioSource = GetComponentInParent<AudioSource>();
        playerStatsUI = FindFirstObjectByType<PlayerStatsUI>();
        playerStatsUI.UpdateMagAmount(magAmount, magCapacity);
        playerStatsUI.UpdateBulletAmount(ammoAmount, ammoCapacity);
    }
    void Update()
    {
        fireTime += Time.deltaTime;
        if ((automaticFiring && Input.GetMouseButton(0) || !automaticFiring && Input.GetMouseButtonDown(0)) && ammoAmount > 0 && canFire)
        {
            if (fireTime >= fireRate)
            {
                audioSource.PlayOneShot(attackSound, 0.7f);
                ammoAmount--;
                playerStatsUI.UpdateBulletAmount(ammoAmount, ammoCapacity);
                fireTime = 0;
                Vector3 mousePos = Input.mousePosition;
                mousePos.z = Camera.main.nearClipPlane + 10;
                Vector3 worldPos = Camera.main.ScreenToWorldPoint(mousePos);
                ShootTheBullet(worldPos);
            }
        }
    }
    private void ShootTheBullet(Vector3 direction)
    {
        Attack newAttack = Instantiate(attack, transform);
        newAttack.damage = damage;
        newAttack.projectileSpeed = projectileSpeed;
        newAttack.maxRange = maxRange;
        newAttack.firedFrom = transform;
        newAttack.RotateToTarget(direction);
        newAttack.transform.Rotate(0, 0, Random.Range(-projectileSpread, projectileSpread));
    }
}
