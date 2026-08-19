using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{

        


    public void PlayGame()
    {
        // Load the next scene in the build index
        SceneManager.LoadScene("Game");
        Time.timeScale = 1f; // Ensure the game runs at normal speed
    }

    public void LoadCollectibles()
    {
        // Load the collectibles scene
        SceneManager.LoadScene("CollectiblesMenu");
    }

    public void ExitGame()
    {
        // Quit the application
        Application.Quit();
    }
}
