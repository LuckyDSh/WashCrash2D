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
        if (LevelUp.s_LevelNumber <= 4)
        {
            BG_Change(0);
        }
        else if (LevelUp.s_LevelNumber <= 9)
        {
            BG_Change(1);
        }
        else if (LevelUp.s_LevelNumber <= 14)
        {
            BG_Change(2);
        }
        else if (LevelUp.s_LevelNumber <= 24)
        {
            BG_Change(3);
        }
        else if (LevelUp.s_LevelNumber <= 34)
        {
            BG_Change(4);
        }
        else if (LevelUp.s_LevelNumber <= 44)
        {
            BG_Change(5);
        }
    }

    #endregion

    private void BG_Change(int index)
    {
        if (index < sprites.Length)
            bgRenderer.sprite = sprites[index];
    }
}
