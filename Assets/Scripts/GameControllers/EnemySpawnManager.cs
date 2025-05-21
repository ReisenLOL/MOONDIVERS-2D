using UnityEngine;

public class EnemySpawnManager : MonoBehaviour
{
    [System.Serializable]
    public class EnemySpawnGroup
    {
        public Unit[] enemiesToSpawn;
        public Transform[] validSpawnLocations; //placeholder, this will be areas it can spawn in.
    }
    //boring surround spawning, will replace with enemy groups and patrols later.
    public EnemySpawnGroup[] spawnGroups;
    public float spawnRate;
    public float spawnTime;
    public Unit enemyToSpawn;
    public Transform[] spawnPoints;

    private void Start()
    {
        for (int i = 0; i < spawnGroups.Length; i++)
        {
            for (int j = 0; j < spawnGroups[i].validSpawnLocations.Length; j++)
            {
                SpawnUnitsFromGroup(spawnGroups[i], spawnGroups[i].validSpawnLocations[j]);
            }
        }
    }

    private void Update()
    {
        spawnTime += Time.deltaTime;
        if (spawnTime > spawnRate)
        {
            spawnTime = 0;
            SpawnSpecificUnit(enemyToSpawn, spawnPoints[Random.Range(0, spawnPoints.Length)].position);
        }
    }
    public void SpawnSpecificUnit(Unit unit, Vector3 locationToSpawn, int spawnAmount = 1)
    {
        for (int i = 0; i < spawnAmount; i++)
        {
            Unit newEnemy = Instantiate(unit);
            newEnemy.transform.position = locationToSpawn;
        }
    }
    public void SpawnUnitsFromGroup(EnemySpawnGroup spawnGroup, Transform spawnLocation)
    {
        for (int i = 0; i < spawnGroup.enemiesToSpawn.Length; i++)
        {
            Unit newEnemy = Instantiate(spawnGroup.enemiesToSpawn[i]);
            newEnemy.transform.position = spawnLocation.position;
        }
    }
}
