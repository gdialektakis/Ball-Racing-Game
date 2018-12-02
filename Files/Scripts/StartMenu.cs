using UnityEngine;
using UnityEngine.SceneManagement;

public class StartMenu : MonoBehaviour {

	public void PlayGame()
    {
        SceneManager.LoadScene("Game"); // Load the game scene
    }

    public void QuitGame()
    {
        Debug.Log("Quit!");
        Application.Quit();     // Exit the game
    }

}
