using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    #region Declarations
    [Header("General characteristics")]
    [Space]
    public float startSpawnRadius = 20f;
    private float spawnRadius;
    public Transform spawnTargetPos;

    //[HideInInspector]
    public Wave currentWave;

    [Space]
    [Header("Boss Spawning")]
    [Space]
    [SerializeField] public GameObject[] _BossesPrefabs;
    [SerializeField] private GameObject OrienteeringForBossSpawn;
    public static bool _bossIsSpawned = false;
    public static GameObject boss_spawned = null;

    [Space]
    [Header("Level Changing ")]
    [Space]
    [SerializeField] private GameObject storyPanel;
    public static bool s_is_On_New_Level = false;
    public static bool s_is_New_Enemy = false;
    public static int s_indexOfEnemy; // used in EnemyIntro

    [HideInInspector] public bool is_stoped = false;
    private float nextSpawnTime = 1f;
    private Vector2 posForBoss = Vector2.zero;
    private int level;
    private bool is_changed;
    #endregion

    #region UnityMethods

    // using OnEnable() because of the only scene in th game
    private void Start()
    {
        is_changed = false;
        s_is_On_New_Level = false;
        s_is_New_Enemy = false;
        s_indexOfEnemy = 0;
        is_stoped = false;
        boss_spawned = null;
        OrienteeringForBossSpawn = GameObject.FindGameObjectWithTag("BackGround");

        foreach (EnemyType enemyType in currentWave.enemies)
        {
            if (enemyType.label == "Dirt")
                enemyType.spawnChance = 1f;
            else if (enemyType.label == "BlueDirt")
                enemyType.spawnChance = 0f;
            else if (enemyType.label == "GreenDirt")
                enemyType.spawnChance = 0f;
            else if (enemyType.label == "RedDirt")
                enemyType.spawnChance = 0f;
            else if (enemyType.label == "BlackDirt")
                enemyType.spawnChance = 0f;
            else if (enemyType.label == "WhiteDirt")
                enemyType.spawnChance = 0f;
        }
    }

    // Update is called once per frame
    void Update()
    {
        spawnRadius = startSpawnRadius /** Progression.Growth*/;
        posForBoss = OrienteeringForBossSpawn.transform.position;
        level = LevelUp.s_LevelNumber;

        if (s_is_On_New_Level)
        {
            On_new_level();
        }

        if (Time.time >= nextSpawnTime && !is_stoped)
        {
            SpawnWave();
            nextSpawnTime = Time.time + 1f / currentWave.spawnRate;
        }

        // System generates 30 levels 
        // and there is 3 types of bosses
        #region BOSS SPAWNING
        if (LevelUp.s_LevelNumber % 10 == 0)
        {
            if (_bossIsSpawned)
            {
                SpawnBoss(_BossesPrefabs[0], posForBoss, Quaternion.identity);
                _bossIsSpawned = false;
            }
        }

        if (LevelUp.s_LevelNumber % 20 == 0)
        {
            if (_bossIsSpawned)
            {
                SpawnBoss(_BossesPrefabs[1], posForBoss, Quaternion.identity);
                _bossIsSpawned = false;
            }
        }

        if (LevelUp.s_LevelNumber % 30 == 0)
        {
            if (_bossIsSpawned)
            {
                SpawnBoss(_BossesPrefabs[2], posForBoss, Quaternion.identity);
                _bossIsSpawned = false;
            }
        }
        #endregion
       
    }

    #endregion

    #region SpawnWave()
    private void SpawnWave()
    {
        foreach (EnemyType eType in currentWave.enemies)
        {
            if (Random.value <= eType.spawnChance)
            {
                Debug.Log(eType.label);
                SpawEnemy(eType.enemyPrefab);
            }

            if (s_is_On_New_Level)
            {
                SpawnChanceChange(eType);
                //s_is_On_New_Level = false;
            }
        }
        s_is_On_New_Level = false;
    }
    #endregion

    private void SpawnChanceChange(EnemyType eType)
    {
        #region ENEMY SPAWNRATE CONFIGURATION
        // think of optimization

        if (level <= 4)
        {
            Debug.Log("Levels from 0 to 5");

            if (eType.label == "Dirt")
                eType.spawnChance = 1f;
            else if (eType.label == "BlueDirt")
                eType.spawnChance = 0f;
            else if (eType.label == "GreenDirt")
                eType.spawnChance = 0f;
            else if (eType.label == "RedDirt")
                eType.spawnChance = 0f;
            else if (eType.label == "BlackDirt")
                eType.spawnChance = 0f;
            else if (eType.label == "WhiteDirt")
                eType.spawnChance = 0f;
        }
        else if (level <= 9)
        {
            Debug.Log("Levels from 5 to 10");

            if (eType.label == "Dirt")
                eType.spawnChance = 0.8f;
            else if (eType.label == "BlueDirt")
                eType.spawnChance = 0.6f;
            else if (eType.label == "GreenDirt")
                eType.spawnChance = 0f;
            else if (eType.label == "RedDirt")
                eType.spawnChance = 0f;
            else if (eType.label == "BlackDirt")
                eType.spawnChance = 0f;
            else if (eType.label == "WhiteDirt")
                eType.spawnChance = 0f;
        }
        else if (level <= 14)
        {
            Debug.Log("Levels from 10 to 15");

            if (eType.label == "Dirt")
                eType.spawnChance = 0.6f;
            else if (eType.label == "BlueDirt")
                eType.spawnChance = 0.6f;
            else if (eType.label == "GreenDirt")
                eType.spawnChance = 0.6f;
            else if (eType.label == "RedDirt")
                eType.spawnChance = 0f;
            else if (eType.label == "BlackDirt")
                eType.spawnChance = 0f;
            else if (eType.label == "WhiteDirt")
                eType.spawnChance = 0f;
        }
        else if (level <= 24)
        {
            Debug.Log("Levels from 15 to 25");

            if (eType.label == "Dirt")
                eType.spawnChance = 0.5f;
            else if (eType.label == "BlueDirt")
                eType.spawnChance = 0.6f;
            else if (eType.label == "GreenDirt")
                eType.spawnChance = 0.7f;
            else if (eType.label == "RedDirt")
                eType.spawnChance = 0.4f;
            else if (eType.label == "BlackDirt")
                eType.spawnChance = 0f;
            else if (eType.label == "WhiteDirt")
                eType.spawnChance = 0f;
        }
        else if (level <= 34)
        {
            Debug.Log("Levels from 25 to 35");

            if (eType.label == "Dirt")
                eType.spawnChance = 0.5f;
            else if (eType.label == "BlueDirt")
                eType.spawnChance = 0.6f;
            else if (eType.label == "GreenDirt")
                eType.spawnChance = 0.7f;
            else if (eType.label == "RedDirt")
                eType.spawnChance = 0.4f;
            else if (eType.label == "BlackDirt")
                eType.spawnChance = 0.5f;
            else if (eType.label == "WhiteDirt")
                eType.spawnChance = 0f;
        }
        else if (level <= 44)
        {
            Debug.Log("Levels from 35 to 45");

            if (eType.label == "Dirt")
                eType.spawnChance = 0.4f;
            else if (eType.label == "BlueDirt")
                eType.spawnChance = 0.7f;
            else if (eType.label == "GreenDirt")
                eType.spawnChance = 0.7f;
            else if (eType.label == "RedDirt")
                eType.spawnChance = 0.4f;
            else if (eType.label == "BlackDirt")
                eType.spawnChance = 0.5f;
            else if (eType.label == "WhiteDirt")
                eType.spawnChance = 0.3f;
        }

        #endregion
    }

    #region SpawnEnemy()
    private void SpawEnemy(GameObject enemyPrefab)
    {
        if (spawnTargetPos == null)
            return;

        Vector2 spawnPos = spawnTargetPos.position;
        spawnPos += Random.insideUnitCircle.normalized * spawnRadius;

        if (enemyPrefab != null)
            Instantiate(enemyPrefab, spawnPos, Quaternion.identity);
    }
    #endregion

    private void On_new_level()
    {
        if (level % 5 == 0 && level != 0 && is_changed) // think how to quit the loop
        {
            storyPanel.SetActive(true);
            s_is_New_Enemy = true;

            Debug.Log(s_indexOfEnemy.ToString());

            s_indexOfEnemy++;
            is_changed = false;
        }
    }

    public void SpawnBoss(GameObject BossToSpawn, Vector2 pos, Quaternion rotation)
    {
        // also change environment and change the music 


        boss_spawned = Instantiate(BossToSpawn, pos, rotation);
    }
}