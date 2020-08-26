using System.Collections;
using UnityEngine;

public class PlayerDropCollision : MonoBehaviour
{
    #region Declarations
    public float slowDownDuration = 2f;
    Transform target;
    bool isCatched = false;
    [SerializeField]
    private int moneyAmount = 10;
    [SerializeField]
    private float timeOfFreeze = 3f;

    private GameObject player;
    private Rigidbody2D rb;
    private new Collider2D collider;
    private float mass;
    private float gravity;
    private Vector2 position;
    private Quaternion rotation;

    AudioManager audioManager;
    #endregion

    #region UnityMethods

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");

        if (player == null)
            return;

        target = GetComponent<Transform>();

        rb = player.GetComponent<Rigidbody2D>();
        collider = player.GetComponent<Collider2D>();
        audioManager = FindObjectOfType<AudioManager>();

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
            if (gameObject.tag == "Drop")
            {
                audioManager.Play("PlayerInBubble");
                StartCoroutine(SlowDown());
            }

            if (gameObject.tag == "SpecialDrop(Coin)")
            {
                AddCoin();
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

    private void AddCoin()
    {
        audioManager.Play("BubblePop");
        PlayerScoreRecorder.s_recorder_instance.moneyAmount += moneyAmount;

        Destroy(gameObject);
    }

    private IEnumerator StopTime()
    {
        audioManager.Play("BubblePop");
        ProgressBar.isOn = false;
        GetComponent<Collider2D>().enabled = false;
        GetComponent<SpriteRenderer>().enabled = false;
        transform.GetChild(0).gameObject.SetActive(false);

        yield return new WaitForSeconds(timeOfFreeze);

        ProgressBar.isOn = true;
        Destroy(gameObject);
    }

    private IEnumerator Armor()
    {
        audioManager.Play("BubblePop");
        GetComponent<Collider2D>().enabled = false;
        GetComponent<SpriteRenderer>().enabled = false;

        // activate animation of armor

        // add ability to destroy the bubbles

        yield return new WaitForSeconds(timeOfFreeze);

        // undo changes

        Destroy(gameObject);
    }

    private void ExtraLife()
    {
        // add the life so that even if time is off we can continue the game but the time this time will be 0.5s less 

        // add the icon of the extra life to the UI

        // make sure to take only one such a drop in the level
    }

    public IEnumerator SlowDown()
    {
        isCatched = true;

        yield return new WaitForSeconds(slowDownDuration);

        isCatched = false;
        UnDo();
    }

    private void OnDestroy()
    {
        if (isCatched)
        {
            isCatched = false;
            UnDo();
        }
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
}