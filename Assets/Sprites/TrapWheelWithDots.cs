using UnityEngine;

public class TrapWheelWithDots : MonoBehaviour
{
    public int numberOfDots = 12; // Số lượng dấu chấm trên bánh xe
    public float radius = 2f; // Bán kính vòng tròn
    public float rotationSpeed = 100f; // Tốc độ quay bánh xe

    private GameObject[] dots;

    void Start()
    {
        // Tạo các dấu chấm quanh hình tròn
        dots = new GameObject[numberOfDots];
        for (int i = 0; i < numberOfDots; i++)
        {
            float angle = i * Mathf.PI * 2 / numberOfDots; // Góc giữa mỗi dấu chấm
            Vector3 dotPosition = new Vector3(Mathf.Cos(angle) * radius, Mathf.Sin(angle) * radius, 0);
            dots[i] = new GameObject("Dot_" + i); // Tạo một đối tượng mới để làm dấu chấm
            dots[i].transform.position = transform.position + dotPosition; // Đặt vị trí dấu chấm
            dots[i].transform.SetParent(transform); // Đảm bảo dấu chấm quay cùng bánh xe
            // Bạn có thể gán sprite cho dấu chấm tại đây nếu cần
        }
    }

    void Update()
    {
        // Quay bánh xe quanh tâm
        transform.Rotate(Vector3.forward * rotationSpeed * Time.deltaTime);
    }
}
