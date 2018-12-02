using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverMenu : MonoBehaviour {
    public GameObject gameOverMenuUI;
   
	void Update () {
        if (GameManager.gameHasEnded)
        {

            StartCoroutine(gameOver());

        }
	}

    IEnumerator gameOver()
    {
        yield return new WaitForSeconds(1f);
        gameOverMenuUI.SetActive(true);
        Time.timeScale = 0f;
    }

    public void LoadMenu()
    {
        GameManager.gameHasEnded = false;
        Time.timeScale = 1f;
        SceneManager.LoadScene("StartMenu");
    }

    public void QuitGame()
    {
        Debug.Log("Quiting game...");
        Application.Quit();
    }

    public void RestartGame()
    {
        Time.timeScale = 1f;
        GameManager.gameHasEnded = false;
        gameOverMenuUI.SetActive(false);
        SceneManager.LoadScene("Game");  //load active scene
    }
}
