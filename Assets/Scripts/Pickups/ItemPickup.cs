using UnityEngine;

public class ItemPickup : MonoBehaviour
{
    protected PlayerController playerThatPickedUpItem;
    public GameObject pickupUI;
    protected bool isInRange;
    public KeyCode pickupKey;
    protected virtual void OnTriggerEnter2D(Collider2D collision)
    {
        pickupUI.SetActive(true);
        playerThatPickedUpItem = collision.GetComponent<PlayerController>();
        isInRange = true;
    }
    protected virtual void OnTriggerExit2D(Collider2D collision)
    {
        pickupUI.SetActive(false);
        playerThatPickedUpItem = null;
        isInRange = false;
    }
    protected virtual void Update()
    {
        if (isInRange)
        {
            if (Input.GetKeyDown(pickupKey))
            {
                PickupItem();
            }
        }
    }
    protected virtual void PickupItem()
    {
        
    }
}
