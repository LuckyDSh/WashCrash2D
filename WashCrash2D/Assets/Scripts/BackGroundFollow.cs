
using UnityEngine;

public class BackGroundFollow : MonoBehaviour
{
    [Header("Refs")]
    public Transform target;
    public Rigidbody2D backGroundRb;
    [Header("Parameters")]
    public Vector3 offSet;
    public float moveSpeed = 5f;
    
    private void FixedUpdate()
    {
        if (target == null)
            return;

        backGroundRb.freezeRotation = true;
        Vector3 newPos = target.position * Time.fixedDeltaTime + offSet;
        newPos.z = 0f;
        backGroundRb.MovePosition(newPos * moveSpeed * Time.fixedDeltaTime * 100);
    }
}
