using UnityEngine;

public class EnemySpawnManager : MonoBehaviour
{
    //boring surround spawning, will replace with enemy groups and patrols later.
    public float spawnRate;
    public float spawnTime;
    public Unit enemyToSpawn;
    public Transform[] spawnPoints;

    private void Update()
    {
        spawnTime += Time.deltaTime;
        if (spawnTime > spawnRate)
        {
            spawnTime = 0;
            Unit newEnemy = Instantiate(enemyToSpawn);
            newEnemy.transform.position = spawnPoints[Random.Range(0, spawnPoints.Length)].position;
        }
    }
}
