using UnityEngine;

public class DetectPlayer : MonoBehaviour
{
    public EnemyUnit thisEnemyUnit;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        thisEnemyUnit.playerInDetectionRange = true;
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        thisEnemyUnit.playerInDetectionRange = false; //this one shouldn't be here i'm just testing
    }
}
