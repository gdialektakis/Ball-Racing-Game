using System;
using UnityEngine;

public class Positions : MonoBehaviour {

    private GameObject player;
    private GameObject opp1, opp2, opp3, opp4, opp5, opp6, opp7, opp8, opp9;
    private float playerPos;
    private float opp1Pos, opp2Pos, opp3Pos, opp4Pos, opp5Pos, opp6Pos, opp7Pos, opp8Pos, opp9Pos;
    public static int pos;



    private void Update()
    {
            CalculatePositions();

    }

    // function that calculat the position of the player and the opponets
    void CalculatePositions()
    {
            // find player gameobject
            player = GameObject.FindGameObjectWithTag("Player");
            // find opponents' gameobjects
            opp1 = GameObject.Find("Opponent1");
            opp2 = GameObject.Find("Opponent2");
            opp3 = GameObject.Find("Opponent3");
            opp4 = GameObject.Find("Opponent4");
            opp5 = GameObject.Find("Opponent5");
            opp6 = GameObject.Find("Opponent6");
            opp7 = GameObject.Find("Opponent7");
            opp8 = GameObject.Find("Opponent8");
            opp9 = GameObject.Find("Opponent9");


            playerPos = player.transform.position.z;   // position of the player on the z-axis
            // positions of the opponents' on the z-axis
            opp1Pos = opp1.transform.position.z;
            opp2Pos = opp2.transform.position.z;
            opp3Pos = opp3.transform.position.z;
            opp4Pos = opp4.transform.position.z;
            opp5Pos = opp5.transform.position.z;
            opp6Pos = opp6.transform.position.z;
            opp7Pos = opp7.transform.position.z;
            opp8Pos = opp8.transform.position.z;
            opp9Pos = opp9.transform.position.z;

            float[] opp = new float[9]    // opponents' array
            { opp1Pos, opp2Pos, opp3Pos, opp4Pos, opp5Pos, opp6Pos, opp7Pos, opp8Pos, opp9Pos };

            float[] positions = new float[10]   // array that stores the positions of the players on the z axis
            {opp[0], opp[1], opp[2], opp[3], opp[4], opp[5], opp[6], opp[7], opp[8], playerPos};

            Array.Sort(positions);    // sort the array
            Array.Reverse(positions);  // because we want descending order

            for (int i = 0; i < positions.Length; i = i + 1)   //search for the main player's position
            {
                if (positions[i] == playerPos)   //player found
                {
                    pos = i + 1;             // the position of the player (+1 because array index starts at 0)

                }
            }
        }


}
