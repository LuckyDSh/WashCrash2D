using System.Collections;
using UnityEngine;

public class PlayerDropCollision : MonoBehaviour
{
    #region Declarations
    public GameObject player;
    public float slowDownDuration = 2f;
    public Transform target;
    bool isCatched = false;

    private Rigidbody2D rb;
    private new Collider2D collider;
    private float mass;
    private float gravity;
    private Vector2 position;
    private Quaternion rotation;

    AudioManager audioManager;
    #endregion

    private void Start()
    {
        if (player == null)
            return;

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

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "Player") 
        {
            audioManager.Play("PlayerInBubble");
            StartCoroutine(SlowDown());
        }
    }

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
}
