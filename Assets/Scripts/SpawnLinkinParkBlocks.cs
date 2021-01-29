using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
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
            if (timer % 41 == 0)
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

            // Start music timing
            if (indexable == 2)
            {
                audioData = GameObject.Find("MusicBox").GetComponent<AudioSource>();
                audioData.Play(0);
            }

            // Level over successfully
            if (indexable > redSpawn.Length && indexable > blueSpawn.Length && started == 1)
            {
                started = 2;
                GoToMenuDelayed();
            }

            // Increment timer
            ++timer;
        }
    }

    void GoToMenuDelayed()
    {
        // Manually clean up objects in our hand so they don't transfer over to next scene
        GameObject[] cleanup = GameObject.FindGameObjectsWithTag("CleanManuallyOnSceneChange");
        foreach (GameObject cl in cleanup)
        {
            Destroy(cl, 0);
        }
        // Go to menu scene
        Invoke("GoToMenu", 0.5f);
    }

    void GoToMenu()
    {
            SceneManager.LoadScene("MainMenuScene", LoadSceneMode.Single);
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
        blueSpawn = new SpawnableBlock[340];
        redSpawn = new SpawnableBlock[340];

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
        blueSpawn[87] = np(); redSpawn[87] = sp(CLOSE_RIGHT_BOTTOM, ROT_DOWN);
        blueSpawn[88] = np(); redSpawn[88] = sp(CLOSE_RIGHT_BOTTOM, ROT_UP);
        blueSpawn[89] = sp(FAR_LEFT_TOP, ROT_RIGHT); redSpawn[89] = np();
        blueSpawn[90] = np(); redSpawn[90] = sp(FAR_RIGHT_TOP, ROT_LEFT);
        blueSpawn[91] = sp(CLOSE_LEFT_BOTTOM, ROT_UP); redSpawn[91] = sp(CLOSE_RIGHT_BOTTOM, ROT_UP);
        blueSpawn[92] = sp(CLOSE_LEFT_BOTTOM, ROT_DOWN); redSpawn[92] = np();
        blueSpawn[93] = np(); redSpawn[93] = sp(FAR_RIGHT_TOP, ROT_LEFT);
        blueSpawn[94] = sp(CLOSE_LEFT_BOTTOM, ROT_UP); redSpawn[94] = np();
        blueSpawn[95] = sp(FAR_LEFT_TOP, ROT_DOWN); redSpawn[95] = np();
        blueSpawn[96] = sp(CLOSE_LEFT_BOTTOM, ROT_UP); redSpawn[96] = np();
        blueSpawn[97] = np(); redSpawn[97] = sp(CLOSE_RIGHT_BOTTOM, ROT_UP);
        blueSpawn[98] = sp(CLOSE_LEFT_BOTTOM, ROT_DOWN); redSpawn[98] = np();
        blueSpawn[99] = sp(CLOSE_LEFT_BOTTOM, ROT_UP); redSpawn[99] = sp(CLOSE_RIGHT_BOTTOM, ROT_DOWN);
        blueSpawn[100] = np(); redSpawn[100] = sp(CLOSE_RIGHT_BOTTOM, ROT_UP);
        blueSpawn[101] = sp(CLOSE_LEFT_BOTTOM, ROT_DOWN); redSpawn[101] = np();
        blueSpawn[102] = np(); redSpawn[102] = sp(CLOSE_RIGHT_BOTTOM, ROT_DOWN);
        blueSpawn[103] = sp(CLOSE_LEFT_BOTTOM, ROT_UP); redSpawn[103] = sp(CLOSE_RIGHT_BOTTOM, ROT_UP);
        blueSpawn[104] = sp(FAR_LEFT_BOTTOM, ROT_RIGHT); redSpawn[104] = sp(FAR_RIGHT_BOTTOM, ROT_LEFT);
        blueSpawn[105] = sp(FAR_LEFT_BOTTOM, ROT_UP); redSpawn[105] = sp(CLOSE_LEFT_BOTTOM, ROT_UP); // 1:05 "i got"
        blueSpawn[106] = sp(FAR_LEFT_BOTTOM, ROT_DOWN); redSpawn[106] = sp(FAR_RIGHT_BOTTOM, ROT_DOWN);
        blueSpawn[107] = sp(CLOSE_RIGHT_BOTTOM, ROT_UP); redSpawn[107] = sp(FAR_RIGHT_BOTTOM, ROT_UP);
        blueSpawn[108] = np(); redSpawn[108] = sp(CLOSE_RIGHT_BOTTOM, ROT_DOWN);
        blueSpawn[109] = sp(FAR_LEFT_TOP, ROT_RIGHT); redSpawn[109] = np();
        blueSpawn[110] = np(); redSpawn[110] = sp(FAR_RIGHT_TOP, ROT_LEFT);
        blueSpawn[111] = sp(CLOSE_LEFT_BOTTOM, ROT_UP); redSpawn[111] = sp(CLOSE_RIGHT_BOTTOM, ROT_UP);
        blueSpawn[112] = np(); redSpawn[112] = sp(CLOSE_RIGHT_BOTTOM, ROT_DOWN);
        blueSpawn[113] = sp(FAR_LEFT_TOP, ROT_RIGHT); redSpawn[113] = np();
        blueSpawn[114] = np(); redSpawn[114] = sp(FAR_RIGHT_TOP, ROT_LEFT);
        blueSpawn[115] = sp(CLOSE_LEFT_BOTTOM, ROT_UP); redSpawn[115] = np();
        blueSpawn[116] = np(); redSpawn[116] = sp(CLOSE_RIGHT_BOTTOM, ROT_UP);
        blueSpawn[117] = sp(FAR_LEFT_BOTTOM, ROT_RIGHT); redSpawn[117] = np();
        blueSpawn[118] = np(); redSpawn[118] = sp(FAR_RIGHT_TOP, ROT_LEFT);
        blueSpawn[119] = sp(FAR_LEFT_BOTTOM, ROT_UP); redSpawn[119] = sp(CLOSE_LEFT_BOTTOM, ROT_UP);
        blueSpawn[120] = sp(FAR_LEFT_TOP, ROT_DOWN); redSpawn[120] = sp(FAR_RIGHT_TOP, ROT_DOWN);
        blueSpawn[121] = sp(CLOSE_RIGHT_BOTTOM, ROT_UP); redSpawn[121] = sp(FAR_RIGHT_BOTTOM, ROT_UP);
        blueSpawn[122] = np(); redSpawn[122] = sp(CLOSE_RIGHT_BOTTOM, ROT_DOWN);
        blueSpawn[123] = sp(FAR_LEFT_TOP, ROT_RIGHT); redSpawn[123] = np();
        blueSpawn[124] = np(); redSpawn[124] = sp(FAR_RIGHT_TOP, ROT_LEFT);
        blueSpawn[125] = sp(CLOSE_LEFT_BOTTOM, ROT_UP); redSpawn[125] = sp(CLOSE_RIGHT_BOTTOM, ROT_UP);
        blueSpawn[126] = np(); redSpawn[126] = sp(CLOSE_RIGHT_BOTTOM, ROT_DOWN);
        blueSpawn[127] = sp(FAR_LEFT_TOP, ROT_RIGHT); redSpawn[127] = np();
        blueSpawn[128] = np(); redSpawn[128] = sp(FAR_RIGHT_TOP, ROT_LEFT);
        blueSpawn[129] = sp(CLOSE_LEFT_BOTTOM, ROT_UP); redSpawn[129] = sp(CLOSE_RIGHT_BOTTOM, ROT_UP);
        blueSpawn[130] = sp(FAR_LEFT_BOTTOM, ROT_RIGHT); redSpawn[130] = np();
        blueSpawn[131] = np(); redSpawn[131] = np();
        blueSpawn[132] = np(); redSpawn[132] = sp(FAR_RIGHT_TOP, ROT_LEFT);
        blueSpawn[133] = sp(CLOSE_LEFT_BOTTOM, ROT_UP); redSpawn[133] = np();
        blueSpawn[134] = np(); redSpawn[134] = sp(CLOSE_RIGHT_BOTTOM, ROT_UP);
        blueSpawn[135] = sp(CLOSE_LEFT_BOTTOM, ROT_DOWN); redSpawn[135] = sp(CLOSE_RIGHT_BOTTOM, ROT_DOWN);
        blueSpawn[136] = sp(CLOSE_LEFT_BOTTOM, ROT_UP); redSpawn[136] = sp(CLOSE_RIGHT_BOTTOM, ROT_UP); // 1:18 "end of i dont wanna be ignored"
        blueSpawn[137] = np(); redSpawn[137] = sp(CLOSE_RIGHT_BOTTOM, ROT_DOWN);
        blueSpawn[138] = sp(CLOSE_LEFT_BOTTOM, ROT_RIGHT); redSpawn[138] = np();
        blueSpawn[139] = np(); redSpawn[139] = np();
        blueSpawn[140] = np(); redSpawn[140] = sp(FAR_RIGHT_TOP, ROT_LEFT);
        blueSpawn[141] = np(); redSpawn[141] = sp(CLOSE_RIGHT_BOTTOM, ROT_UP);
        blueSpawn[142] = sp(FAR_LEFT_BOTTOM, ROT_UP); redSpawn[142] = np();
        blueSpawn[143] = np(); redSpawn[143] = np();
        blueSpawn[144] = sp(CLOSE_LEFT_BOTTOM, ROT_DOWN); redSpawn[144] = np();
        blueSpawn[145] = sp(CLOSE_LEFT_BOTTOM, ROT_UP); redSpawn[145] = np();
        blueSpawn[146] = np(); redSpawn[146] = sp(CLOSE_RIGHT_BOTTOM, ROT_DOWN);
        blueSpawn[147] = np(); redSpawn[147] = sp(CLOSE_RIGHT_BOTTOM, ROT_UP);
        blueSpawn[148] = sp(CLOSE_LEFT_BOTTOM, ROT_DOWN); redSpawn[148] = np();
        blueSpawn[149] = sp(CLOSE_LEFT_BOTTOM, ROT_UP); redSpawn[149] = np();
        blueSpawn[150] = np(); redSpawn[150] = sp(CLOSE_RIGHT_BOTTOM, ROT_DOWN);
        blueSpawn[151] = sp(FAR_LEFT_TOP, ROT_RIGHT); redSpawn[151] = np();
        blueSpawn[152] = sp(CLOSE_LEFT_BOTTOM, ROT_UP); redSpawn[152] = sp(CLOSE_RIGHT_BOTTOM, ROT_UP);
        blueSpawn[153] = sp(CLOSE_LEFT_BOTTOM, ROT_DOWN); redSpawn[153] = np();
        blueSpawn[154] = np(); redSpawn[154] = sp(CLOSE_RIGHT_BOTTOM, ROT_LEFT);
        blueSpawn[155] = np(); redSpawn[155] = np();
        blueSpawn[156] = sp(FAR_LEFT_TOP, ROT_RIGHT); redSpawn[156] = np();
        blueSpawn[157] = sp(CLOSE_LEFT_BOTTOM, ROT_UP); redSpawn[157] = np();
        blueSpawn[158] = np(); redSpawn[158] = sp(FAR_RIGHT_BOTTOM, ROT_UP);
        blueSpawn[159] = sp(CLOSE_LEFT_BOTTOM, ROT_DOWN); redSpawn[159] = np();
        blueSpawn[160] = sp(CLOSE_LEFT_BOTTOM, ROT_UP); redSpawn[160] = np();
        blueSpawn[161] = np(); redSpawn[161] = sp(CLOSE_RIGHT_BOTTOM, ROT_DOWN);
        blueSpawn[162] = np(); redSpawn[162] = sp(CLOSE_RIGHT_BOTTOM, ROT_UP);
        blueSpawn[163] = sp(CLOSE_LEFT_BOTTOM, ROT_DOWN); redSpawn[163] = np();
        blueSpawn[164] = sp(CLOSE_LEFT_BOTTOM, ROT_UP); redSpawn[164] = np();
        blueSpawn[165] = np(); redSpawn[165] = sp(FAR_RIGHT_TOP, ROT_LEFT);
        blueSpawn[166] = sp(FAR_LEFT_TOP, ROT_RIGHT); redSpawn[166] = np();
        blueSpawn[167] = sp(CLOSE_LEFT_BOTTOM, ROT_UP); redSpawn[167] = sp(CLOSE_RIGHT_BOTTOM, ROT_UP);
        blueSpawn[168] = np(); redSpawn[168] = sp(CLOSE_RIGHT_BOTTOM, ROT_DOWN); // 1:30 "so I"
        blueSpawn[169] = sp(FAR_LEFT_TOP, ROT_RIGHT); redSpawn[169] = np();
        blueSpawn[170] = np(); redSpawn[170] = sp(CLOSE_RIGHT_BOTTOM, ROT_UP);
        blueSpawn[171] = np(); redSpawn[171] = sp(FAR_RIGHT_TOP, ROT_DOWN);
        blueSpawn[172] = np(); redSpawn[172] = sp(CLOSE_RIGHT_BOTTOM, ROT_UP);
        blueSpawn[173] = sp(CLOSE_LEFT_BOTTOM, ROT_UP); redSpawn[173] = np();
        blueSpawn[174] = np(); redSpawn[174] = sp(CLOSE_RIGHT_BOTTOM, ROT_DOWN);
        blueSpawn[175] = sp(CLOSE_LEFT_BOTTOM, ROT_DOWN); redSpawn[175] = sp(CLOSE_RIGHT_BOTTOM, ROT_UP);
        blueSpawn[176] = sp(CLOSE_LEFT_BOTTOM, ROT_UP); redSpawn[176] = np();
        blueSpawn[177] = np(); redSpawn[177] = sp(CLOSE_RIGHT_BOTTOM, ROT_DOWN);
        blueSpawn[178] = sp(CLOSE_LEFT_BOTTOM, ROT_DOWN); redSpawn[178] = np();
        blueSpawn[179] = sp(CLOSE_LEFT_BOTTOM, ROT_UP); redSpawn[179] = sp(CLOSE_RIGHT_BOTTOM, ROT_UP);
        blueSpawn[180] = np(); redSpawn[180] = sp(CLOSE_RIGHT_BOTTOM, ROT_DOWN);
        blueSpawn[181] = sp(FAR_LEFT_TOP, ROT_RIGHT); redSpawn[181] = np();
        blueSpawn[182] = np(); redSpawn[182] = sp(FAR_RIGHT_TOP, ROT_LEFT);
        blueSpawn[183] = np(); redSpawn[183] = np();
        blueSpawn[184] = sp(CLOSE_LEFT_BOTTOM, ROT_DOWN); redSpawn[184] = sp(CLOSE_RIGHT_BOTTOM, ROT_DOWN);
        blueSpawn[185] = sp(CLOSE_LEFT_BOTTOM, ROT_UP); redSpawn[185] = sp(CLOSE_RIGHT_BOTTOM, ROT_UP);
        blueSpawn[186] = sp(FAR_LEFT_TOP, ROT_DOWN); redSpawn[186] = sp(FAR_RIGHT_TOP, ROT_DOWN);
        blueSpawn[187] = sp(FAR_LEFT_BOTTOM, ROT_UP); redSpawn[187] = sp(CLOSE_LEFT_BOTTOM, ROT_UP);
        blueSpawn[188] = sp(CLOSE_LEFT_BOTTOM, ROT_DOWN); redSpawn[188] = np();
        blueSpawn[189] = np(); redSpawn[189] = sp(FAR_RIGHT_TOP, ROT_LEFT);
        blueSpawn[190] = sp(FAR_LEFT_TOP, ROT_RIGHT); redSpawn[190] = np();
        blueSpawn[191] = sp(CLOSE_LEFT_BOTTOM, ROT_UP); redSpawn[191] = sp(CLOSE_RIGHT_BOTTOM, ROT_UP);
        blueSpawn[192] = sp(CLOSE_LEFT_BOTTOM, ROT_DOWN); redSpawn[192] = np();
        blueSpawn[193] = np(); redSpawn[193] = sp(FAR_RIGHT_TOP, ROT_LEFT);
        blueSpawn[194] = sp(FAR_LEFT_TOP, ROT_RIGHT); redSpawn[194] = np();
        blueSpawn[195] = np(); redSpawn[195] = sp(CLOSE_RIGHT_BOTTOM, ROT_UP);
        blueSpawn[196] = sp(CLOSE_LEFT_BOTTOM, ROT_UP); redSpawn[196] = np();
        blueSpawn[197] = np(); redSpawn[197] = sp(FAR_RIGHT_BOTTOM, ROT_LEFT);
        blueSpawn[198] = sp(FAR_LEFT_TOP, ROT_RIGHT); redSpawn[198] = np();
        blueSpawn[199] = sp(CLOSE_RIGHT_BOTTOM, ROT_UP); redSpawn[199] = sp(FAR_RIGHT_BOTTOM, ROT_UP);
        blueSpawn[200] = sp(FAR_LEFT_TOP, ROT_DOWN); redSpawn[200] = sp(FAR_RIGHT_TOP, ROT_DOWN);
        blueSpawn[201] = sp(FAR_LEFT_BOTTOM, ROT_UP); redSpawn[201] = sp(CLOSE_LEFT_BOTTOM, ROT_UP); // 1:43 "i wont be ignored"
        blueSpawn[202] = sp(CLOSE_LEFT_BOTTOM, ROT_DOWN); redSpawn[202] = np();
        blueSpawn[203] = np(); redSpawn[203] = sp(FAR_RIGHT_TOP, ROT_LEFT);
        blueSpawn[204] = sp(FAR_LEFT_TOP, ROT_RIGHT); redSpawn[204] = np();
        blueSpawn[205] = sp(CLOSE_LEFT_BOTTOM, ROT_UP); redSpawn[205] = sp(CLOSE_RIGHT_BOTTOM, ROT_UP);
        blueSpawn[206] = sp(CLOSE_LEFT_BOTTOM, ROT_DOWN); redSpawn[206] = np();
        blueSpawn[207] = np(); redSpawn[207] = sp(FAR_RIGHT_TOP, ROT_LEFT);
        blueSpawn[208] = sp(FAR_LEFT_TOP, ROT_RIGHT); redSpawn[208] = np();
        blueSpawn[209] = np(); redSpawn[209] = sp(CLOSE_RIGHT_BOTTOM, ROT_UP);
        blueSpawn[210] = sp(CLOSE_LEFT_BOTTOM, ROT_UP); redSpawn[210] = np();
        blueSpawn[211] = np(); redSpawn[211] = sp(FAR_RIGHT_BOTTOM, ROT_LEFT);
        blueSpawn[212] = sp(FAR_LEFT_TOP, ROT_RIGHT); redSpawn[212] = np();
        blueSpawn[213] = np(); redSpawn[213] = sp(CLOSE_RIGHT_BOTTOM, ROT_UP);
        blueSpawn[214] = sp(CLOSE_LEFT_BOTTOM, ROT_UP); redSpawn[214] = np();
        blueSpawn[215] = sp(CLOSE_LEFT_BOTTOM, ROT_DOWN); redSpawn[215] = sp(CLOSE_RIGHT_BOTTOM, ROT_DOWN);
        blueSpawn[216] = sp(CLOSE_RIGHT_BOTTOM, ROT_UP); redSpawn[216] = sp(FAR_RIGHT_BOTTOM, ROT_UP);
        blueSpawn[217] = np(); redSpawn[217] = sp(FAR_RIGHT_BOTTOM, ROT_DOWN);
        blueSpawn[218] = sp(FAR_LEFT_TOP, ROT_RIGHT); redSpawn[218] = sp(FAR_LEFT_BOTTOM, ROT_RIGHT);
        blueSpawn[219] = sp(FAR_RIGHT_BOTTOM, ROT_LEFT); redSpawn[219] = sp(FAR_RIGHT_TOP, ROT_LEFT);
        blueSpawn[220] = sp(CLOSE_LEFT_BOTTOM, ROT_RIGHT); redSpawn[220] = np();
        blueSpawn[221] = sp(CLOSE_LEFT_BOTTOM, ROT_UP); redSpawn[221] = sp(CLOSE_RIGHT_BOTTOM, ROT_UP);
        blueSpawn[222] = np(); redSpawn[222] = np();
        blueSpawn[223] = sp(FAR_LEFT_TOP, ROT_RIGHT); redSpawn[223] = sp(FAR_RIGHT_TOP, ROT_LEFT);
        blueSpawn[224] = sp(CLOSE_LEFT_BOTTOM, ROT_UP); redSpawn[224] = np();
        blueSpawn[225] = sp(CLOSE_RIGHT_BOTTOM, ROT_DOWN); redSpawn[225] = sp(FAR_RIGHT_BOTTOM, ROT_UP);
        blueSpawn[226] = sp(FAR_LEFT_BOTTOM, ROT_UP); redSpawn[226] = np();
        blueSpawn[227] = sp(CLOSE_LEFT_BOTTOM, ROT_DOWN); redSpawn[227] = sp(CLOSE_RIGHT_BOTTOM, ROT_DOWN);
        blueSpawn[228] = np(); redSpawn[228] = sp(CLOSE_LEFT_BOTTOM, ROT_UP);
        blueSpawn[229] = sp(FAR_LEFT_BOTTOM, ROT_UP); redSpawn[229] = np();
        blueSpawn[230] = sp(CLOSE_LEFT_BOTTOM, ROT_DOWN); redSpawn[230] = sp(CLOSE_RIGHT_BOTTOM, ROT_DOWN);
        blueSpawn[231] = sp(CLOSE_RIGHT_BOTTOM, ROT_UP); redSpawn[231] = sp(FAR_RIGHT_BOTTOM, ROT_UP);
        blueSpawn[232] = np(); redSpawn[232] = sp(FAR_RIGHT_BOTTOM, ROT_DOWN);
        blueSpawn[233] = sp(FAR_LEFT_TOP, ROT_RIGHT); redSpawn[233] = sp(FAR_LEFT_BOTTOM, ROT_RIGHT);
        blueSpawn[234] = sp(FAR_RIGHT_BOTTOM, ROT_LEFT); redSpawn[234] = sp(FAR_RIGHT_TOP, ROT_LEFT);
        blueSpawn[235] = sp(CLOSE_LEFT_BOTTOM, ROT_RIGHT); redSpawn[235] = np();
        blueSpawn[236] = sp(CLOSE_LEFT_BOTTOM, ROT_UP); redSpawn[236] = sp(CLOSE_RIGHT_BOTTOM, ROT_UP);
        blueSpawn[237] = np(); redSpawn[237] = np();
        blueSpawn[238] = sp(FAR_LEFT_TOP, ROT_RIGHT); redSpawn[238] = sp(FAR_RIGHT_TOP, ROT_LEFT);
        blueSpawn[239] = sp(CLOSE_LEFT_BOTTOM, ROT_UP); redSpawn[239] = np();
        blueSpawn[240] = sp(CLOSE_RIGHT_BOTTOM, ROT_DOWN); redSpawn[240] = sp(FAR_RIGHT_BOTTOM, ROT_UP);
        blueSpawn[241] = sp(FAR_LEFT_BOTTOM, ROT_UP); redSpawn[241] = np();
        blueSpawn[242] = sp(CLOSE_LEFT_BOTTOM, ROT_DOWN); redSpawn[242] = sp(CLOSE_RIGHT_BOTTOM, ROT_DOWN); // 2:01 "listen to me"
        blueSpawn[243] = np(); redSpawn[243] = sp(CLOSE_LEFT_BOTTOM, ROT_UP);
        blueSpawn[244] = sp(FAR_LEFT_BOTTOM, ROT_UP); redSpawn[244] = np();
        blueSpawn[245] = sp(CLOSE_LEFT_BOTTOM, ROT_DOWN); redSpawn[245] = sp(CLOSE_RIGHT_BOTTOM, ROT_DOWN);
        blueSpawn[246] = np(); redSpawn[246] = sp(FAR_RIGHT_BOTTOM, ROT_LEFT);
        blueSpawn[247] = sp(FAR_LEFT_BOTTOM, ROT_RIGHT); redSpawn[247] = np();
        blueSpawn[248] = np(); redSpawn[248] = sp(FAR_RIGHT_BOTTOM, ROT_LEFT);
        blueSpawn[249] = np(); redSpawn[249] = np();
        blueSpawn[250] = sp(CLOSE_LEFT_BOTTOM, ROT_UP); redSpawn[250] = np();
        blueSpawn[251] = np(); redSpawn[251] = sp(CLOSE_RIGHT_BOTTOM, ROT_UP);
        blueSpawn[252] = sp(CLOSE_LEFT_BOTTOM, ROT_RIGHT); redSpawn[252] = np();
        blueSpawn[253] = np(); redSpawn[253] = np();
        blueSpawn[254] = np(); redSpawn[254] = sp(CLOSE_RIGHT_BOTTOM, ROT_LEFT);
        blueSpawn[255] = sp(CLOSE_LEFT_BOTTOM, ROT_UP); redSpawn[255] = np();
        blueSpawn[256] = np(); redSpawn[256] = sp(CLOSE_RIGHT_BOTTOM, ROT_UP);
        blueSpawn[257] = sp(CLOSE_RIGHT_BOTTOM, ROT_DOWN); redSpawn[257] = sp(CLOSE_LEFT_BOTTOM, ROT_DOWN); // 2:07 big pause
        blueSpawn[258] = np(); redSpawn[258] = np();
        blueSpawn[259] = np(); redSpawn[259] = np();
        blueSpawn[260] = np(); redSpawn[260] = np();
        blueSpawn[261] = np(); redSpawn[261] = np();
        blueSpawn[262] = np(); redSpawn[262] = np();
        blueSpawn[263] = np(); redSpawn[263] = np();
        blueSpawn[264] = sp(CLOSE_RIGHT_BOTTOM, ROT_UP); redSpawn[264] = sp(CLOSE_LEFT_BOTTOM, ROT_UP);
        blueSpawn[265] = sp(FAR_LEFT_TOP, ROT_DOWN); redSpawn[265] = sp(FAR_RIGHT_TOP, ROT_DOWN);
        blueSpawn[266] = sp(CLOSE_RIGHT_BOTTOM, ROT_UP); redSpawn[266] = sp(CLOSE_LEFT_BOTTOM, ROT_UP);
        blueSpawn[267] = np(); redSpawn[267] = sp(CLOSE_RIGHT_BOTTOM, ROT_DOWN);
        blueSpawn[268] = sp(FAR_LEFT_TOP, ROT_RIGHT); redSpawn[268] = np();
        blueSpawn[269] = np(); redSpawn[269] = sp(FAR_RIGHT_TOP, ROT_LEFT);
        blueSpawn[270] = np(); redSpawn[270] = np();
        blueSpawn[271] = sp(CLOSE_LEFT_BOTTOM, ROT_UP); redSpawn[271] = sp(CLOSE_RIGHT_BOTTOM, ROT_UP);
        blueSpawn[272] = np(); redSpawn[272] = sp(CLOSE_RIGHT_BOTTOM, ROT_DOWN);
        blueSpawn[273] = sp(FAR_LEFT_TOP, ROT_RIGHT); redSpawn[273] = np();
        blueSpawn[274] = np(); redSpawn[274] = sp(FAR_RIGHT_TOP, ROT_LEFT);
        blueSpawn[275] = sp(CLOSE_LEFT_BOTTOM, ROT_UP); redSpawn[275] = np();
        blueSpawn[276] = np(); redSpawn[276] = sp(CLOSE_RIGHT_BOTTOM, ROT_UP);
        blueSpawn[277] = sp(FAR_LEFT_BOTTOM, ROT_RIGHT); redSpawn[277] = np();
        blueSpawn[278] = np(); redSpawn[278] = np();
        blueSpawn[279] = np(); redSpawn[279] = sp(FAR_RIGHT_TOP, ROT_LEFT);
        blueSpawn[280] = sp(CLOSE_RIGHT_BOTTOM, ROT_UP); redSpawn[280] = sp(CLOSE_LEFT_BOTTOM, ROT_UP);
        blueSpawn[281] = sp(FAR_LEFT_TOP, ROT_DOWN); redSpawn[281] = sp(FAR_RIGHT_TOP, ROT_DOWN);
        blueSpawn[282] = sp(CLOSE_RIGHT_BOTTOM, ROT_UP); redSpawn[282] = sp(CLOSE_LEFT_BOTTOM, ROT_UP);
        blueSpawn[283] = np(); redSpawn[283] = sp(CLOSE_RIGHT_BOTTOM, ROT_DOWN);
        blueSpawn[284] = sp(FAR_LEFT_TOP, ROT_RIGHT); redSpawn[284] = np();
        blueSpawn[285] = np(); redSpawn[285] = sp(FAR_RIGHT_TOP, ROT_LEFT);
        blueSpawn[286] = sp(CLOSE_LEFT_BOTTOM, ROT_UP); redSpawn[286] = sp(CLOSE_RIGHT_BOTTOM, ROT_UP);
        blueSpawn[287] = np(); redSpawn[287] = sp(CLOSE_RIGHT_BOTTOM, ROT_DOWN);
        blueSpawn[288] = sp(FAR_LEFT_TOP, ROT_RIGHT); redSpawn[288] = np();
        blueSpawn[289] = np(); redSpawn[289] = sp(FAR_RIGHT_TOP, ROT_LEFT);
        blueSpawn[290] = sp(CLOSE_LEFT_BOTTOM, ROT_UP); redSpawn[290] = np();
        blueSpawn[291] = np(); redSpawn[291] = sp(CLOSE_RIGHT_BOTTOM, ROT_UP);
        blueSpawn[292] = sp(FAR_LEFT_BOTTOM, ROT_RIGHT); redSpawn[292] = np();
        blueSpawn[293] = np(); redSpawn[293] = np();
        blueSpawn[294] = np(); redSpawn[294] = sp(CLOSE_RIGHT_BOTTOM, ROT_DOWN);
        blueSpawn[295] = sp(FAR_RIGHT_BOTTOM, ROT_LEFT); redSpawn[295] = sp(FAR_RIGHT_TOP, ROT_LEFT);
        blueSpawn[296] = sp(FAR_LEFT_TOP, ROT_RIGHT); redSpawn[296] = sp(FAR_LEFT_BOTTOM, ROT_RIGHT);
        blueSpawn[297] = sp(FAR_RIGHT_BOTTOM, ROT_LEFT); redSpawn[297] = sp(FAR_RIGHT_TOP, ROT_LEFT);
        blueSpawn[298] = sp(CLOSE_LEFT_BOTTOM, ROT_RIGHT); redSpawn[298] = np();
        blueSpawn[299] = np(); redSpawn[299] = sp(CLOSE_RIGHT_BOTTOM, ROT_UP);
        blueSpawn[300] = np(); redSpawn[300] = np();
        blueSpawn[301] = sp(CLOSE_RIGHT_BOTTOM, ROT_LEFT); redSpawn[301] = np();
        blueSpawn[302] = sp(FAR_LEFT_TOP, ROT_RIGHT); redSpawn[302] = np();
        blueSpawn[303] = np(); redSpawn[303] = sp(FAR_RIGHT_TOP, ROT_LEFT);
        blueSpawn[304] = sp(CLOSE_LEFT_BOTTOM, ROT_UP); redSpawn[304] = np();
        blueSpawn[305] = sp(FAR_LEFT_TOP, ROT_DOWN); redSpawn[305] = np();
        blueSpawn[306] = np(); redSpawn[306] = sp(CLOSE_RIGHT_BOTTOM, ROT_UP);
        blueSpawn[307] = sp(CLOSE_LEFT_BOTTOM, ROT_UP); redSpawn[307] = np();
        blueSpawn[308] = np(); redSpawn[308] = np();
        blueSpawn[309] = sp(CLOSE_LEFT_BOTTOM, ROT_DOWN); redSpawn[309] = np();
        blueSpawn[310] = sp(FAR_RIGHT_BOTTOM, ROT_LEFT); redSpawn[310] = sp(FAR_RIGHT_TOP, ROT_LEFT);
        blueSpawn[311] = sp(FAR_LEFT_TOP, ROT_RIGHT); redSpawn[311] = sp(FAR_LEFT_BOTTOM, ROT_RIGHT);
        blueSpawn[312] = sp(FAR_RIGHT_BOTTOM, ROT_LEFT); redSpawn[312] = sp(FAR_RIGHT_TOP, ROT_LEFT);
        blueSpawn[313] = sp(CLOSE_LEFT_BOTTOM, ROT_RIGHT); redSpawn[313] = np();
        blueSpawn[314] = np(); redSpawn[314] = sp(CLOSE_RIGHT_BOTTOM, ROT_UP);
        blueSpawn[315] = np(); redSpawn[315] = np();
        blueSpawn[316] = sp(CLOSE_RIGHT_BOTTOM, ROT_LEFT); redSpawn[316] = np();
        blueSpawn[317] = sp(FAR_LEFT_TOP, ROT_RIGHT); redSpawn[317] = np();
        blueSpawn[318] = np(); redSpawn[318] = sp(FAR_RIGHT_TOP, ROT_LEFT);
        blueSpawn[319] = sp(CLOSE_LEFT_BOTTOM, ROT_UP); redSpawn[319] = np();
        blueSpawn[320] = sp(FAR_LEFT_TOP, ROT_DOWN); redSpawn[320] = np();
        blueSpawn[321] = np(); redSpawn[321] = sp(CLOSE_RIGHT_BOTTOM, ROT_UP);
        blueSpawn[322] = sp(CLOSE_LEFT_BOTTOM, ROT_UP); redSpawn[322] = np();
        blueSpawn[323] = np(); redSpawn[323] = sp(FAR_RIGHT_TOP, ROT_LEFT);
        blueSpawn[324] = sp(CLOSE_LEFT_BOTTOM, ROT_DOWN); redSpawn[324] = np();
        blueSpawn[325] = np(); redSpawn[325] = sp(CLOSE_LEFT_BOTTOM, ROT_RIGHT);
        blueSpawn[326] = np(); redSpawn[326] = sp(FAR_RIGHT_TOP, ROT_LEFT);
        blueSpawn[327] = sp(CLOSE_LEFT_BOTTOM, ROT_UP); redSpawn[327] = np();
        blueSpawn[328] = np(); redSpawn[328] = sp(CLOSE_RIGHT_BOTTOM, ROT_UP);
        blueSpawn[329] = sp(FAR_LEFT_TOP, ROT_RIGHT); redSpawn[329] = np();
        blueSpawn[330] = np(); redSpawn[330] = np();
        blueSpawn[331] = np(); redSpawn[331] = np();
        blueSpawn[332] = np(); redSpawn[332] = np();
        blueSpawn[333] = np(); redSpawn[333] = np();
        blueSpawn[334] = np(); redSpawn[334] = np();
        blueSpawn[335] = np(); redSpawn[335] = np();
        blueSpawn[336] = np(); redSpawn[336] = np();
        blueSpawn[337] = np(); redSpawn[337] = np();
        blueSpawn[338] = np(); redSpawn[338] = np();
        blueSpawn[339] = np(); redSpawn[339] = np();

        started = 1;
    }
}
