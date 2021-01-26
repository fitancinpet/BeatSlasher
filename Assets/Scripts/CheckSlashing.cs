using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CheckSlashing : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        // Holding Blue Weapon
        if (gameObject.name == "LeftWeapon")
        {
            // Correct angle hit +1 score
            if (other.gameObject.name == "SuccessBLUE")
            {
                Destroy(other.gameObject.transform.parent.gameObject);
                HandleScore.scoreValue += 1;
            }
            // Wrong angle hit -3 score
            else if (other.gameObject.name == "FailBLUE")
            {
                Destroy(other.gameObject.transform.parent.gameObject);
                HandleScore.scoreValue -= 3;
            }
            // Correct angle but wrong color -5 score
            else if (other.gameObject.name == "SuccessRED")
            {
                Destroy(other.gameObject.transform.parent.gameObject);
                HandleScore.scoreValue -= 5;
            }
            // Wrong angle and color -8 score
            else if (other.gameObject.name == "FailRED")
            {
                Destroy(other.gameObject.transform.parent.gameObject);
                HandleScore.scoreValue -= 8;
            }
        }
        else if (gameObject.name == "RightWeapon")
        {
            // Correct angle hit +1 score
            if (other.gameObject.name == "SuccessRED")
            {
                Destroy(other.gameObject.transform.parent.gameObject);
                HandleScore.scoreValue += 1;
            }
            // Wrong angle hit -3 score
            else if (other.gameObject.name == "FailRED")
            {
                Destroy(other.gameObject.transform.parent.gameObject);
                HandleScore.scoreValue -= 3;
            }
            // Correct angle but wrong color -5 score
            else if (other.gameObject.name == "SuccessBLUE")
            {
                Destroy(other.gameObject.transform.parent.gameObject);
                HandleScore.scoreValue -= 5;
            }
            // Wrong angle and color -8 score
            else if (other.gameObject.name == "FailBLUE")
            {
                Destroy(other.gameObject.transform.parent.gameObject);
                HandleScore.scoreValue -= 8;
            }
        }

        if (other.gameObject.layer == LayerMask.NameToLayer("Menu"))
        {
            if (other.gameObject.name == "InfiniteModeButton")
            {
                HandleScore.currentScene = 2;
                HandleScore.scoreValue = 0;
                SceneManager.LoadScene("AlanWalkerScene", LoadSceneMode.Additive);
            }
            else if (other.gameObject.name == "LevelModeButton")
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
