using UnityEngine.UI;
using UnityEngine;

public class Score : MonoBehaviour {

    public Transform player;
    public Text scoreText;


    private void Start()
    {
        // initialize it to 12 so that the total score starts counting from 0 because player starts at z = -6
        PlayerCollision.boostScore = 12;
    }

    void Update () {
        // Total score = (player's position on the z axis times 2) plus (the score collected from speed boosts)
        scoreText.text = "Score: " + (2*player.position.z + PlayerCollision.boostScore).ToString("0");
    }
}
