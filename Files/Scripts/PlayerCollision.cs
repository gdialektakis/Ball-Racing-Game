using System.Collections;
using UnityEngine;

public class PlayerCollision : MonoBehaviour {

    public PlayerMovement movement;
    public Rigidbody rb;

    public GameObject boostEffect;
    public GameObject dieEffect;
    public static int boostScore = 0;


    private void OnCollisionEnter(Collision collisionInfo)
    {
        if (collisionInfo.collider.tag == "Obstacle")
        {
            PlayerMovement.forwardVelocity = 8.0f;
            rb.constraints = RigidbodyConstraints.FreezeAll;    //freeze the player when he hits an obstacle
            Instantiate(dieEffect, transform.position, transform.rotation);  //create an effect

            FindObjectOfType<AudioManager>().Play("PlayerDeath");  //play a sound when the player dies
            //set forward speed to its default value when the game restarts
            
            gameObject.SetActive(false);     //destroy player object when it hits an obstacle
            FindObjectOfType<GameManager>().GameOver();    //game over when player hits an obstacle
        }

    }

    private void OnTriggerEnter(Collider colliderInfo)
    {
        if (colliderInfo.CompareTag("Booster"))
        {
            FindObjectOfType<AudioManager>().Play("SpeedBoost"); //play a sound when collecting a speed boost
            boostScore += 100;  //add 100 points to the score
            StartCoroutine (Boost(colliderInfo));  //call the IEnumerator Boost() function
        }
    }

    IEnumerator Boost(Collider bst)    //IEnumerator because it yields
    {
        Instantiate(boostEffect, transform.position, transform.rotation);  //create an effect
        PlayerMovement.forwardVelocity *= 1.5f;         //bonus on the speed player is moving
        yield return new WaitForSeconds(1f);            //duration 1 sec
        PlayerMovement.forwardVelocity /= 1.5f;         //going back to normal speed

    }
}
