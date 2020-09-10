/*  
*	TickLuck team
*	All rights reserved
*/

using UnityEngine;

public class Volty : MonoBehaviour
{
    #region Variables
    [SerializeField] private float reload_time = 5f;
    [SerializeField] private float radius = 2f;
    [SerializeField] private GameObject volty_effect;
    [SerializeField] private GameObject volty_btn;
    private float reload_time_buffer;
    #endregion

    #region UnityMethods

    private void Start()
    {
        reload_time_buffer = reload_time;
    }

    void Update()
    {
        if (Time.time > reload_time_buffer)
        {
            volty_btn.SetActive(true);
            reload_time_buffer += Time.time + reload_time;
        }
    }

    #endregion

    public void Volty_shot()
    {
        Instantiate(volty_effect, transform.position, transform.rotation);
        Collider2D colliders = Physics2D.OverlapCircle(transform.position, radius);

        Enemy enemy = colliders.GetComponent<Enemy>();

        if (enemy != null)
        {
            enemy.volty_effect.SetActive(true);
            enemy.Die();
        }
    }
}
