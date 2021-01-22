using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnSlashableBlocks : MonoBehaviour
{
    // Blocks the player can destroy (red or blue)
    public GameObject[] slashableBlocks;
    // The positions for spawning and object
    public Transform[] spawnBounds;
    // Song beat (135 is the beats per minute of a song)
    public float songBeat = (60 / 135) * 2;
    public float timer;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (timer > songBeat)
        {
            // Create random block (red/blue) with random position
            GameObject slashableBlock = Instantiate(slashableBlocks[Random.Range(0, 2)], spawnBounds[Random.Range(0, 4)]);
            slashableBlock.transform.localPosition = Vector3.zero;
            // It can be either up, down, left or right
            slashableBlock.transform.Rotate(transform.forward, 90 * Random.Range(0, 4));

            timer -= songBeat;
        }

        // Add delta every frame
        timer += Time.deltaTime;
    }
}
