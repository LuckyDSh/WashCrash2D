using UnityEngine;

public class Enemy : Entity
{
    public int damage = 10;
    public int reward = 1;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Player player = collision.collider.GetComponent<Player>();
        if (player != null)
        {
            Debug.Log("Player Collision ... ");

            FindObjectOfType<AudioManager>().Play("EnemyDie");
            //if (!progression.IsGrowing) player.Takedamage(damage);
            ProgressBar.maxTime += reward;
            LevelBar.progress += reward;
            base.Die();
        }
    }

    public override void Die()
    {       
        //Progression.instance.AddScore(reward);
        base.Die();
    }

    public void Remove()
    {
        base.Die();
    }

}
