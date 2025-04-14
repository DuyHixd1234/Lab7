using UnityEngine;

public class Wheel : MonoBehaviour
{
    public float rotationSpeed = 100f;  // Tốc độ quay
    public float pushForce = 10f;       // Lực đẩy nhân vật

    private void Update()
    {
        // Quay bánh xe ngược lại
        transform.Rotate(0, 0, -rotationSpeed * Time.deltaTime);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player")) // Nếu chạm vào nhân vật
        {
            Rigidbody2D playerRb = collision.gameObject.GetComponent<Rigidbody2D>();
            if (playerRb != null)
            {
                // Tính hướng đẩy
                Vector2 pushDirection = (collision.transform.position - transform.position).normalized;

                // Thêm lực đẩy mạnh hơn
                playerRb.linearVelocity = Vector2.zero;
                playerRb.AddForce(pushDirection * pushForce, ForceMode2D.Impulse);
            }
        }
    }
}
