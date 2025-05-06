using UnityEngine;

public class ProjectileEffect : MonoBehaviour
{
    public float dissipationRate;
    private float dissipationTime = 0;
    protected virtual void Update()
    {
        dissipationTime += Time.deltaTime;
        if (dissipationTime >= dissipationRate)
        {
            Destroy(gameObject);
        }
    }
}
