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
            HandleScore.currentScene = 2;
            HandleScore.scoreValue = 0;
            SceneManager.LoadScene("AlanWalkerScene", LoadSceneMode.Additive);
            Destroy(other.gameObject);
        }
    }
}
