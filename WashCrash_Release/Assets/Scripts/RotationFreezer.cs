/*
* TickLuck Team
* All rights reserved
*/

using UnityEngine;

public class RotationFreezer : MonoBehaviour
{
   public Rigidbody2D rb;
    RigidbodyConstraints2D rbc;

    // Start is called before the first frame update
    void Start()
    {
        rbc = rb.GetComponent<RigidbodyConstraints2D>();
        rbc = RigidbodyConstraints2D.FreezeRotation;
    }

}
