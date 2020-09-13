/*
* TickLuck Team
* All rights reserved
*/

using UnityEngine;

public class AvoidPoint : MonoBehaviour
{
    public float radius = 5f;

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawSphere(transform.position, radius);
    }
}
