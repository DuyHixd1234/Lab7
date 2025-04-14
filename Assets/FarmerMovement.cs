using UnityEngine;

public class FarmerMovement : MonoBehaviour
{
    public float speed = 5f;
    private Rigidbody2D rb;
    private float moveInput;
    private SpriteRenderer spriteRenderer; // Thêm biến để Flip hình

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponentInChildren<SpriteRenderer>(); // Lấy SpriteRenderer từ con của FarmerContainer
    }

    void Update()
    {
        moveInput = Input.GetAxis("Horizontal"); // Nhận input từ A/D hoặc ← →

        // Nếu di chuyển sang trái, lật X
        if (moveInput < 0)
            spriteRenderer.flipX = true;
        else if (moveInput > 0)
            spriteRenderer.flipX = false;
    }

    void FixedUpdate()
    {
        rb.linearVelocity = new Vector2(moveInput * speed, rb.linearVelocity.y); // Di chuyển bằng Rigidbody2D
    }
}
