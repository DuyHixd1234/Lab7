using UnityEngine;

public class FallPlace : MonoBehaviour
{
    [Header("Prefab trung va thoi gian spawn")]
    public GameObject eggPrefab; // Prefab trung
    public float spawnInterval = 2f; // Thoi gian giua cac lan spawn

    private float timer;

    void Update()
    {
        timer += Time.deltaTime;

        if (timer >= spawnInterval)
        {
            SpawnEggs();
            timer = 0f;
        }
    }

    void SpawnEggs()
    {
        // Random so trung (1 hoac 2)
        int eggCount = Random.Range(1, 1);

        for (int i = 0; i < eggCount; i++)
        {
            Instantiate(eggPrefab, transform.position, Quaternion.identity);
        }
    }
}
