
using BayatGames.SaveGameFree;
using UnityEngine;

public class Player : Entity
{
    #region Variables
    private float time_overall;
    public static string time_txt = "0";
    private bool timeIsOn;
    [Range(1, 10)] private int number_of_record = 1;
    [SerializeField] private GameObject GO_ui;
    #endregion

    #region Unity Methods 
    private void Start()
    {
        time_overall = 0;
        timeIsOn = true;
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
            Die();
        }

        if (GameOver.meltBar.value == 0) // min value
        {
            Die();
        }
    }
    #endregion

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "EnemyRed")
        {
            Die();
        }
    }

    #region DIE()
    public override void Die()
    {
        timeIsOn = false;
        time_overall = 0;
        FindObjectOfType<AudioManager>().Play("PlayerDie");

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
}