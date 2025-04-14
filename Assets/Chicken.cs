using UnityEngine;

public class Chicken : MonoBehaviour
{
    public GameObject eggPrefab;  // Prefab trứng
    public Transform spawnPoint;  // Vị trí gà đẻ trứng
    public float spawnRate = 3f;  // Thời gian mỗi lần đẻ

    void Start()
    {
        InvokeRepeating("LayEgg", 0f, spawnRate); // Gọi hàm LayEgg mỗi 3 giây
    }

    void LayEgg()
    {
        Instantiate(eggPrefab, spawnPoint.position, Quaternion.identity);
    }
}
