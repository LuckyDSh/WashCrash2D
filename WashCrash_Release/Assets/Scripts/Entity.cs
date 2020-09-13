/*
* TickLuck Team
* All rights reserved
*/

using UnityEngine;

public class Entity : MonoBehaviour
{
    public int health = 20;
    public GameObject deathEffect;
    GameObject effect_buffer;

    public void TakeDamage(int amount)
    {
        health -= amount;

        if (health <= 0) Die();
    }

    public virtual void Die()
    {
        effect_buffer = Instantiate(deathEffect, transform.position, transform.rotation);
        //effect.transform.localScale = transform.localScale;
        VibrationController.is_vibrating = true;

        Destroy(effect_buffer, 1f);
        Destroy(gameObject); 
    }
}
