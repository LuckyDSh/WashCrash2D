
using UnityEngine;
using UnityEngine.UI;

public class LevelUp : MonoBehaviour
{
    #region Variables
    public GameObject[] uiToActivate;
    public Slider progressSlider;
    private Enemy[] enemies;
    public static bool s_isOnNewLevel = false; // Used in ProgressBar
    public static int s_LevelNumber = 0;
    #endregion

    private void Awake()
    {
        s_LevelNumber = 0;
        s_isOnNewLevel = false;
    }

    // Update is called once per frame
    void Update()
    {
        enemies = FindObjectsOfType<Enemy>();

        if (progressSlider.value == progressSlider.maxValue)
        {
            ProgressBar.isOn = false;
            s_isOnNewLevel = true;
            LevelBar.progress = 0;
            

            foreach (var enemy in enemies)
            {
                if (enemy == null)
                    return;

                enemy.Die();
            }

            progressSlider.value = progressSlider.minValue;

            s_LevelNumber += 5; // change to ++ 
            EnemySpawner.s_is_On_New_Level = true;

            if (s_LevelNumber == 50)
            {
                foreach (var ui in uiToActivate)
                {
                    ui.SetActive(true);
                }
            }
            if (s_LevelNumber % 10 == 0)
            {
                EnemySpawner._bossIsSpawned = true;
            }
        }
    }
}
