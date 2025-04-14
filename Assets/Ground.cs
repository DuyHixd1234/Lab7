using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;

public class Ground : MonoBehaviour
{
    [Header("Gameplay")]
    public int maxLives = 6; // Max lives (editable in Inspector)
    private int currentLives; // Current lives

    [Header("UI")]
    public TMP_Text livesText; // TMP Text to display lives (assign in Inspector)
    public Slider healthSlider; // Slider to represent heart (assign in Inspector)

    [Header("Audio")]
    public AudioClip hitSound; // Sound to play on egg collision
    private AudioSource audioSource; // Audio source component

    void Start()
    {
        currentLives = maxLives;

        UpdateLivesText();
        UpdateHealthSlider();

        audioSource = GetComponent<AudioSource>();
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Egg"))
        {
            currentLives--;

            UpdateLivesText();
            UpdateHealthSlider();

            if (audioSource != null && hitSound != null)
            {
                audioSource.PlayOneShot(hitSound);
            }

            if (currentLives <= 0)
            {
                SceneManager.LoadScene("Lab6Lose");
            }
        }
    }

    void UpdateLivesText()
    {
        if (livesText != null)
        {
            livesText.text = currentLives + "/" + maxLives;
        }
    }

    void UpdateHealthSlider()
    {
        if (healthSlider != null)
        {
            healthSlider.value = (float)currentLives / maxLives;
        }
    }
}
