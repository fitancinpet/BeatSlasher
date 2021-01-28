using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnableBlock
{
    public bool spawn;
    public int pos;
    public int rot;

    public SpawnableBlock(bool sp, int p, int r)
    {
        spawn = sp;
        pos = p;
        rot = r;
    }
}

public class SpawnLinkinParkBlocks : MonoBehaviour
{
    // Constants
    public const int BLUE_BLOCK = 0;
    public const int RED_BLOCK = 1;

    public const int FAR_LEFT_TOP = 0;
    public const int FAR_LEFT_BOTTOM = 1;
    public const int CLOSE_LEFT_BOTTOM = 2;
    public const int CLOSE_RIGHT_BOTTOM = 3;
    public const int FAR_RIGHT_BOTTOM = 4;
    public const int FAR_RIGHT_TOP = 5;

    public const int ROT_UP = 0;
    public const int ROT_RIGHT = 1;
    public const int ROT_DOWN = 2;
    public const int ROT_LEFT = 3;

    AudioSource audioData;
    // Blocks the player can destroy (red or blue)
    public GameObject[] slashableBlocks;
    // The positions for spawning and object
    public Transform[] spawnBounds;
    public int timer = 0;
    public int indexable = 0;
    public int started = 0;

    // Level data hardcoded
    public SpawnableBlock[] redSpawn;

    public SpawnableBlock[] blueSpawn;

    // Update is called during fixed periods
    void FixedUpdate()
    {
        if (started > 0)
        {
            if (timer % 42 == 0)
            {
                if (indexable >= 0 && indexable < redSpawn.Length && redSpawn[indexable].spawn)
                {
                    // Create random block (red/blue) with random position
                    GameObject slashableBlock = Instantiate(slashableBlocks[RED_BLOCK], spawnBounds[redSpawn[indexable].pos]);
                    slashableBlock.transform.localPosition = Vector3.zero;
                    // It can be either up, down, left or right
                    slashableBlock.transform.Rotate(transform.forward, 90 * redSpawn[indexable].rot);
                }

                if (indexable >= 0 && indexable < blueSpawn.Length && blueSpawn[indexable].spawn)
                {
                    // Create random block (red/blue) with random position
                    GameObject slashableBlock = Instantiate(slashableBlocks[BLUE_BLOCK], spawnBounds[blueSpawn[indexable].pos]);
                    slashableBlock.transform.localPosition = Vector3.zero;
                    // It can be either up, down, left or right
                    slashableBlock.transform.Rotate(transform.forward, 90 * blueSpawn[indexable].rot);
                }

                // Indexable running at lower speed
                ++indexable;
            }

            if (indexable == 3)
            {
                audioData = GameObject.Find("MusicBox").GetComponent<AudioSource>();
                audioData.Play(0);
            }
            // Increment timer
            ++timer;
        }
    }

    SpawnableBlock sp(int p, int r)
    {
        return new SpawnableBlock(true, p, r);
    }

    SpawnableBlock np()
    {
        return new SpawnableBlock(false, 0, 0);
    }

    void Start()
    {
        timer = 0;
        indexable = 0;
        blueSpawn = new SpawnableBlock[1000];
        redSpawn = new SpawnableBlock[1000];

        blueSpawn[0] = sp(FAR_LEFT_BOTTOM, ROT_RIGHT); redSpawn[0] = sp(FAR_RIGHT_BOTTOM, ROT_LEFT);
        blueSpawn[1] = np(); redSpawn[1] = np();
        blueSpawn[2] = np(); redSpawn[2] = sp(CLOSE_LEFT_BOTTOM, ROT_RIGHT);
        blueSpawn[3] = np(); redSpawn[3] = np();
        blueSpawn[4] = np(); redSpawn[4] = sp(FAR_RIGHT_BOTTOM, ROT_LEFT);
        blueSpawn[5] = np(); redSpawn[5] = np();
        blueSpawn[6] = np(); redSpawn[6] = np();
        blueSpawn[7] = sp(CLOSE_LEFT_BOTTOM, ROT_UP); redSpawn[7] = np();
        blueSpawn[8] = np(); redSpawn[8] = np();
        blueSpawn[9] = sp(CLOSE_LEFT_BOTTOM, ROT_DOWN); redSpawn[9] = np();
        blueSpawn[10] = np(); redSpawn[10] = np();
        blueSpawn[11] = np(); redSpawn[11] = sp(CLOSE_RIGHT_BOTTOM, ROT_UP);
        blueSpawn[12] = np(); redSpawn[12] = sp(CLOSE_RIGHT_BOTTOM, ROT_DOWN);
        blueSpawn[13] = sp(CLOSE_LEFT_BOTTOM, ROT_DOWN); redSpawn[13] = np();
        blueSpawn[14] = sp(FAR_LEFT_TOP, ROT_RIGHT); redSpawn[14] = np();
        blueSpawn[15] = np(); redSpawn[15] = np();
        blueSpawn[16] = np(); redSpawn[16] = np();
        blueSpawn[17] = np(); redSpawn[17] = np();
        blueSpawn[18] = sp(CLOSE_LEFT_BOTTOM, ROT_UP); redSpawn[18] = np();
        blueSpawn[19] = np(); redSpawn[19] = sp(FAR_RIGHT_TOP, ROT_LEFT);
        blueSpawn[20] = np(); redSpawn[20] = np();
        blueSpawn[21] = np(); redSpawn[21] = sp(CLOSE_RIGHT_BOTTOM, ROT_UP);
        blueSpawn[22] = sp(FAR_LEFT_TOP, ROT_RIGHT); redSpawn[22] = np();
        blueSpawn[23] = np(); redSpawn[23] = sp(CLOSE_RIGHT_BOTTOM, ROT_DOWN);
        blueSpawn[24] = np(); redSpawn[24] = sp(CLOSE_RIGHT_BOTTOM, ROT_UP);
        blueSpawn[25] = sp(CLOSE_LEFT_BOTTOM, ROT_UP); redSpawn[25] = np();
        blueSpawn[26] = np(); redSpawn[26] = np();
        blueSpawn[27] = np(); redSpawn[27] = np();
        blueSpawn[28] = sp(CLOSE_LEFT_BOTTOM, ROT_DOWN); redSpawn[28] = sp(CLOSE_RIGHT_BOTTOM, ROT_DOWN);
        blueSpawn[29] = sp(CLOSE_LEFT_BOTTOM, ROT_UP); redSpawn[29] = sp(CLOSE_RIGHT_BOTTOM, ROT_UP);
        blueSpawn[30] = sp(CLOSE_LEFT_BOTTOM, ROT_DOWN); redSpawn[30] = np();
        blueSpawn[31] = np(); redSpawn[31] = sp(FAR_RIGHT_TOP, ROT_LEFT);
        blueSpawn[32] = np(); redSpawn[32] = np();
        blueSpawn[33] = sp(CLOSE_RIGHT_BOTTOM, ROT_UP); redSpawn[33] = sp(FAR_RIGHT_BOTTOM, ROT_UP);
        blueSpawn[34] = np(); redSpawn[34] = sp(CLOSE_RIGHT_BOTTOM, ROT_DOWN);
        blueSpawn[35] = sp(FAR_LEFT_TOP, ROT_RIGHT); redSpawn[35] = np();
        blueSpawn[36] = np(); redSpawn[36] = np();
        blueSpawn[37] = sp(FAR_LEFT_BOTTOM, ROT_UP); redSpawn[37] = sp(CLOSE_LEFT_BOTTOM, ROT_UP);
        blueSpawn[38] = sp(CLOSE_LEFT_BOTTOM, ROT_DOWN); redSpawn[38] = np();
        blueSpawn[39] = np(); redSpawn[39] = sp(FAR_RIGHT_TOP, ROT_LEFT);
        blueSpawn[40] = np(); redSpawn[40] = np();
        blueSpawn[41] = sp(CLOSE_LEFT_BOTTOM, ROT_UP); redSpawn[41] = sp(CLOSE_RIGHT_BOTTOM, ROT_UP); //39
        blueSpawn[42] = np(); redSpawn[42] = sp(CLOSE_RIGHT_BOTTOM, ROT_DOWN);
        blueSpawn[43] = sp(FAR_LEFT_TOP, ROT_RIGHT); redSpawn[43] = np();
        blueSpawn[44] = np(); redSpawn[44] = np();
        blueSpawn[45] = sp(CLOSE_LEFT_BOTTOM, ROT_UP); redSpawn[45] = sp(CLOSE_RIGHT_BOTTOM, ROT_UP);
        blueSpawn[46] = sp(CLOSE_LEFT_BOTTOM, ROT_DOWN); redSpawn[46] = np();
        blueSpawn[47] = np(); redSpawn[47] = sp(FAR_RIGHT_TOP, ROT_LEFT);
        blueSpawn[48] = np(); redSpawn[48] = np();
        blueSpawn[49] = sp(CLOSE_RIGHT_BOTTOM, ROT_UP); redSpawn[49] = sp(FAR_RIGHT_BOTTOM, ROT_UP);
        blueSpawn[50] = np(); redSpawn[50] = sp(CLOSE_RIGHT_BOTTOM, ROT_DOWN);
        blueSpawn[51] = sp(FAR_LEFT_TOP, ROT_RIGHT); redSpawn[51] = np();
        blueSpawn[52] = np(); redSpawn[52] = np();
        blueSpawn[53] = sp(FAR_LEFT_BOTTOM, ROT_UP); redSpawn[53] = sp(CLOSE_LEFT_BOTTOM, ROT_UP);
        blueSpawn[54] = sp(CLOSE_LEFT_BOTTOM, ROT_DOWN); redSpawn[54] = np();
        blueSpawn[55] = np(); redSpawn[55] = sp(FAR_RIGHT_TOP, ROT_LEFT);
        blueSpawn[56] = sp(CLOSE_LEFT_BOTTOM, ROT_UP); redSpawn[56] = sp(CLOSE_RIGHT_BOTTOM, ROT_UP); // 45
        blueSpawn[57] = np(); redSpawn[57] = sp(CLOSE_RIGHT_BOTTOM, ROT_DOWN);
        blueSpawn[58] = sp(FAR_LEFT_TOP, ROT_RIGHT); redSpawn[58] = np();
        blueSpawn[59] = np(); redSpawn[59] = sp(CLOSE_RIGHT_BOTTOM, ROT_LEFT);
        blueSpawn[60] = sp(CLOSE_LEFT_BOTTOM, ROT_UP); redSpawn[60] = sp(CLOSE_RIGHT_BOTTOM, ROT_UP); // 46 "I am"
        blueSpawn[61] = sp(CLOSE_LEFT_BOTTOM, ROT_DOWN); redSpawn[61] = np();
        blueSpawn[62] = np(); redSpawn[62] = sp(CLOSE_RIGHT_BOTTOM, ROT_LEFT);
        blueSpawn[63] = np(); redSpawn[63] = np();
        blueSpawn[64] = sp(FAR_LEFT_TOP, ROT_RIGHT); redSpawn[64] = np();
        blueSpawn[65] = sp(CLOSE_LEFT_BOTTOM, ROT_UP); redSpawn[65] = np();
        blueSpawn[66] = np(); redSpawn[66] = sp(FAR_RIGHT_BOTTOM, ROT_UP);
        blueSpawn[67] = np(); redSpawn[67] = np();
        blueSpawn[68] = np(); redSpawn[68] = sp(CLOSE_RIGHT_BOTTOM, ROT_DOWN);
        blueSpawn[69] = np(); redSpawn[69] = sp(CLOSE_RIGHT_BOTTOM, ROT_UP);
        blueSpawn[70] = sp(CLOSE_LEFT_BOTTOM, ROT_DOWN); redSpawn[70] = np();
        blueSpawn[71] = sp(CLOSE_LEFT_BOTTOM, ROT_UP); redSpawn[71] = np();
        blueSpawn[72] = np(); redSpawn[72] = sp(CLOSE_RIGHT_BOTTOM, ROT_DOWN);
        blueSpawn[73] = np(); redSpawn[73] = sp(CLOSE_RIGHT_BOTTOM, ROT_UP);
        blueSpawn[74] = sp(CLOSE_LEFT_BOTTOM, ROT_DOWN); redSpawn[74] = np();
        blueSpawn[75] = np(); redSpawn[75] = sp(FAR_RIGHT_TOP, ROT_LEFT);
        blueSpawn[76] = sp(CLOSE_LEFT_BOTTOM, ROT_UP); redSpawn[76] = sp(CLOSE_RIGHT_BOTTOM, ROT_UP);
        blueSpawn[77] = np(); redSpawn[77] = sp(CLOSE_RIGHT_BOTTOM, ROT_DOWN);
        blueSpawn[78] = sp(CLOSE_LEFT_BOTTOM, ROT_RIGHT); redSpawn[78] = np();
        blueSpawn[79] = np(); redSpawn[79] = sp(FAR_RIGHT_TOP, ROT_LEFT);
        blueSpawn[80] = np(); redSpawn[80] = sp(CLOSE_RIGHT_BOTTOM, ROT_UP);
        blueSpawn[81] = sp(FAR_LEFT_BOTTOM, ROT_UP); redSpawn[81] = np();
        blueSpawn[82] = np(); redSpawn[82] = np();
        blueSpawn[83] = np(); redSpawn[83] = sp(CLOSE_RIGHT_BOTTOM, ROT_DOWN);
        blueSpawn[84] = np(); redSpawn[84] = sp(CLOSE_RIGHT_BOTTOM, ROT_UP);
        blueSpawn[85] = sp(CLOSE_LEFT_BOTTOM, ROT_DOWN); redSpawn[85] = np();
        blueSpawn[86] = sp(CLOSE_LEFT_BOTTOM, ROT_UP); redSpawn[86] = np(); // 57 "can't convince you"


        started = 1;
    }
}
