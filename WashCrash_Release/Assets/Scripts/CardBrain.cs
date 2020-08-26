/*  
*	TickLuck team
*	All rights reserved
*/

using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CardBrain : MonoBehaviour
{
    #region Variables
    [SerializeField] public int score;
    [SerializeField] public string time;
    [SerializeField] public int enemyKilled;
    [SerializeField] public Image numberOfCard;
    [SerializeField] public TextMeshProUGUI score_txt;
    [SerializeField] public TextMeshProUGUI time_txt;
    [SerializeField] public TextMeshProUGUI enemyKilled_txt;
    #endregion

    #region UnityMethods
    void Start()
    {
        score_txt.text = score.ToString();
        time_txt.text = time;
        enemyKilled_txt.text = enemyKilled.ToString();

        // assign the card 
        // use the object of Progress to store and load the data
        // make calculations to place cards at right positions
        // disable cards if their score is less then the previous one 
    }

    //private void OnDisable()
    //{
    //    BinaryFormatter formatter = new BinaryFormatter();
    //    string path = Application.persistentDataPath + "cardData.card";
    //    FileStream stream = new FileStream(path, FileMode.Create);
    //}
    #endregion
}
