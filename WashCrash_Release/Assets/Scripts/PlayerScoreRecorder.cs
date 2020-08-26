/*  
*	TickLuck team
*	All rights reserved
*/

using UnityEngine;
/// <summary>
/// Class that contain Player info 
/// during the game 
/// </summary>
[System.Serializable]
public class PlayerScoreRecorder: MonoBehaviour
{
    #region Variables
    // Modified in Enemy Script
    [HideInInspector] public int m_score = 0;
    [HideInInspector] public int m_enemyKilled = 0;
    // Modified in Player Script
    [HideInInspector] public string timeOfPlay = "0";
    // Modified PlayerDropCollision script
    [HideInInspector] public int moneyAmount = 0;
    #endregion

    #region Singleton
    public static PlayerScoreRecorder s_recorder_instance = null;

    private void Awake()
    {
        s_recorder_instance = this;

        if (s_recorder_instance == null)
        {
            Debug.Log("No instance");
            return;
        }

        s_recorder_instance.m_score = 0;
        s_recorder_instance.m_enemyKilled = 0;
        s_recorder_instance.timeOfPlay = "0";
        s_recorder_instance.moneyAmount = 0;
    }
    #endregion

    #region Ctor with PLAYER PROGRESS as param
    public PlayerScoreRecorder(PlayerProgress player)
    {
        m_score = player.s_score;
        m_enemyKilled = player.s_enemyKilled;
        timeOfPlay = player.s_timeOfPlay;
        moneyAmount = player.s_moneyAmount;
    }
    #endregion
}