using UnityEngine;
using UnityEngine.UI;  // Thêm thư viện UI

public class OrangeManager : MonoBehaviour
{
    public static OrangeManager instance;
    public int totalOranges = 7;  // Tổng số cam trong map
    public int orangesCollected = 0; // Số cam đã ăn
    public Text orangeText; // Thêm Text UI để hiển thị số cam còn lại

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        UpdateOrangeText(); // Cập nhật UI ngay khi bắt đầu
    }

    public void CollectOrange()
    {
        orangesCollected++;
        Debug.Log("Cam đã ăn: " + orangesCollected + "/" + totalOranges);
        UpdateOrangeText(); // Cập nhật UI khi ăn cam
    }

    public bool AllOrangesCollected()
    {
        return orangesCollected >= totalOranges;
    }

    void UpdateOrangeText()
    {
        if (orangeText != null)
        {
            orangeText.text = "Bạn cần tìm thêm: " + (totalOranges - orangesCollected)+ " ngọc để mở khoá cửa ra.";
        }
        else
        {
            Debug.LogWarning("Chưa gán UI Text vào OrangeManager!");
        }
    }
}
