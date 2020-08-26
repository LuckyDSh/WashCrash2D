using UnityEngine;

public class Rotator : MonoBehaviour
{
    public GameObject obj;
    public float rotationSpeed = 0.5f;
    float angle = 10f;
    float currentAngle;

    private void Start()
    {
        currentAngle = obj.transform.rotation.z;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        angle += transform.rotation.z * Time.fixedDeltaTime;
        angle = Mathf.Lerp(transform.rotation.z, angle, rotationSpeed);

        currentAngle = angle;
    }
}
