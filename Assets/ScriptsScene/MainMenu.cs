using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void ToMainMenu()
    {
        SceneManager.LoadScene("UI"); // Chuyển sang scene UI
    }
}
