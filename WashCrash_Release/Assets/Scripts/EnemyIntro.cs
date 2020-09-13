/*  
*	TickLuck team
*	All rights reserved
*/

using UnityEngine;

public class EnemyIntro : MonoBehaviour
{
    #region Variables
    [SerializeField] private GameObject[] stories;
    [SerializeField] private float timeScale = 0.5f;
    private int m_index;
    #endregion

    #region UnityMethods
    void Start()
    {
        Time.timeScale = 1f;
        m_index = 0;
        timeScale = 0.2f;

        foreach (var story in stories)
        {
            story.SetActive(false);
        }
    }

    void Update()
    {
        if (EnemySpawner.s_is_New_Enemy && BackGroundChange.is_on_BG_change)
        {
            Intro_On(EnemySpawner.s_indexOfEnemy);
            EnemySpawner.s_indexOfEnemy++;
            EnemySpawner.s_is_New_Enemy = false;
        }
    }

    #endregion

    private void Intro_On(int index)
    {
        m_index = index;

        if (m_index <= stories.Length && m_index >= 0)
        {
            Time.timeScale = timeScale;
            stories[index].SetActive(true);
        }
    }

    public void Intro_Off()
    {
        Time.timeScale = 1f;
        if (m_index < stories.Length && m_index >= 0)
            stories[m_index].SetActive(false);
    }
}
