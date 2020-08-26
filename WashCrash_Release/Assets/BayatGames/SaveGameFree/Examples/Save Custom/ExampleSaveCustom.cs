using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace BayatGames.SaveGameFree.Examples
{

    public class ExampleSaveCustom : MonoBehaviour
    {

        [System.Serializable]
        public struct Level
        {
            public bool unlocked;
            public bool completed;

            public Level(bool unlocked, bool completed)
            {
                this.unlocked = unlocked;
                this.completed = completed;
            }
        }

        [System.Serializable]
        public class CustomData
        {

            public int score;
            public int enemyKilled;
            public string time_of_play;
            public int money_amount;
          

            public CustomData()
            {
                score = 0;
                enemyKilled = 0;
                time_of_play = "00:00:00";
                money_amount = 0;
            }

        }

        public CustomData customData;
        public bool loadOnStart = true;
        public InputField scoreInputField;
        public InputField highScoreInputField;
        public string identifier = "exampleSaveCustom";

        void Start()
        {
            if (loadOnStart)
            {
                Load();
            }
        }

        public void SetScore(string score)
        {
            customData.score = int.Parse(score);
        }

        public void SetHighScore(string enemyNum)
        {
            customData.enemyKilled = int.Parse(enemyNum);
        }

        public void SetTimeOfPlay(string time)
        {
            customData.time_of_play = time;
        }

        public void SetMoney(string money)
        {
            customData.money_amount = int.Parse(money);
        }


        public void Save()
        {
            SaveGame.Save<CustomData>(identifier, customData, SerializerDropdown.Singleton.ActiveSerializer);
        }

        public void Load()
        {
            customData = SaveGame.Load<CustomData>(
                identifier,
                new CustomData(),
                SerializerDropdown.Singleton.ActiveSerializer);
            scoreInputField.text = customData.score.ToString();
            //highScoreInputField.text = customData.highScore.ToString();
        }

    }

}