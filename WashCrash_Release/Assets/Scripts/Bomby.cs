/*  
*	TickLuck team
*	All rights reserved
*/

using UnityEngine;

public class Bomby : MonoBehaviour
{
    #region Variables
    [SerializeField] private GameObject bomb_Pref;
    [SerializeField] private float reload_time = 3f;
    [SerializeField] private GameObject bomb_effect;
    [SerializeField] private float force = 2f;
    [SerializeField] private GameObject bomby_btn;
    private float reload_time_buffer;
    private GameObject bomb_Pref_buffer;
    #endregion

    #region UnityMethods

    void Start()
    {
        reload_time_buffer = reload_time;
    }

    void Update()
    {
        if (Time.time > reload_time_buffer)
        {
            bomby_btn.SetActive(true);
            reload_time_buffer += Time.time + reload_time;
        }
    }

    #endregion

    public void Bombardment()
    {
        GameObject effect = Instantiate(bomb_effect, transform.position, Quaternion.identity);
        bomb_Pref_buffer = Instantiate(bomb_Pref, transform.position, transform.rotation);

        bomb_Pref_buffer.GetComponent<Rigidbody2D>().AddForce(Vector2.up * force, ForceMode2D.Impulse);
        Destroy(effect);
    }
}
