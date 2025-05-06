using UnityEngine;

public class PlayerController : Unit
{
    public Rigidbody2D rb;
    public Vector2 moveInput;
    public SpriteRenderer playerSpriteRenderer;
    private bool isFacingRight = false;
    public bool isInputtingSpell = false;
    void Update()
    {
        moveInput.x = Input.GetAxisRaw("Horizontal");
        moveInput.y = Input.GetAxisRaw("Vertical");
        moveInput.Normalize();
        if (this.moveInput.x > 0f && this.isFacingRight)
        {
            playerSpriteRenderer.flipX = true;
            this.isFacingRight = !this.isFacingRight;
        }
        else if (this.moveInput.x < 0f && !this.isFacingRight)
        {
            playerSpriteRenderer.flipX = false;
            this.isFacingRight = !this.isFacingRight;
        }
    }
    private void FixedUpdate()
    {
        if (!isInputtingSpell)
        {
            rb.linearVelocity = moveInput * speed;
        }
    }
    public override void TakeDamage(float damage)
    {
        health -= damage;
        if (health <= 0)
        {
            Debug.Log("unit killed:" + gameObject.name);
            //Destroy(gameObject);
        }
    }
}
