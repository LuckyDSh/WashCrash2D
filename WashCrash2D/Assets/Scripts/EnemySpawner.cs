using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public float startSpawnRadius = 20f;
    private float spawnRadius;
    public Transform spawnTargetPos;


    //[HideInInspector]
    public Wave currentWave;

    private float nextSpawnTime = 1f;

    // Update is called once per frame
    void Update()
    {
        //if (Progression.IsGrowing) return;

        spawnRadius = startSpawnRadius /** Progression.Growth*/;

        if (Time.time >= nextSpawnTime)
        {
            SpawnWave();
            nextSpawnTime = Time.time + 1f / currentWave.spawnRate;
        }
    }

    private void SpawnWave()
    {
        foreach (EnemyType eType in currentWave.enemies)
        {
            if (Random.value <= eType.spawnChance)
            {
                SpawEnemy(eType.enemyPrefab);
            }
        }
    }

    private void SpawEnemy(GameObject enemyPrefab)
    {
        if (spawnTargetPos == null)
            return;

        Vector2 spawnPos = spawnTargetPos.position;
        spawnPos += Random.insideUnitCircle.normalized * spawnRadius;

        if (enemyPrefab != null)
            Instantiate(enemyPrefab, spawnPos, Quaternion.identity);
    }
}
