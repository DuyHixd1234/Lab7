using UnityEngine;

public class BallSpawner : MonoBehaviour
{
    [Header("Cai dat spawn")]
    public GameObject ballPrefab; // Prefab cua bong
    public Sprite[] ballSprites; // Danh sach 6 sprite danh so 1-6
    public float spawnInterval = 2f;

    private float timer;

    void Update()
    {
        timer += Time.deltaTime;

        if (timer >= spawnInterval)
        {
            SpawnBall();
            timer = 0f;
        }
    }

    void SpawnBall()
    {
        if (ballPrefab == null)
        {
            Debug.LogError("Ball Prefab chua duoc gan trong Inspector!");
            return;
        }

        if (ballSprites == null || ballSprites.Length == 0)
        {
            Debug.LogError("Chua gan sprite cho ballSprites[]!");
            return;
        }

        Vector2 randomPos = new Vector2(Random.Range(-7f, 7f), Random.Range(-3f, 4f));
        GameObject ball = Instantiate(ballPrefab, randomPos, Quaternion.identity);

        SpriteRenderer sr = ball.GetComponent<SpriteRenderer>();
        if (sr == null)
        {
            Debug.LogError("Prefab khong co SpriteRenderer!");
            return;
        }

        int index = Random.Range(0, ballSprites.Length);
        sr.sprite = ballSprites[index];
        ball.name = "Ball_" + (index + 1);

        Ball ballScript = ball.GetComponent<Ball>();
        if (ballScript != null)
        {
            ballScript.ballID = index + 1;
        }
        else
        {
            Debug.LogWarning("Prefab khong co script Ball.cs");
        }
    }
}
