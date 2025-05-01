using UnityEngine;

public class PlayerController : Unit
{
    public Rigidbody2D rb;
    private Vector2 moveInput;
    public SpriteRenderer playerSpriteRenderer;
    private bool isFacingRight = false;
    void Start()
    {
        
    }

    // Update is called once per frame
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
        rb.linearVelocity = moveInput * speed;
    }
}
