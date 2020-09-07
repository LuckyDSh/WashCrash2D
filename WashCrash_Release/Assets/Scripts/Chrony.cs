/*  
*	TickLuck team
*	All rights reserved
*/

using System.Collections;
using UnityEngine;

public class Chrony : MonoBehaviour
{
    #region Variables
    [SerializeField] private float reload_time = 6f;
    [SerializeField] private float slowDown_Amount = 3f;
    [SerializeField] private float chrono_timeStop_duration = 3f;
    [SerializeField] private float reload_time_buffer;
    [SerializeField] private GameObject chrony_btn;
    [SerializeField] private GameObject chrony_effect;
    private ProgressBar meltBar;
    private EnemySpawner enemySpawner;
    #endregion

    #region UnityMethods

    void Start()
    {
        reload_time_buffer = reload_time;
        enemySpawner = FindObjectOfType<EnemySpawner>();
        meltBar = FindObjectOfType<ProgressBar>();
    }

    void Update()
    {
        if (Time.time > reload_time_buffer)
        {
            reload_time_buffer += Time.time + reload_time;
        }
    }

    #endregion

    public IEnumerator ChronoStasis()
    {
        GameObject effect = Instantiate(chrony_effect, transform.position, Quaternion.identity);
        EnemyAI[] enemies = FindObjectsOfType<EnemyAI>();

        if (meltBar != null)
            StartCoroutine(meltBar.FreezeMeltBar());

        if (enemySpawner != null)
            enemySpawner.is_stoped = true;

        foreach (var enemy in enemies)
        {
            enemy.moveSpeed /= slowDown_Amount;
        }

        yield return new WaitForSeconds(slowDown_Amount);

        foreach (var enemy in enemies)
        {
            enemy.moveSpeed *= slowDown_Amount;
        }

        enemySpawner.is_stoped = false;
    }
}
