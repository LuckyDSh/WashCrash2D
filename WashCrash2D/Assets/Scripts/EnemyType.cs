using UnityEngine;

[System.Serializable]
public class EnemyType:MonoBehaviour
{
    public GameObject enemyPrefab;

    [Range(.1f,1)]
    public float spawnChance;
}
