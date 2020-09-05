/*  
*	TickLuck team
*	All rights reserved
*/

using System.Collections;
using UnityEngine;

public class WhiteDirtLogic : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.collider.tag == "Enemy")
        {
            Accelerate(collision);
        }
    }

    private IEnumerator Accelerate(Collision2D collision)
    {
        EnemyAI logic = collision.collider.GetComponent<EnemyAI>();
        logic.moveSpeed += 5;

        yield return new WaitForSeconds(3f);

        logic.moveSpeed -= 5;
    }
}
