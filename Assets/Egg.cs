using UnityEngine;

public class Egg : MonoBehaviour
{
    private Rigidbody2D rb; // Rigidbody2D cua trung
    private Collider2D eggCollider; // Collider2D cua trung
    private AudioSource audioSource; // AudioSource để phát âm thanh

    public GameObject brokenEggPrefab; // Prefab trung be, gan trong Inspector
    public Vector3 brokenEggScale = new Vector3(0.5f, 0.5f, 1f); // Tỷ lệ của trứng bể, bạn có thể điều chỉnh giá trị này theo ý muốn
    public AudioClip brokenEggSound; // Âm thanh khi trứng vỡ

    void Start()
    {
        // Lay Rigidbody2D cua Egg
        rb = GetComponent<Rigidbody2D>();
        eggCollider = GetComponent<Collider2D>(); // Lay Collider2D cua Egg

        // Lấy AudioSource từ đối tượng này
        audioSource = GetComponent<AudioSource>();
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (!eggCollider.isTrigger && collision.gameObject.CompareTag("Ground"))
        {
            // Khi cham mat dat va isTrigger = false, dung lai va khong roi nua
            rb.linearVelocity = Vector2.zero; // Dung hoan toan chuyen dong
            rb.gravityScale = 0; // Tat trong luc

            // Thay the trung ban dau bang trung be
            GameObject brokenEgg = Instantiate(brokenEggPrefab, transform.position, transform.rotation);

            // Thay doi kich thuoc cua trung be
            brokenEgg.transform.localScale = brokenEggScale;

            // Phat am thanh trung be
            if (audioSource != null && brokenEggSound != null)
            {
                audioSource.PlayOneShot(brokenEggSound);
            }

            // Xoa trung goc
            Destroy(gameObject);
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (eggCollider.isTrigger && collision.CompareTag("Ground"))
        {
            // Khi cham mat dat va isTrigger = true, dung lai va khong roi nua
            rb.linearVelocity = Vector2.zero; // Dung hoan toan chuyen dong
            rb.gravityScale = 0; // Tat trong luc

            // Thay the trung ban dau bang trung be
            GameObject brokenEgg = Instantiate(brokenEggPrefab, transform.position, transform.rotation);

            // Thay doi kich thuoc cua trung be
            brokenEgg.transform.localScale = brokenEggScale;

            // Phat am thanh trung be
            if (audioSource != null && brokenEggSound != null)
            {
                audioSource.PlayOneShot(brokenEggSound);
            }

            // Xoa trung goc
            Destroy(gameObject);
        }
    }
}
