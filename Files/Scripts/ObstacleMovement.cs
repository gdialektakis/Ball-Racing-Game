using UnityEngine;

public class ObstacleMovement : MonoBehaviour {

    public float range = 2.0f;  // Amount to move left and right from the start point
    public float speed = 4.0f;
    private Vector3 startPos;


    void Start () {
        startPos = transform.position;
    }

	void Update () {
        Vector3 v = startPos;
        // perform oscillation between the 2 side walls of the track
        v.x += range * Mathf.Sin(Time.time * speed);
        transform.position = v;
    }


}
