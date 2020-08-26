/*  
*	TickLuck team
*	All rights reserved
*/

using BayatGames.SaveGameFree;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RecordsController : MonoBehaviour
{
    #region Variables
    [SerializeField] public CardBrain[] recordCards;
    [SerializeField] private RectTransform[] spawnPoints;
    [SerializeField] private Image[] numbers;
    private static List<int> previousRecords;
    #endregion

    #region UnityMethods
    void Awake()
    {
        #region OLD SAVE SYSTEM
        //recordCards[0] = FindObjectOfType<CardBrain>();
        //if (recordCards[0].isActiveAndEnabled)
        //    Debug.Log("Success");

        //PlayerProgress playerProgress = SaveSystem.LoadPlayer();
        //PlayerProgress progress = playerProgress;

        //recordCards[0].score = progress.s_score;
        //recordCards[0].time = progress.s_timeOfPlay;
        //recordCards[0].enemyKilled = progress.s_enemyKilled;
        #endregion

        for (int i = 0; i < recordCards.Length-1; i++)
        {
            CardBrain card = GameObject.Find("Record0" + (i + 1)).GetComponent<CardBrain>();
            PlayerProgress progress = SaveGame.Load<PlayerProgress>("PlayerProgress0" + (i + 1));

            if(progress == null)          
                return;

            card.gameObject.SetActive(true); //  think of better represantation

            card.score = progress.s_score;
            card.enemyKilled = progress.s_enemyKilled;
            card.time = progress.s_timeOfPlay;
        }
        
        // load info
        //recordCards = Loadinfo();      
    }

    private void Start()
    {

    }
    
    private void OnEnable()
    {
        //if (recordCards != null)
        //    QuickSort(recordCards, 0, recordCards.Length - 1);

        for (int i = 0; i < (recordCards.Length - 1); i++)
        {
            recordCards[i].gameObject.GetComponent<RectTransform>().position = spawnPoints[i].position;
            Debug.Log("Assigned...");
        }

        // work on placing cards on right positions
    }

    private void OnDisable()
    {
        // srore info 
        //SaveInfo();
    }
    #endregion

    #region Save and Load Cards Info
#if false
    private void SaveInfo()
    {
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "/progress.tl";

        FileStream file = new FileStream(path, FileMode.Create);
        formatter.Serialize(file, recordCards);

        file.Close();
    }

    private CardBrain[] Loadinfo()
    {
        string path = Application.persistentDataPath + "/cardSave.tl";

        if (File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream file = new FileStream(path, FileMode.Open);

            CardBrain[] cards = formatter.Deserialize(file) as CardBrain[];
            file.Close();

            return cards;
        }
        else
        {
            Debug.LogError("File is not found in " + path);
            return null;
        }
    }
#endif
    #endregion

    #region QuickSort
    public void QuickSort(CardBrain[] arr, int left, int right)
    {
        int l = left;
        int r = right;
        int size = right - left;

        if (size > 1)
        {
            System.Random rand = new System.Random();
            int pivot = arr[rand.Next(0, size) + l].score;

            Debug.Log(pivot);

            while (l < r) // comparing the cards by score
            {
                while (arr[r].score > pivot && r > l)
                {
                    r--;
                }
                while (arr[l].score < pivot && l <= r)
                {
                    l++;
                }
                if (l < r) // here we swap cards
                {
                    CardBrain temp = arr[l];
                    arr[l] = arr[r];
                    arr[r] = temp;
                    l++;
                }
            }

            QuickSort(arr, left, l);
            QuickSort(arr, r, right);
        }
    }

    #endregion
}
