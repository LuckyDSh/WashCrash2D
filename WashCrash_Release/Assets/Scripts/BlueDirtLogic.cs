/*  
*	TickLuck team
*	All rights reserved
*/

using System.Collections;
using UnityEngine;

public class BlueDirtLogic : MonoBehaviour
{
    #region Variables
    [SerializeField]
    private float timeFreeze = 1f;
    #endregion

    #region UnityMethods

    #endregion

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "Player")
        {
            StartCoroutine(Freeze());
        }
    }

    private IEnumerator Freeze()
    {
        PlayerMovement._rb.velocity /= 2f;

        yield return new WaitForSeconds(timeFreeze);

        PlayerMovement._rb.velocity *= 2f;
    }
}
