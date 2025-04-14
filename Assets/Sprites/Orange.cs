using UnityEngine;

public class Orange : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player")) // Kiểm tra nếu Player chạm vào cam
        {
            Debug.Log("Player đã ăn cam: " + gameObject.name);

            // Gọi OrangeManager để tăng số cam đã ăn
            OrangeManager.instance.CollectOrange();

            // Hủy đối tượng cam
            Destroy(gameObject);
        }
    }
}
