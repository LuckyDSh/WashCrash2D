/*
* TickLuck Team
* All rights reserved
*/

using UnityEngine;

public class StaticDisabler : MonoBehaviour
{
    #region Variables
    // Disable on load
    [SerializeField] private GameObject[] objsTo_enable_disable;

    // instantiate the Player at pos
    private Vector2 init_pos_for_Player = new Vector2(-6.823887f, -12.04306f);
    [SerializeField] private GameObject Player;

    // Activate on Load + make full
    private LevelBar enemyBar;
    #endregion

    #region UnityMethods

    void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }

    private void OnLevelWasLoaded(int level)
    {
        if(level == 1)
        {
            enemyBar = FindObjectOfType<LevelBar>();

            ProgressBar.s_meltBarSlider.value = ProgressBar.s_meltBarSlider.maxValue;
            enemyBar.slider.value = 0;

            foreach (var obj in objsTo_enable_disable)
            {
                obj.SetActive(false);
            }

            if (Player == null)
                Instantiate(Player, init_pos_for_Player, Quaternion.identity);
        }     
    }

    #endregion
}
