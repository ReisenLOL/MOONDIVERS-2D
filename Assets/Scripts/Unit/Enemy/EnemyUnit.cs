using UnityEngine;

public class EnemyUnit : Unit
{
    public Rigidbody2D rb;
    public Vector3 lookDirection;
    public PlayerController player;
    private void Start()
    {
        player = FindFirstObjectByType<PlayerController>();
    }
    private void Update()
    {
        lookDirection = (player.transform.position - transform.position).normalized;
    }
    private void FixedUpdate()
    {
        rb.linearVelocity = lookDirection * speed;
    }
}
