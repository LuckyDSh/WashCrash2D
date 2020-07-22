/*
* TickLuck Team
* All rights reserved
*/

using UnityEngine;
using UnityEngine.UI;

public class GameOver : MonoBehaviour
{

    #region Variables
    public Slider meltBar;
    public GameObject gameOverUI;
    #endregion

    #region Unity Methods

    void Update()
    {
        if (meltBar.value == meltBar.minValue)
        {
            gameOverUI.SetActive(true);
            //StartCoroutine(LevelUp.LoadNewScene(5));
        }
    }

    #endregion
}
