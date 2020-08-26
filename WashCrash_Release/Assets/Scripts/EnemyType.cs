using UnityEngine;

[System.Serializable]
public class EnemyType : MonoBehaviour
{
    public string label;

    public GameObject enemyPrefab;

    [Range(0f, 1)]
    public float spawnChance;
}
