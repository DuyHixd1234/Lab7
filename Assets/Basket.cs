using UnityEngine;

public class Basket : MonoBehaviour
{
    public Animator eggCounterAnimator; // Kéo Animator của số trứng vào đây
    private int eggCount = 0;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Egg")) // Đảm bảo trứng có tag "Egg"
        {
            eggCount++;
            eggCounterAnimator.SetInteger("EggCount", eggCount); // Gửi số trứng vào Animator

            Destroy(other.gameObject); // Xóa trứng sau khi chạm
        }
    }
}
