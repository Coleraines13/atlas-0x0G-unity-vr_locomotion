using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    // Method to be called when the Start button is pressed
    public void StartGame()
    {
        // Load the game scene
        SceneManager.LoadScene("GameScene");
    }

    // Method to be called when the Exit button is pressed (optional)
    public void ExitGame()
    {
        Application.Quit();
        Debug.Log("Game is exiting"); // This is for debugging purposes; it won't be seen in the build
    }
}