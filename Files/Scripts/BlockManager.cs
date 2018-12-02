using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockManager : MonoBehaviour {

    public GameObject[] blockPrefabs;  // array of all the different block preafabs created
    private List<GameObject> activeBlocks;
    private Transform playerTransform;

    private float spawnZ = 15.0f;
    private float blockLength = 15.0f;
    private int blocksOnScreen = 5;
    private float safeZone = 30.0f;
    private int lastPrefabIndex = 0;



	// Use this for initialization
	void Start () {

        activeBlocks = new List<GameObject>();
        // locate the player's position
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;

        for(int i = 0; i < blocksOnScreen; i++)
        {
            Spawnblock();    // At first, spawn a default number of blocks
        }

    }

	// Update is called once per frame
	void Update () {

            // condition when to spawn a new block and delete the oldest created
            if (playerTransform.position.z - safeZone > (spawnZ - blocksOnScreen * blockLength))
            {
                Spawnblock();
                Deleteblock();
            }

	}

    //function that spawns a block
    void Spawnblock(int prefabIndex = -1)
    {
       // select a random block from the prefabs
        GameObject newBlock = Instantiate(blockPrefabs[RandomPrefabIndex()]) as GameObject;
        // set the new block's transform the same as the starting (parent) block on the track
        newBlock.transform.SetParent(transform);
        // move it on the z-axis so that it sits after the last block on the track
        newBlock.transform.position = Vector3.forward * spawnZ;
        spawnZ += blockLength;
        activeBlocks.Add(newBlock);  // add the new block to the list of active blocks
    }

    //function that deletes a block so that it frees memory space while the game progresses
    void Deleteblock()
    {
        Destroy(activeBlocks[0]);
        activeBlocks.RemoveAt(0);   // remove the first block of the list of active blocks

    }

    // function
    int RandomPrefabIndex()
    {
        if (blockPrefabs.Length <= 1)  // we need more blocks
            return 0;

        int randomIndex = lastPrefabIndex;
        while (randomIndex == lastPrefabIndex)  // we don't want 2 consecutive blocks to be the same
        {
            randomIndex = Random.Range(0, blockPrefabs.Length);  // pick a random block from those available
        }

        lastPrefabIndex = randomIndex;
        return randomIndex;
    }
}
