﻿/*  
*	TickLuck team
*	All rights reserved
*/

using UnityEngine;

public class BlackDirtLogic : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "Enemy")
        {
            Destroy(collision.collider.gameObject.GetComponent<Enemy>());
        }
    }
}
