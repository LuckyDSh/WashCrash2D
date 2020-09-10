﻿using UnityEngine;

public class Enemy : Entity
{
    public int damage = 10;
    public int reward = 1;
    public GameObject freezy_effect;
    public GameObject volty_effect;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Damage(collision);
    }

    public void Damage(Collision2D collision)
    {
        Player player = collision.collider.GetComponent<Player>();
        if (player != null)
        {
            // Add logic to kill Bosses 
            // by every hit take damage

            if (gameObject.tag == "GreenBoss" || gameObject.tag == "BlueBoss" || gameObject.tag == "RedBoss")
            {
                TakeDamage(damage);
            }
            else
            {
                Die();
            }

            //base.Die();
        }
    }

    public override void Die()
    {
        PlayerScoreRecorder.s_recorder_instance.m_score += reward;
        PlayerScoreRecorder.s_recorder_instance.m_enemyKilled++;

        FindObjectOfType<AudioManager>().Play("EnemyDie");
        //if (!progression.IsGrowing) player.Takedamage(damage);

        ProgressBar.maxTime += reward;
        LevelBar.progress += reward;
        //Progression.instance.AddScore(reward);
        base.Die();
    }

    public void Remove()
    {
        base.Die();
    }

}
