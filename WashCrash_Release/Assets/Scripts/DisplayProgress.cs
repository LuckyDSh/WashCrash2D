/*  
*	TickLuck team
*	All rights reserved
*/

using UnityEngine;
using UnityEngine.UI;

public class DisplayProgress : MonoBehaviour
{
    #region Variables
    [SerializeField] private Text time_txt;
    [SerializeField] private Text score_txt;
    [SerializeField] private Text money_txt;
    [SerializeField] private Text enemyKilled_txt;
    #endregion

    #region UnityMethods
    void Awake()
    {
        time_txt.text = "0";
        score_txt.text = "0";
        money_txt.text = "0";
        enemyKilled_txt.text = "0";
    }

    void Update()
    {
        time_txt.text = PlayerScoreRecorder.s_recorder_instance.timeOfPlay.ToString();
        score_txt.text = PlayerScoreRecorder.s_recorder_instance.m_score.ToString();
        money_txt.text = PlayerScoreRecorder.s_recorder_instance.moneyAmount.ToString();
        enemyKilled_txt.text = PlayerScoreRecorder.s_recorder_instance.m_enemyKilled.ToString();
    }
    #endregion
}
