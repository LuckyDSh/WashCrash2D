
public class Player : Entity
{

    private void Update()
    {
        if (ProgressBar.maxTime <= 0)
        {
            Die();
        }
    }

    public override void Die()
    {

        FindObjectOfType<AudioManager>().Play("PlayerDie");
        // GameManager Script
        base.Die();
    }
}
