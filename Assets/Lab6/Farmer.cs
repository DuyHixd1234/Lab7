using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class Farmer : MonoBehaviour
{
    [Header("UI")]
    public Slider healthUpSlider; // slider len khi nhat trung
    public Slider healthDownSlider; // slider xuong khi mat trung
    public TMP_Text eggCounterText; // text hien thi trung nhat
    public TMP_Text loseCounterText; // text hien thi so mang con lai

    [Header("Thong so gameplay")]
    public int totalEggsToCollect = 25;
    public int maxLives = 10;
    public AudioClip pickupSound;

    private int currentEggs = 0;
    private int currentLives;
    private AudioSource audioSource;

    public float moveSpeed = 5f;

    private Rigidbody2D rb;
    private bool facingRight = true;

    private Animator animator; // Animator component

    void Start()
    {
        currentLives = maxLives;

        UpdateEggCounterText();
        UpdateLivesText();

        if (healthUpSlider != null)
        {
            healthUpSlider.maxValue = totalEggsToCollect;
            healthUpSlider.value = 0;
        }

        if (healthDownSlider != null)
        {
            healthDownSlider.maxValue = maxLives;
            healthDownSlider.value = maxLives;
        }

        audioSource = GetComponent<AudioSource>();
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>(); // Lay Animator
    }

    void Update()
    {
        float horizontalInput = Input.GetAxisRaw("Horizontal");
        Vector2 moveDirection = new Vector2(horizontalInput, 0f);

        rb.linearVelocity = new Vector2(moveDirection.x * moveSpeed, rb.linearVelocity.y);

        // Cap nhat animation
        if (animator != null)
            animator.SetBool("isMoved", horizontalInput != 0);

        if (horizontalInput > 0 && !facingRight)
        {
            Flip();
        }
        else if (horizontalInput < 0 && facingRight)
        {
            Flip();
        }
    }

    void Flip()
    {
        facingRight = !facingRight;
        Vector3 localScale = transform.localScale;
        localScale.x *= -1;
        transform.localScale = localScale;
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Egg"))
        {
            Destroy(collision.gameObject);

            currentEggs++;
            UpdateEggCounterText();

            if (healthUpSlider != null)
                healthUpSlider.value = currentEggs;

            if (pickupSound != null && audioSource != null)
                audioSource.PlayOneShot(pickupSound);

            if (currentEggs >= totalEggsToCollect)
            {
                SceneManager.LoadScene("YouWin");
            }
        }
    }

    public void LoseLife()
    {
        currentLives--;
        UpdateLivesText();

        if (healthDownSlider != null)
            healthDownSlider.value = currentLives;

        if (currentLives <= 0)
        {
            SceneManager.LoadScene("Lab6Lose");
        }
    }

    void UpdateEggCounterText()
    {
        if (eggCounterText != null)
            eggCounterText.text = currentEggs + "/" + totalEggsToCollect;
    }

    void UpdateLivesText()
    {
        if (loseCounterText != null)
            loseCounterText.text = currentLives + "/" + maxLives;
    }
}
