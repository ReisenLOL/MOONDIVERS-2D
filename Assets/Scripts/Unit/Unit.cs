using UnityEngine;

public class Unit : MonoBehaviour
{
    public float speed;
    public float health;
    public float maxHealth;
    public virtual void TakeDamage(float damage)
    {
        health -= damage;
        if (health <= 0)
        {
            Debug.Log("unit killed:" + gameObject.name);
            Destroy(gameObject);
        }
    }
}
