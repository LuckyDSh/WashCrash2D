/*
* TickLuck Team
* All rights reserved
*/

using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class LevelUp : MonoBehaviour
{
    #region Variables
    public GameObject[] uiToActivate;
    public Slider progressSlider;
    private Enemy[] enemies;
    public static bool s_isOnNewLevel = false; // Used in ProgressBar
    public static int s_LevelNumber;
    //private Slider level_slider;
    [SerializeField] public string[] themes_names;
    private int song_index;
    private GameObject effect_buffer = null;
    private Player player;
    #endregion

    private void Awake()
    {
        //level_slider = FindObjectOfType<LevelBar>().slider;
        s_LevelNumber = 0;
        s_isOnNewLevel = false;
    }

    private void Start()
    {
        song_index = 0;
        player = FindObjectOfType<Player>();

        if (player == null)
            player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();

        // if PlayModeMusic is not playing, play 
        if (!AudioManager.instance.sounds.First(s => s.name == themes_names[0]).source.isPlaying)
            AudioManager.instance.Play(themes_names[0]);

        progressSlider = GameObject.FindGameObjectWithTag("LevelBar").GetComponent<Slider>();
    }

    // Update is called once per frame
    void Update()
    {
        enemies = FindObjectsOfType<Enemy>();

        if (progressSlider.value == progressSlider.maxValue)
        {

            #region RESET FOR NEW LEVEL
            ProgressBar.isOn = false;
            LevelBar.progress = 0;
            if (LevelBar.decreaser < 0)
                LevelBar.decreaser--;
            progressSlider.value = 0;
            //level_slider.value = 0;
            #endregion

            #region Enemy Die()
            foreach (var enemy in enemies)
            {
                if (enemy == null)
                    return;

                effect_buffer = Instantiate(enemy.deathEffect, transform.position, Quaternion.identity);
                Destroy(effect_buffer);
                Destroy(enemy.gameObject);
            }
            #endregion

            EnemySpawner.s_is_On_New_Level = true;
            s_isOnNewLevel = EnemySpawner.s_is_On_New_Level;

            if (BackGroundChange.is_on_BG_change && s_LevelNumber > 0 && s_LevelNumber < 40)
            {
                //EnemySpawner._bossIsSpawned = true;
                #region MUSIC CHANGE
                if (s_LevelNumber == 5 || s_LevelNumber == 15 || s_LevelNumber == 25)
                {
                    ++song_index;
                    if (song_index < themes_names.Length && (song_index - 1) >= 0)
                    {
                        AudioManager.instance.Stop(themes_names[song_index - 1]);
                        AudioManager.instance.Play(themes_names[song_index]);
                    }
                }
                #endregion

                //BackGroundChange.is_on_BG_change = false; // SWITCH OFF
            }

            /*++*/
            s_LevelNumber += 1; // change to ++ 

            #region Final
            if (s_LevelNumber == 35)
            {
                foreach (var ui in uiToActivate)
                {
                    foreach (string theme in themes_names)
                    {
                        AudioManager.instance.Stop(theme);
                    }
                    ui.SetActive(true);
                }

                player.Die();
                player.GO_ui.SetActive(false);
            }
            #endregion
        }
    }
}
