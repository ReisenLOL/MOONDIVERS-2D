using UnityEngine;

public class ItemPickup : MonoBehaviour
{
    protected PlayerController playerThatPickedUpItem;
    protected virtual void OnTriggerEnter2D(Collider2D collision)
    {
        playerThatPickedUpItem = collision.GetComponent<PlayerController>();
    }
}
