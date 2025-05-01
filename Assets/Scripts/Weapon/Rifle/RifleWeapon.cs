using UnityEngine;

public class RifleWeapon : Weapon
{
    void Update()
    {
        fireTime += Time.deltaTime;
        if (Input.GetMouseButton(0))
        {
            if (fireTime >= fireRate)
            {
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
