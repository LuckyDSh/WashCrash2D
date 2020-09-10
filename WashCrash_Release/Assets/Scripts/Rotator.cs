using UnityEngine;

public class Rotator : MonoBehaviour
{
    [SerializeField] private GameObject obj;
    [SerializeField] private float rotationSpeed = 5f;
    float angle = 10f;

    // Update is called once per frame
    void FixedUpdate()
    {
        angle += transform.rotation.z * Time.fixedDeltaTime;
        angle = Mathf.Lerp(transform.rotation.z, angle, rotationSpeed);

        obj.GetComponent<Rigidbody2D>().MoveRotation(angle);
        obj.transform.Rotate(0f, 0f, angle);
    }
}
