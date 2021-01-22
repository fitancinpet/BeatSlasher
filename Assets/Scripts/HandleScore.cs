using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class HandleScore : MonoBehaviour
{
    public static int scoreValue;
    public static int currentScene;
    TextMesh score;

    // Start is called before the first frame update
    void Start()
    {
        score = GetComponent<TextMesh>();
        scoreValue = 0;
        currentScene = 0;
        SceneManager.LoadScene("MainMenuScene", LoadSceneMode.Single);
    }

    // Update is called once per frame
    void Update()
    {
        if (currentScene > 1)
        {
            // Update score text
            score.text = "" + scoreValue;

            // If we fail
            if (scoreValue < 0)
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
        }        
    }

    void GoToMenu()
    {
            SceneManager.LoadScene("MainMenuScene", LoadSceneMode.Single);
            currentScene = 1;
    }
}
