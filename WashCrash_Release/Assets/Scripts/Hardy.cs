/*  
*	TickLuck team
*	All rights reserved
*/

using System.Collections;
using UnityEngine;

public class Hardy : MonoBehaviour
{
    #region Variables
    [SerializeField] private float reload_time = 4f;
    [SerializeField] private GameObject hardy_effect;
    private bool is_Hard;
    private float reload_time_buffer;
    private GameObject block_to_destroy;
    private GameObject block_destroy_effect_byffer;
    #endregion

    #region UnityMethods

    void Start()
    {
        is_Hard = false;
    }

    void Update()
    {
        if(Time.time > reload_time_buffer)
        {
            StartCoroutine(Hard());
            reload_time_buffer += Time.time + reload_time;
        }
    }

    #endregion

    private IEnumerator Hard()
    {
        is_Hard = true;

        yield return new WaitForSeconds(reload_time);

        is_Hard = false;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(is_Hard && collision.collider.tag == "Block")
        {
            block_to_destroy = collision.gameObject;
            block_destroy_effect_byffer = block_to_destroy.GetComponent<BlockDestroy>().destroy_effect;

            Instantiate(block_destroy_effect_byffer, transform.position, Quaternion.identity);

            Destroy(block_destroy_effect_byffer);
            Destroy(block_to_destroy);
        }
    }
}
