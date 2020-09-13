/*
* TickLuck Team
* All rights reserved
*/

using BayatGames.SaveGameFree;
using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class Player : Entity
{
    #region Variables
    private float time_overall;
    public static string time_txt = "0";
    private bool timeIsOn;
    public GameObject armorEffect;
    public GameObject rebornEffect;
    public GameObject freezeEffect;
    [Range(1, 10)] private int number_of_record = 1;
    [SerializeField] public GameObject GO_ui;
    private Image ui_extraLife;
    [SerializeField] private int timeFreeze = 3;
    public static bool is_extraLife;
    private float multiplier;
    #endregion

    #region Unity Methods 
    private void Start()
    {
        multiplier = 0;
        is_extraLife = false;
        time_overall = 0;
        timeIsOn = true;
        ui_extraLife = GameObject.FindGameObjectWithTag("ExtraLife").GetComponent<Image>();
    }

    private void Update()
    {
        if (timeIsOn)
        {
            time_overall += Time.deltaTime;
            string minutes = Mathf.Floor((time_overall % 3600) / 60).ToString("00");
            string seconds = Mathf.Floor(time_overall % 60).ToString("00");
            string milliseconds = ((time_overall % 0.99) + 100).ToString("00");

            time_txt = minutes + ":" + seconds + ":" + milliseconds;
            PlayerScoreRecorder.s_recorder_instance.timeOfPlay = time_txt;
        }

        if (ProgressBar.s_meltBarSlider.value <= 0)
        {
            if (is_extraLife)
            {
                rebornEffect.SetActive(true);
                ui_extraLife.enabled = false;
                ProgressBar.s_meltBarSlider.value = ProgressBar.s_meltBarSlider.maxValue;
                ProgressBar.maxTime = ProgressBar.initialTime;
                is_extraLife = false;
            }
            else
            {
                Die();
            }
        }

        //if (GameOver.meltBar.value == 0) // min value
        //{
        //    if (is_extraLife)
        //    {
        //        rebornEffect.SetActive(true);
        //        ui_extraLife.enabled = false;
        //        is_extraLife = false;
        //        GameOver.meltBar.value = GameOver.meltBar.maxValue;
        //    }
        //    else
        //    {
        //        Die();
        //    }
        //}
    }
    #endregion

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "EnemyRed")
        {
            if (is_extraLife)
            {
                rebornEffect.SetActive(true);
                ui_extraLife.enabled = false;
                is_extraLife = false;
            }
            else
            {
                Die();
            }
        }

        if (collision.collider.tag == "EnemyBlue")
        {
            StartCoroutine(Freeze());
        }
    }

    #region DIE()
    public override void Die()
    {
        timeIsOn = false;
        time_overall = 0;
        AudioManager.instance.Play("PlayerDie");

        base.deathEffect.SetActive(true);
        gameObject.GetComponent<Collider2D>().enabled = false;
        gameObject.GetComponent<SpriteRenderer>().enabled = false;

        GO_ui.SetActive(true);

        PlayerProgress playerInfo = new PlayerProgress();

        playerInfo.s_score = PlayerScoreRecorder.s_recorder_instance.m_score;
        playerInfo.s_enemyKilled = PlayerScoreRecorder.s_recorder_instance.m_enemyKilled;
        playerInfo.s_timeOfPlay = PlayerScoreRecorder.s_recorder_instance.timeOfPlay;
        playerInfo.s_moneyAmount = PlayerScoreRecorder.s_recorder_instance.moneyAmount;
        //SaveSystem.SavePlayer(playerInfo);

        // creating 9 copies of data for cards in main menu
        string num = number_of_record.ToString();

        if (number_of_record == 9)
        {
            number_of_record = 1;
        }
        else
        {
            number_of_record++;
        }
        // there is only one obj stored after game
        SaveGame.Save<PlayerProgress>("PlayerProgress", playerInfo);

        // GameManager Script
        base.Die(); // effect of death will be called second time here
    }
    #endregion

    private IEnumerator Freeze()
    {
        PlayerMovement._rb.velocity /= 2f;
        freezeEffect.SetActive(true);

        //while (multiplier < 2)
        //{
        //    yield return new WaitForSeconds(0.1f);
        //    multiplier += 10f * Time.fixedDeltaTime;
        //}
        yield return new WaitForSeconds(timeFreeze);

        freezeEffect.SetActive(false);
        while (multiplier < 4)
        {
            if (multiplier == 3)
                multiplier -= 0.1f;

            PlayerMovement._rb.velocity *= (0.5f + multiplier / 10);
            multiplier++;
        }
        multiplier = 0;
    }
}