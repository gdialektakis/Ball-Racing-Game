using UnityEngine;
public class GameManager : MonoBehaviour {

  public static bool gameHasEnded = false;

	public void GameOver()
    {

        if(gameHasEnded == false)
        {
            gameHasEnded = true; // update that the game has ended
            Debug.Log("Game Over");
        }
    }
}
