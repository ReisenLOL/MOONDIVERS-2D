using UnityEngine;

public class EnemySpawnManager : MonoBehaviour
{
    [System.Serializable]
    public class EnemySpawnGroups
    {
        public Unit[] enemiesToSpawn;
        public Transform validSpawnLocations; //placeholder, this will be areas it can spawn in.
    }
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
            SpawnSpecificUnit(enemyToSpawn, spawnPoints[Random.Range(0, spawnPoints.Length)].position);
        }
    }
    public void SpawnSpecificUnit(Unit unit, Vector3 locationToSpawn)
    {
        Unit newEnemy = Instantiate(unit);
        newEnemy.transform.position = locationToSpawn;
    }
}
