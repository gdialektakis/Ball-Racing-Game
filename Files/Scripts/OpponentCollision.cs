using System.Collections;
using UnityEngine;

public class OpponentCollision : MonoBehaviour {

    public AImovement Opponentmovement;
    public Rigidbody  OpponentRb;


    private void OnCollisionEnter(Collision collisionInfo)
    {
        if (collisionInfo.collider.tag == "Obstacle")
        {
            AImovement.forwardSpeed = 8.0f;
            OpponentRb.constraints = RigidbodyConstraints.FreezeAll; //freeze the player when he hits an obstacle

            //gameObject.SetActive(false);     //destroy opponent object when it hits an obstacle
        }

    }

    private void OnTriggerEnter(Collider colliderInfo)
    {
        if (colliderInfo.CompareTag("Booster"))
        {
            StartCoroutine(Boost(colliderInfo));
        }
    }

    IEnumerator Boost(Collider bst)
    {
        AImovement.forwardSpeed *= 1.1f;         //bonus on the opponent's speed
        yield return new WaitForSeconds(1f);     //duration 1 sec
        AImovement.forwardSpeed /= 1.1f;         //going back to normal speed

    }
}
