using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    
    public void StartGame()
    {
        
        SceneManager.LoadScene("Game scene");
    }

    
    public void ExitGame()
    {
        Application.Quit();
        Debug.Log("Game is exiting"); 
    }
}