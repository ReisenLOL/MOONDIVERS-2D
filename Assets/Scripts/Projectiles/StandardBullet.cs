using UnityEngine;

public class StandardBullet : Attack
{
    void Start()
    {
        
    }
    void Update()
    {
        transform.Translate(Vector2.right * projectileSpeed * Time.deltaTime);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        collision.GetComponent<Unit>().TakeDamage(damage);
    }
}
