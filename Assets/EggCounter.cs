using UnityEngine;

public class EggCounter : MonoBehaviour
{
    private Animator animator;
    private int currentFrame = 0;

    void Start()
    {
        animator = GetComponent<Animator>();
        animator.speed = 0; // Dừng animation để tự điều khiển frame
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Egg")) // Kiểm tra nếu va chạm với trứng
        {
            currentFrame++; // Tăng frame lên 1
            if (currentFrame > 9) currentFrame = 0; // Nếu quá 9 thì quay về 0

            animator.Play("Pts", 0, currentFrame / 10f); // Chạy frame tương ứng
            Destroy(other.gameObject); // Xóa trứng
        }
    }
}
