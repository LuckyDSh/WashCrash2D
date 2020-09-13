/*
* TickLuck Team
* All rights reserved
*/

using UnityEngine;

public class Enemy : Entity
{
    public int damage = 10;
    public int reward = 1;
    public GameObject freezy_effect;
    public GameObject volty_effect;
    private GameObject death_effect_buffer;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "BackGround")
        {
            if (gameObject.tag != "GreenBoss" || gameObject.tag != "BlueBoss" || gameObject.tag != "RedBoss")
            {
                //death_effect_buffer = Instantiate(this.deathEffect, transform.position, Quaternion.identity);
                //Destroy(death_effect_buffer,1f);
                Destroy(this.gameObject);
            }
        }
        else
        {
            Damage(collision);
        }

    }

    public void Damage(Collision2D collision)
    {
        Player player = collision.collider.GetComponent<Player>();
        if (player != null)
        {
            // logic to kill Bosses 
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

    #region DIE()
    public override void Die()
    {
        PlayerScoreRecorder.s_recorder_instance.m_score += reward;
        PlayerScoreRecorder.s_recorder_instance.m_enemyKilled++;

        AudioManager.instance.Play("EnemyDie");
        //if (!progression.IsGrowing) player.Takedamage(damage);

        if (ProgressBar.maxTime < ProgressBar.initialTime)
            ProgressBar.maxTime += reward * (LevelBar.decreaser / 10);

        if (LevelBar.progress < LevelBar.slider_maxValue)
            LevelBar.progress += reward * (LevelBar.decreaser / 10);

        //Progression.instance.AddScore(reward);
        base.Die();
    }
    #endregion 

    public void Remove()
    {
        base.Die();
    }
}
