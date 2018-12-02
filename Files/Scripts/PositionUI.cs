using UnityEngine.UI;
using UnityEngine;

public class PositionUI : MonoBehaviour {

    public Text positionText;

    // Update is called once per frame
    void Update () {
        // display the position of the player on screen
        positionText.text = "Position:  " + Positions.pos.ToString();
    }
}
