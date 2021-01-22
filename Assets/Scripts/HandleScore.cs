using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HandleScore : MonoBehaviour
{
    public static int scoreValue;
    TextMesh score;
    // Start is called before the first frame update
    void Start()
    {
        score = GetComponent<TextMesh>();
        scoreValue = 0;
    }

    // Update is called once per frame
    void Update()
    {
        score.text = "" + scoreValue;
    }
}
