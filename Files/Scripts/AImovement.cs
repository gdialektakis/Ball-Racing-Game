using UnityEngine;

public class AImovement : MonoBehaviour {

    public static float forwardSpeed = 8.0f;  // Determines the forward velocity
    public float speed = 50f;

    public Rigidbody opponentRb;
    public GameObject opponent;

    void FixedUpdate() {

        opponent = GameObject.FindGameObjectWithTag("Opponent");

        RaycastHit hit;
        // Bit shift the index of the layer (8) to get a bit mask
        int layerWall = 1 << 11;
        int layerOpp = 1 << 10;

        // This would cast rays only against the wall and other opponents colliders in layer 11 and 10.
        // But instead we want to collide against everything except those layers. The ~ operator does this, it inverts a bitmask.
        layerWall = ~layerWall;
        layerOpp = ~layerOpp;

        opponentRb.velocity = new Vector3(opponentRb.velocity.x, opponentRb.velocity.y, forwardSpeed);

        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, 4, layerOpp)
            && opponent.transform.position.x <= 0.75f && opponent.transform.position.x >= -0.75f)
        {   //there is an obstacle in front of you
            // draw two rays
            Debug.DrawRay(transform.position, transform.TransformDirection(1, 0, 1) * hit.distance, Color.yellow);
            Debug.DrawRay(transform.position, transform.TransformDirection(-1, 0, 1) * hit.distance, Color.yellow);

            if (Physics.Raycast(transform.position, transform.TransformDirection(1,0,1), out hit, 5, layerWall)
                && Physics.Raycast(transform.position, transform.TransformDirection(1, 0, 1), out hit, 5, layerOpp) )
            {
              //there is an obstacle on the right diagonal

                Vector3 movement = new Vector3(-speed * Time.deltaTime, 0, 0);
                opponentRb.MovePosition(transform.position + movement);      //move to the left
            }
            else if(Physics.Raycast(transform.position, transform.TransformDirection(-1, 0, 1), out hit, 5, layerWall)
                    && Physics.Raycast(transform.position, transform.TransformDirection(-1, 0, 1), out hit, 5, layerOpp) )
            {
              //there is an obstacle on the left diagonal
              Vector3 movement = new Vector3(speed * Time.deltaTime, 0, 0);
              opponentRb.MovePosition(transform.position + movement);      //move to the right
            }

        }else if(Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, 4, layerOpp)
                  && opponent.transform.position.x > 0.75f)  //opponent is placed on the right side of the track
        {
          Vector3 movement = new Vector3(-speed * Time.deltaTime, 0, 0);
          opponentRb.MovePosition(transform.position + movement);      //move to the left

        }else if(Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, 4, layerOpp)
                  && opponent.transform.position.x < -0.75f) //opponent is placed on the left side of the track
        {
          Vector3 movement = new Vector3(speed * Time.deltaTime, 0, 0);
          opponentRb.MovePosition(transform.position + movement);      //move to the right
        }

        //ignoring the collisions between the player and the opponents with layers 9 and 10
        Physics.IgnoreLayerCollision(9, 10);
        //ignoring the collisions between the opponents with layer 10
        Physics.IgnoreLayerCollision(10, 10);
    }
}
