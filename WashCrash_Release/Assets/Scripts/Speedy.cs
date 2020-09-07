/*  
*	TickLuck team
*	All rights reserved
*/

using System.Collections;
using UnityEngine;

public class Speedy : MonoBehaviour
{
    #region Variables
    [SerializeField] private float accelaration = 1.5f;
    [SerializeField] private float reload_time = 5f;
    [SerializeField] private float duration = 3f;
    [SerializeField] private GameObject speedUp_effect;
    [SerializeField] private GameObject accelaration_btn;
    private float reload_time_buffer;
    #endregion

    #region UnityMethods

    private void Start()
    {
        reload_time_buffer = reload_time;
    }

    void Update()
    {
        if(Time.time > reload_time_buffer)
        {
            StartCoroutine(Accelarate());
            reload_time_buffer += Time.time + reload_time;
        }
    }

    #endregion

    private IEnumerator Accelarate()
    {
        PlayerMovement.moveSpeed *= accelaration;
        speedUp_effect.SetActive(true);

        yield return new WaitForSeconds(duration);

        PlayerMovement.moveSpeed /= accelaration;
        speedUp_effect.SetActive(false);
    }
}
