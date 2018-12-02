using UnityEngine;

public class PlayerMovement : MonoBehaviour {

    public Rigidbody rb;

    public static float forwardVelocity = 8.0f;  // Determines the forward velocity
    public float speed = 5f;

  

    void FixedUpdate()
    {

        rb.velocity = new Vector3(rb.velocity.x, rb.velocity.y, forwardVelocity);

        if (Input.GetKey("d"))  // If the player is pressing the "d" key
        {
            // "Time.deltaTime" because we want per second and not per frame
            Vector3 movement = new Vector3(speed * Time.deltaTime, 0, 0);
            rb.MovePosition(transform.position + movement);  // move player to the right
        }

        if (Input.GetKey("a"))  // If the player is pressing the "a" key
        {
            Vector3 movement = new Vector3(-speed * Time.deltaTime, 0, 0);
            rb.MovePosition(transform.position + movement); // move player to the left
        }

        //ignoring the collisions between the player and the opponents with layers 9 and 10 respectively
        Physics.IgnoreLayerCollision(9, 10);
    }


}
