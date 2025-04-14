using UnityEngine;
using UnityEngine.SceneManagement;

public class SelectLevelButton : MonoBehaviour
{
    public void LoadLevelSelection()
    {
        SceneManager.LoadScene("levels");
    }
}
