using UnityEngine;

public class DisplayMouseCursor : MonoBehaviour
{
    void Start()
    {
        // Script Used only for the Menu Screens - GameStart, GameWin, GameOver 
        // Display cursors on them screens
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }
}