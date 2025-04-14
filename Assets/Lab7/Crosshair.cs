using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;
using System.Collections.Generic;

public class Crosshair : MonoBehaviour
{
    public float moveSpeed = 5f;
    public AudioClip shootSound;
    public TMP_Text ammoText; // hien thi dan
    public Image[] targetImages; // 6 sprite UI tuong ung cac bong 1-6
    public int maxAmmo = 10;

    private int currentAmmo;
    private AudioSource audioSource;

    private bool[] ballCollected = new bool[6]; // danh dau cac bong da ban
    private Vector3 recoilOrigin;

    private List<Ball> ballsInRange = new List<Ball>(); // danh sach bong dang cham

    void Start()
    {
        currentAmmo = maxAmmo;
        audioSource = GetComponent<AudioSource>();
        UpdateAmmoText();
    }

    void Update()
    {
        Move();

        if ((Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0)) && currentAmmo > 0)
        {
            ShootEffect();
            TryShootBall();
        }
    }

    void Move()
    {
        float moveX = Input.GetAxisRaw("Horizontal");
        float moveY = Input.GetAxisRaw("Vertical");

        Vector2 move = new Vector2(moveX, moveY).normalized;
        transform.Translate(move * moveSpeed * Time.deltaTime);
    }

    void ShootEffect()
    {
        if (audioSource != null && shootSound != null)
        {
            audioSource.PlayOneShot(shootSound);
        }

        recoilOrigin = transform.position;
        Vector3 upOffset = new Vector3(0, 0.1f, 0); // giat 1cm
        transform.position += upOffset;
        Invoke("ResetPosition", 0.05f);

        currentAmmo--;
        UpdateAmmoText();
    }

    void ResetPosition()
    {
        transform.position = recoilOrigin;
    }

    void UpdateAmmoText()
    {
        if (ammoText != null)
        {
            ammoText.text = currentAmmo + "/" + maxAmmo;
        }
    }

    void TryShootBall()
    {
        if (ballsInRange.Count > 0)
        {
            Ball ball = ballsInRange[0];
            CollectBall(ball.ballID);
            Destroy(ball.gameObject);
            ballsInRange.Remove(ball);
        }

        // Neu da het dan ma chua ban du 6 loai bong thi thua
        if (currentAmmo <= 0 && !HasWon())
        {
            SceneManager.LoadScene("Lose7");
        }
    }

    public void CollectBall(int id)
    {
        if (id >= 1 && id <= 6 && !ballCollected[id - 1])
        {
            ballCollected[id - 1] = true;

            // An UI sprite da ban
            if (targetImages != null && id - 1 < targetImages.Length && targetImages[id - 1] != null)
            {
                targetImages[id - 1].enabled = false;
            }

            if (HasWon())
            {
                SceneManager.LoadScene("Win7");
            }
        }
    }

    bool HasWon()
    {
        for (int i = 0; i < ballCollected.Length; i++)
        {
            if (!ballCollected[i]) return false;
        }
        return true;
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        Ball ball = collision.GetComponent<Ball>();
        if (ball != null && !ballsInRange.Contains(ball))
        {
            ballsInRange.Add(ball);
        }
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        Ball ball = collision.GetComponent<Ball>();
        if (ball != null && ballsInRange.Contains(ball))
        {
            ballsInRange.Remove(ball);
        }
    }
}
