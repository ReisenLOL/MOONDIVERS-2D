using UnityEngine;

public class EnemyUnit : Unit
{
    public Rigidbody2D rb;
    public Vector3 lookDirection;
    public PlayerController player;
    public bool playerInDetectionRange;
    private void Start()
    {
        player = FindFirstObjectByType<PlayerController>();
    }
    private void Update()
    {
        if (playerInDetectionRange)
        {
            lookDirection = (player.transform.position - transform.position).normalized;
        }
        else
        {
            lookDirection = Vector3.zero;
        }
    }
    private void FixedUpdate()
    {
        rb.linearVelocity = lookDirection * speed;
    }
}
