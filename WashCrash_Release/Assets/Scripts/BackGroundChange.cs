/*  
*	TickLuck team
*	All rights reserved
*/

using UnityEngine;

public class BackGroundChange : MonoBehaviour
{
    #region Variables
    private SpriteRenderer bgRenderer;
    [SerializeField] private Sprite[] sprites;
    #endregion

    #region UnityMethods
    void Start()
    {
        bgRenderer = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        if (LevelUp.s_LevelNumber <= 5)
        {
            BG_Change(0);
        }
        else if (LevelUp.s_LevelNumber <= 10)
        {
            BG_Change(1);
        }
        else if (LevelUp.s_LevelNumber <= 15)
        {
            BG_Change(2);
        }
        else if (LevelUp.s_LevelNumber <= 25)
        {
            BG_Change(3);
        }
        else if (LevelUp.s_LevelNumber <= 35)
        {
            BG_Change(4);
        }
        else if (LevelUp.s_LevelNumber <= 40)
        {
            BG_Change(5);
        }
    }

    #endregion

    private void BG_Change(int index)
    {
        bgRenderer.sprite = sprites[index];
    }
}
