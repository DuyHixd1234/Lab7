using UnityEngine;

public class WheelPush : MonoBehaviour
{
    public float pushForce = 5f; // Lực đẩy

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Rigidbody2D playerRb = other.GetComponent<Rigidbody2D>();
            if (playerRb != null)
            {
                // Tính hướng đẩy ngược lại từ bánh xe
                Vector2 pushDirection = (other.transform.position - transform.position).normalized;
                playerRb.AddForce(pushDirection * pushForce, ForceMode2D.Impulse);
            }
        }
    }
}
