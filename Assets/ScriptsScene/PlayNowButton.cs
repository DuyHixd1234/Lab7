using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayNowButton : MonoBehaviour
{
    public void LoadGame()
    {
        SceneManager.LoadScene("Lab3");
    }
}
