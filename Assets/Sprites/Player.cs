using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro; // Import TextMeshPro

public class Player : MonoBehaviour
{
    public float moveSpeed = 5f;
    private Rigidbody2D rb;
    private Vector2 movement;

    public int maxLives = 10;
    private int currentLives;
    public TMP_Text livesText; // Text hien thi so mang

    private Vector3 lastSpawnPoint; // Luu vi tri SpawnPlace cuoi cung da cham

    public AudioSource audioSource; // Thêm AudioSource
    public AudioClip trapSound; // Âm thanh khi va chạm với Trap

    void Start()
    {
        // Tim SpawnPlace gan nhat de lam vi tri spawn ban dau
        GameObject spawn = GameObject.FindWithTag("SpawnPlace");
        if (spawn != null)
        {
            lastSpawnPoint = spawn.transform.position;
        }
        else
        {
            Debug.LogWarning("Khong tim thay SpawnPlace! Su dung vi tri mac dinh.");
            lastSpawnPoint = transform.position;
        }

        rb = GetComponent<Rigidbody2D>();
        rb.gravityScale = 0;
        rb.freezeRotation = true;

        currentLives = maxLives;
        UpdateLivesUI();
    }

    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");
        movement = movement.normalized;

        if (currentLives <= 0)
        {
            SceneManager.LoadScene("LoseScene");
        }
    }

    void FixedUpdate()
    {
        rb.linearVelocity = movement * moveSpeed; // Sửa lại để đúng cách điều khiển Rigidbody2D
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Trap"))
        {
            // Phát âm thanh khi chạm vào trap
            if (audioSource != null && trapSound != null)
            {
                audioSource.PlayOneShot(trapSound);
            }

            currentLives--;
            UpdateLivesUI();
            transform.position = lastSpawnPoint;
            rb.linearVelocity = Vector2.zero;
        }
        else if (other.CompareTag("WinPlace"))
        {
            SceneManager.LoadScene("YouWin");
        }
        else if (other.CompareTag("SpawnPlace"))
        {
            // Cap nhat SpawnPlace moi nhat da cham vao
            lastSpawnPoint = other.transform.position;
        }
    }

    void UpdateLivesUI()
    {
        if (livesText != null)
        {
            livesText.text = currentLives + "/" + maxLives;
        }
        else
        {
            Debug.LogWarning("Chua gan UI text cho livesText!");
        }
    }
}
