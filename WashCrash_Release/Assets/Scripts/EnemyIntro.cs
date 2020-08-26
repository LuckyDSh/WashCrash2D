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
        timeScale = 0.2f;
        foreach (var story in stories)
        {
            story.SetActive(false);
        }
    }

    void Update()
    {
        if (EnemySpawner.s_is_New_Enemy)
        {
            Intro_On(EnemySpawner.s_indexOfEnemy);
        }
    }

    #endregion

    private void Intro_On(int index)
    {
        m_index = index;
        Time.timeScale = timeScale;
        stories[index].SetActive(true);
        EnemySpawner.s_is_New_Enemy = false;
    }

    public void Intro_Off()
    {
        Time.timeScale = 1f;
        stories[m_index].SetActive(false);
    }
}
