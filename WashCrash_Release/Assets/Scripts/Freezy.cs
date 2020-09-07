/*  
*	TickLuck team
*	All rights reserved
*/

using System.Collections;
using UnityEngine;

public class Freezy : MonoBehaviour
{
    #region Variables
    [SerializeField] private float radius = 4f;
    [SerializeField] private float freeze_amount = 2f;
    [SerializeField] private float timeOfImpact = 2f;
    [SerializeField] private GameObject freezeEffect;
    [SerializeField] private float reloadTime = 3f;
    private float delayTime;
    #endregion

    #region UnityMethods

    void Start()
    {
        delayTime = reloadTime;
    }

    void Update()
    {
        if (Time.time >= reloadTime)
        {
            StartCoroutine(Freeze());
            reloadTime += Time.time + delayTime;
        }
    }

    #endregion

    IEnumerator Freeze()
    {
        Instantiate(freezeEffect, transform.position, transform.rotation);
        Collider2D colliders = Physics2D.OverlapCircle(transform.position, radius); // now captures only one collider
        colliders.GetComponent<EnemyAI>().moveSpeed /= freeze_amount;

        yield return new WaitForSeconds(timeOfImpact);

        colliders.GetComponent<EnemyAI>().moveSpeed *= freeze_amount;

        yield return null;
    }
}
