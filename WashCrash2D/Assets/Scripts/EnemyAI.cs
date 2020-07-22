﻿using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    #region Declarations
    private static List<Rigidbody2D> EnemyRBs;
    public Collider2D colliders;
    public Animator animator; 
    [Header("Movement")]
    [Space]
    public float moveSpeed = 4f;
    public float smoothedSpeed = 0.5f;
    [Range(0f, 1f)]
    public float turnSpeed = .1f;
    [Header("RepelForce")]
    [Space]
    public float repelRange = .5f;
    public float repelAmount = 5f;
    [Header("Chasing")]
    [Space]
    public float startMinChaseDistance = 5f;
    public float minChaseDistance;
    public float maxChaseDistance = 20f;
    Rigidbody2D rb;
    new Collider2D collider;
    #endregion

    // Initialization
    void Start()
    {
        collider = GetComponent<Collider2D>();
        rb = GetComponent<Rigidbody2D>();
        if (EnemyRBs == null) EnemyRBs = new List<Rigidbody2D>();

        EnemyRBs.Add(rb);
    }

    private void FixedUpdate()
    {
        Vector2 direction = (rb.position - PlayerMovement.Position).normalized;
        Vector2 newPos;

        if (false) { /* place behaviour of other enemy types here */ }
        else
        { 
            newPos = MoveRegular(direction);
            rb.MovePosition(newPos);
        }
    }

    private void OnDestroy()
    {
        EnemyRBs.Remove(rb);
    }

    // Motion, avoidence from other enemies and player
    #region MoveRegular
    Vector2 MoveRegular(Vector2 direction)
    {

        // REPEL FORCE FOR ENEMIES

        Vector2 repelForce = Vector2.zero;
        minChaseDistance = startMinChaseDistance /** Progression.Growth*/;
       
        Vector2 newPos = transform.position /*+ transform.up * Time.fixedDeltaTime * moveSpeed*/; // LOOK HERE

        foreach (var enemy in EnemyRBs)
        {
            if (enemy == rb) continue;
            if (Vector2.Distance(enemy.position, rb.position) <= repelRange) // Separating enemies
            {
                Vector2 repelDir = (rb.position - enemy.position).normalized; 
                repelForce += repelDir;
            } 
        }

        // REPEL FORCE FOR PLAYER

        float distance = Vector2.Distance(rb.position, PlayerMovement.Position);
        if (distance >= minChaseDistance) animator.SetBool("isMoving", false);
        else
        {
            animator.SetBool("isMoving", true);
            // Separating enemy and player
            newPos += direction * Time.fixedDeltaTime * moveSpeed;
        }

        if (distance > maxChaseDistance) 
        {
            Destroy(gameObject);
            return Vector2.zero;
        }
        
        newPos += repelForce * Time.fixedDeltaTime * repelAmount;
        newPos = Vector2.Lerp(transform.position, newPos, smoothedSpeed);
        return newPos;
    }
    #endregion

    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawSphere(transform.position, minChaseDistance);
    }

}
