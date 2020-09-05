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
    [SerializeField] private Image fill;
    [SerializeField] private GameObject border;
    #endregion

    #region UnityMethods

    void Start()
    {
        Debug.Log("BossBar Start is called");

        fill.enabled = false;
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
        foreach (var boss in bosses)
        {
            if (boss.bossPref.activeInHierarchy)
            {
                int health = boss.bossPref.GetComponent<Entity>().health;

                fill.enabled = true;
                border.SetActive(true);
                slider.maxValue = health;

                if (health > 0)
                    slider.value = health;
                   
                else
                {
                    slider.value = slider.maxValue;
                    gameObject.SetActive(false);
                }

                break;
            }
        }
    }
}
