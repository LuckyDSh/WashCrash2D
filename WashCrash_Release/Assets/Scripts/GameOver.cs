/*
* TickLuck Team
* All rights reserved
*/

using UnityEngine;
using UnityEngine.UI;

public class GameOver : MonoBehaviour
{

    #region Variables
    public static Slider meltBar;
    public GameObject gameOverUI;
    #endregion

    #region Unity Methods

    private void Start()
    {
        Slider slider = FindObjectOfType<Slider>();
        if (slider.tag == "MeltBar")
            meltBar = slider;
        meltBar.value = meltBar.maxValue;
        gameOverUI.SetActive(false);
    }

    void Update()
    {
        // add condition when player is dead
        if (meltBar.value == meltBar.minValue)
        {
            gameOverUI.SetActive(true);
            // second part of this event is in Player script
        }
    }

    #endregion
}