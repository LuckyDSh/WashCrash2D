/*  
*	TickLuck team
*	All rights reserved
*/

using UnityEngine;

public class Bomb : MonoBehaviour
{
    #region Variables
    [SerializeField] private GameObject explode_effect;
    #endregion

    #region UnityMethods

    void Start()
    {

    }

    void Update()
    {

    }

    void FixedUpdate()
    {

    }

    #endregion

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Instantiate(explode_effect, transform.position, Quaternion.identity);
       Enemy enemy = collision.collider.GetComponent<Enemy>();

        if (enemy)
        {
            enemy.Damage(collision);
        }

        Destroy(gameObject);
    }
}
