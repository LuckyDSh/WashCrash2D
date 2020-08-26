/*  
*	TickLuck team
*	All rights reserved
*/

/// <summary>
/// This class we serialize in SaveLoad()
/// used for UI display in main menu
/// </summary>
[System.Serializable]
public class PlayerProgress
{
    #region Variables
    public int s_score;
    public int s_enemyKilled;
    public string s_timeOfPlay;
    public int s_moneyAmount;
    #endregion

    public void LoadPlayer()
    {
        PlayerProgress data = SaveSystem.LoadPlayer();

        s_score = data.s_score;
        s_enemyKilled = data.s_enemyKilled;
        s_timeOfPlay = data.s_timeOfPlay;
        s_moneyAmount = data.s_moneyAmount;
    }
}