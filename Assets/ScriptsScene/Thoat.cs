using UnityEngine;

public class Thoat : MonoBehaviour
{
    public void ThoatGame()
    {
        Application.Quit(); // Thoát game
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false; // Dừng trong Editor
#endif
    }
}
