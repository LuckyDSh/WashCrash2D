/*
* TickLuck Team
* All rights reserved
*/

using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class PlayerDropCollision : MonoBehaviour
{
    #region Declarations
    public float slowDownDuration = 2f;
    Transform target;
    bool isCatched = false;

    [SerializeField] private int moneyAmount = 10;
    [SerializeField] private float timeOfFreeze = 3f;
    [SerializeField] private Image ui_extraLife;

    private GameObject player;
    private Rigidbody2D rb;
    private new Collider2D collider;
    private float mass;
    private float gravity;
    private Vector2 position;
    private Quaternion rotation;
    private GameObject effect_Buffer;
    private bool is_player_armored = false;
    private Collider2D this_collider2D;
    private SpriteRenderer this_spriteRenderer;

    AudioManager audioManager;
    #endregion

    #region UnityMethods

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        this_collider2D = GetComponent<Collider2D>();
        this_spriteRenderer = GetComponent<SpriteRenderer>();

        if (player == null)
            return;

        target = GetComponent<Transform>();
        ui_extraLife = GameObject.FindGameObjectWithTag("ExtraLife").GetComponent<Image>();

        rb = player.GetComponent<Rigidbody2D>();
        collider = player.GetComponent<Collider2D>();
        audioManager = AudioManager.instance;

        mass = rb.mass;
        gravity = rb.gravityScale;

    }

    private void FixedUpdate()
    {


        if (isCatched && target != null)
        {
            position = target.position;
            rotation = target.rotation;

            Follow(target);
        }
    }

    #endregion

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "Player")
        {
            if (is_player_armored)
            {
                audioManager.Play("BubblePop");
                Destroy(gameObject);
            }
            else
            {
                if (gameObject.tag == "Drop")
                {
                    audioManager.Play("PlayerInBubble");
                    StartCoroutine(SlowDown());
                }

                if (gameObject.tag == "SpecialDrop(Coin)")
                {
                    AddCoin(1); // one coin
                }

                if (gameObject.tag == "SpecialDrop(Coinx2)")
                {
                    AddCoin(2); // two coins
                }

                if (gameObject.tag == "SpecialDrop(Coinx3)")
                {
                    AddCoin(3); // three coins
                }

                if (gameObject.tag == "SpecialDrop(TimerStop)")
                {
                    StartCoroutine(StopTime());
                }

                if (gameObject.tag == "SpecialDrop(ExtraLife)")
                {
                    ExtraLife();
                }

                if (gameObject.tag == "SpecialDrop(Armor)")
                {
                    StartCoroutine(Armor());
                }
            }
        }
    }

    private void OnDestroy()
    {
        if (isCatched)
        {
            isCatched = false;
            UnDo();
        }
    }

    #region Coin Bubble
    private void AddCoin(int multiplier)
    {
        audioManager.Play("BubblePop");
        PlayerScoreRecorder.s_recorder_instance.moneyAmount += moneyAmount * multiplier;

        Destroy(gameObject);
    }
    #endregion

    #region TimeStop Bubble
    private IEnumerator StopTime()
    {
        audioManager.Play("BubblePop");
        ProgressBar.isOn = false;
        this_collider2D.enabled = false;
        this_spriteRenderer.enabled = false;
        transform.GetChild(0).gameObject.SetActive(false);

        yield return new WaitForSeconds(timeOfFreeze);

        ProgressBar.isOn = true;
        Destroy(gameObject);
    }
    #endregion

    #region Armor Bubble
    private IEnumerator Armor()
    {
        audioManager.Play("BubblePop");
        this_collider2D.enabled = false;
        this_spriteRenderer.enabled = false;
        effect_Buffer = player.GetComponent<Player>().armorEffect;

        // activate animation of armor
        effect_Buffer.SetActive(true);

        // add ability to destroy the bubbles
        is_player_armored = true;

        yield return new WaitForSeconds(timeOfFreeze);

        // undo changes
        is_player_armored = false;
        effect_Buffer.SetActive(false);
        Destroy(gameObject);
    }
    #endregion

    #region ExtraLife Bubble
    private void ExtraLife()
    {
        // add the life so that even if time is off we can continue the game but the time this time will be 0.5s less 
        audioManager.Play("BubblePop");
        this_collider2D.enabled = false;
        this_spriteRenderer.enabled = false;

        ui_extraLife.enabled = true;

        // add the icon of the extra life to the UI
        Player.is_extraLife = true;

        Destroy(gameObject);
        // make sure to take only one such a drop in the level
    }
    #endregion

    #region Simple Bubble(Drop)
    public IEnumerator SlowDown()
    {
        isCatched = true;

        yield return new WaitForSeconds(slowDownDuration);

        isCatched = false;
        UnDo();
    }

    void Follow(Transform target)
    {

        if (!collider)
            return;
        collider.enabled = false;
        player.transform.position = target.position;
        player.transform.rotation = target.rotation;
        rb.gravityScale = 0f;
        rb.mass = 0f;
    }

    void UnDo()
    {
        if (!collider)
            return;
        collider.enabled = true;
        player.transform.position = position;
        player.transform.rotation = rotation;
        rb.gravityScale = gravity;
        rb.mass = mass;

        audioManager.Play("BubblePop");
        Destroy(gameObject);
    }
    #endregion
}