using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerLab4 : MonoBehaviour
{
    public float moveSpeed = 5f;
    private Vector3 spawnPosition;
    private Rigidbody2D rb;
    private Vector2 movement;

    void Start()
    {
        spawnPosition = GameObject.Find("SpawnPlace").transform.position;
        rb = GetComponent<Rigidbody2D>();
        rb.gravityScale = 0;
        rb.freezeRotation = true;
    }

    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");
        movement = movement.normalized;
    }

    void FixedUpdate()
    {
        rb.linearVelocity = movement * moveSpeed; // Sửa linearVelocity thành velocity
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Trap"))
        {
            transform.position = spawnPosition;
            rb.linearVelocity = Vector2.zero; // Sửa lỗi linearVelocity
        }
        else if (other.CompareTag("WinPlace"))
        {
            if (OrangeManager.instance.AllOrangesCollected()) // Kiểm tra nếu ăn đủ cam
            {
                SceneManager.LoadScene("SceneWin");
            }
            else
            {
                Debug.Log("Chưa ăn đủ cam! Còn lại: " + (OrangeManager.instance.totalOranges - OrangeManager.instance.orangesCollected));
            }
        }
    }
}
