using UnityEngine;
using System.Collections;

public class TrapSpawner : MonoBehaviour
{
    public GameObject trapPrefab; // Prefab của bẫy
    public float moveSpeed = 10f; // Tốc độ di chuyển của bẫy
    public float trapLifetime = 3f; // Thời gian tồn tại của bẫy
    public float spawnInterval = 1f; // Mỗi giây bắn 1 lần

    private Vector2[] directions = new Vector2[] { Vector2.left, Vector2.right, Vector2.up, Vector2.down };

    void Start()
    {
        StartCoroutine(SpawnTrapsLoop());
    }

    IEnumerator SpawnTrapsLoop()
    {
        while (true)
        {
            Vector2 randomDirection = directions[Random.Range(0, directions.Length)]; // Chọn hướng ngẫu nhiên
            SpawnTrap(randomDirection);
            yield return new WaitForSeconds(spawnInterval); // Mỗi giây bắn 1 lần
        }
    }

    void SpawnTrap(Vector2 direction)
    {
        GameObject newTrap = Instantiate(trapPrefab, transform.position, Quaternion.identity);
        Rigidbody2D rb = newTrap.GetComponent<Rigidbody2D>();

        if (rb != null)
        {
            rb.linearVelocity = direction * moveSpeed;
        }

        Destroy(newTrap, trapLifetime); // Trap tự hủy sau 3 giây
    }
}
