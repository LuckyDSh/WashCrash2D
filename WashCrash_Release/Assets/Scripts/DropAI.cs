/*
* TickLuck Team
* All rights reserved
*/

using System.Collections.Generic;
using UnityEngine;

public class DropAI : MonoBehaviour
{

    public float motionSpeed = 1f;
    public float maxChaseDistance = 15f;

    [Header("Repel Force")]
    [Space]
    public float repelAmount = 3f;
    public float repelRange = 3f;
    public float smoothedSpeed = 0.25f;

    private Rigidbody2D rb;
    public static List<Rigidbody2D> dropRBs;

    // Start is called before the first frame update
    public void Start()
    {
        motionSpeed *= Random.Range(0.1f, 1f);

        rb = GetComponent<Rigidbody2D>();

        if (dropRBs == null)
            dropRBs = new List<Rigidbody2D>();

        dropRBs.Add(rb);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "BackGround")
        {
            GetComponent<AudioSource>().Play();
            Destroy(gameObject);
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (rb == null)
            return;

        Vector2 direction = transform.position + transform.up * Time.fixedDeltaTime * motionSpeed;

        Vector2 newPos =  Moveregular(direction);

        float distance = Vector2.Distance(rb.position, PlayerMovement.Position);

        if (distance >= maxChaseDistance)
        {
            Destroy(gameObject);
            return;
        }

        rb.MovePosition(direction); // last change 
    }

    #region MoveRegular
    private Vector2 Moveregular(Vector2 direction)
    {
        if (rb == null)
            return Vector2.zero; 

        Vector2 repelForce = Vector2.zero;
        Vector2 newPos = transform.position;

        foreach (var drop in dropRBs)
        {
            if (drop == rb) continue;

            if (drop == null)
                continue;

            if (Vector2.Distance(drop.position, rb.position) <= repelRange)
            {
                Vector2 repelDir = (rb.position - drop.position).normalized;
                repelForce += repelDir;
            }
        }

        newPos += repelForce * Time.fixedDeltaTime * repelAmount;
        newPos = Vector2.Lerp(transform.position, newPos, smoothedSpeed);

        direction += newPos;

        return direction;
    }
    #endregion
}
