using UnityEngine;

public class TrapWheelRotation : MonoBehaviour
{
    // Tốc độ quay (độ mỗi giây)
    public float rotationSpeed = 100f;

    void Update()
    {
        // Quay quanh trục Y (trục thẳng đứng)
        transform.Rotate(Vector3.up * rotationSpeed * Time.deltaTime);
    }
}
