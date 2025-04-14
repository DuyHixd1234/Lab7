using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5f; // Tốc độ di chuyển
    private Vector3 spawnPosition; // Vị trí SpawnPlace
    private Rigidbody2D rb; // Rigidbody2D của nhân vật
    private Vector2 movement; // Vector di chuyển

    void Start()
    {
        // Lưu vị trí SpawnPlace
        spawnPosition = GameObject.Find("SpawnPlace").transform.position;

        // Lấy Rigidbody2D của Player
        rb = GetComponent<Rigidbody2D>();
        rb.gravityScale = 0; // Không có trọng lực
        rb.freezeRotation = true; // Không cho nhân vật xoay
    }

    void Update()
    {
        // Nhận input từ bàn phím
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");
        movement = movement.normalized; // Để tránh di chuyển nhanh hơn theo đường chéo
    }

    void FixedUpdate()
    {
        // Di chuyển bằng Rigidbody2D (không dùng Transform để tránh xuyên tường)
        rb.linearVelocity = movement * moveSpeed;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Trap"))
        {
            // Nếu chạm vào bẫy, quay lại vị trí SpawnPlace
            transform.position = spawnPosition;
            rb.linearVelocity = Vector2.zero; // Reset tốc độ tránh bug
        }
        else if (other.CompareTag("WinPlace"))
        {
            // Nếu chạm vào WinPlace, chuyển sang scene "SceneWin"
            SceneManager.LoadScene("WinScene");
        }
    }
}
    