using UnityEngine;

public class RifleWeapon : Weapon
{
    void Update()
    {
        if (isEquipped)
        {
            fireTime += Time.deltaTime;
            if (Input.GetMouseButton(0) && ammoAmount > 0)
            {
                if (fireTime >= fireRate)
                {
                    ammoAmount--;
                    playerStatsUI.UpdateBulletAmount(ammoAmount, ammoCapacity);
                    fireTime = 0;
                    Attack newAttack = Instantiate(attack, transform);
                    newAttack.damage = damage;
                    newAttack.projectileSpeed = projectileSpeed;
                    newAttack.maxRange = maxRange;
                    newAttack.firedFrom = transform;
                    Vector3 mousePos = Input.mousePosition;
                    mousePos.z = Camera.main.nearClipPlane + 10;
                    Vector3 worldPos = Camera.main.ScreenToWorldPoint(mousePos);
                    newAttack.RotateToTarget(worldPos);
                }
            }
        }
    }
}
