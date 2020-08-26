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
    #endregion

    #region UnityMethods
    void Start()
    {
        //number = SaveGame.Load<int>("Money");
        PlayerProgress progress = SaveGame.Load<PlayerProgress>("PlayerProgress");
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
        }
    }

    private void OnDisable()
    {
        SaveGame.Save<int>("Money", number);
    }
    #endregion
}
