/*  
*	TickLuck team
*	All rights reserved
*/

using UnityEngine;

public class BackGroundChange : MonoBehaviour
{
    #region Variables
    private SpriteRenderer bgRenderer;
    public GameObject[] borders_points;
    [SerializeField] private Sprite[] sprites;
    public static bool is_on_BG_change; // used in LevelUp and EnemySpawner and EnemyIntro
    #endregion

    #region UnityMethods
    void Start()
    {
        is_on_BG_change = false;
        bgRenderer = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        #region SET BACKGROUND
        if (LevelUp.s_LevelNumber == 0)
        {
            BG_Change(0);
        }
        else if (LevelUp.s_LevelNumber == 5)
        {
            is_on_BG_change = true;
            BG_Change(1);
        }
        else if (LevelUp.s_LevelNumber == 10)
        {
            is_on_BG_change = true;
            BG_Change(2);
        }
        else if (LevelUp.s_LevelNumber == 15)
        {
            is_on_BG_change = true;
            BG_Change(3);
        }
        else if (LevelUp.s_LevelNumber == 20)
        {
            is_on_BG_change = true;
            BG_Change(4);
        }
        else if (LevelUp.s_LevelNumber == 25)
        {
            is_on_BG_change = true;
            BG_Change(5);
        }
        #endregion
    }

    #endregion

    private void BG_Change(int index)
    {
        if (index < sprites.Length && index >= 0)
            bgRenderer.sprite = sprites[index];
    }
}
