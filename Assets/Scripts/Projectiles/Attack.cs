using Core.Extensions;
using UnityEngine;

public class Attack : MonoBehaviour
{
    public float damage;
    public float projectileSpeed;
    public Vector2 targetPosition;
    public float maxRange;
    public Transform firedFrom;
    public void RotateToTarget(Vector2 worldPosition)
    {
        targetPosition = worldPosition;
        transform.Lookat2D(worldPosition);
    }
}
