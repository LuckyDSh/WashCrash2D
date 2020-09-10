/*  
*	TickLuck team
*	All rights reserved
*/

using BayatGames.SaveGameFree;
using UnityEngine;
using UnityEngine.UI;

public class MoneyController : MonoBehaviour
{
    #region Variables
    [SerializeField] private Text money_amount;
    [HideInInspector] public static int number;
    public static bool game_is_over = false;
    private PlayerProgress progress;
    #endregion

    #region UnityMethods
    void Start()
    {
        //number = SaveGame.Load<int>("Money");
        progress = SaveGame.Load<PlayerProgress>("PlayerProgress");
        if (progress != null && game_is_over)
        {
            number += progress.s_moneyAmount;

            if (number >= 1000000)
            {
                float temp = number;
                money_amount.text = (temp / 1000000).ToString() + " m";
            }
            else
            {
                money_amount.text = number.ToString();
            }
            game_is_over = false;
            progress.s_moneyAmount = 0;
            SaveGame.Save("PlayerProgress", progress);
        }
    }

    private void OnEnable()
    {
        number = SaveGame.Load<int>("Money");
        game_is_over = true;
    }

    private void OnDisable()
    {
        SaveGame.Save("Money", number);
    }
    #endregion
}
