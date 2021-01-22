using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CheckSlashing : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == gameObject.layer)
        {
            Destroy(other.gameObject);
            HandleScore.scoreValue += 1;
        }

        if (other.gameObject.layer == LayerMask.NameToLayer("Menu"))
        {
            if (other.gameObject.name == "InfiniteModeButton")
            {
                HandleScore.currentScene = 2;
                HandleScore.scoreValue = 0;
                SceneManager.LoadScene("AlanWalkerScene", LoadSceneMode.Additive);
            } else if (other.gameObject.name == "LevelModeButton")
            {

            }
            
            GameObject[] cleanup = GameObject.FindGameObjectsWithTag("Menu");
            foreach (GameObject cl in cleanup)
            {
                Destroy(cl, 0);
            }
        }
    }
}
