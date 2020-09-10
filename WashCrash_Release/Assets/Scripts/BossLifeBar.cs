/*  
*	TickLuck team
*	All rights reserved
*/

using UnityEngine;
using UnityEngine.UI;

public class BossLifeBar : MonoBehaviour
{
    #region Variables
    private Slider slider;
    [SerializeField] private Bosses[] bosses;
    [SerializeField] private GameObject fill;
    [SerializeField] private GameObject border;
    private int health;
    private GameObject boss_that_was_spawned;
    #endregion

    #region UnityMethods

    void Start()
    {
        Debug.Log("BossBar Start is called");


        fill.SetActive(false);
        border.SetActive(false);
        slider = GetComponent<Slider>();

        Debug.Log("BossBar Start is finished");
    }

    void FixedUpdate()
    {
        SetValue();
    }

    #endregion

    private void SetValue()
    {
        boss_that_was_spawned = EnemySpawner.boss_spawned;

        if (boss_that_was_spawned)
            foreach (var boss in bosses)
            {
                if (boss.bossPref.tag == EnemySpawner.boss_spawned.tag)
                {
                    health = boss_that_was_spawned.GetComponent<Entity>().health;

                    fill.SetActive(true);
                    border.SetActive(true);
                    slider.maxValue = health;
                    fill.GetComponent<Image>().color = boss.color;

                    if (health > 0)
                        slider.value = health;

                    else if (health <= 0)
                    {
                        slider.value = slider.maxValue;
                        fill.SetActive(false);
                        border.SetActive(false);
                    }
                }

                break;
            }
    }
}
