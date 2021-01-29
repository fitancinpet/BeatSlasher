using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Valve.VR;

public class CheckSlashing : MonoBehaviour
{
    public GameObject successHit;
    public GameObject failHit;
    public SteamVR_Action_Vibration hapticAction;

    public GameObject getParent(Collider other)
    {
        if (other != null &&
            other.gameObject != null && 
            other.gameObject.transform != null && 
            other.gameObject.transform.parent != null &&
            other.gameObject.transform.parent.gameObject != null &&
            other.gameObject.transform.parent.gameObject.GetComponent<variables>() != null)
        {
            return other.gameObject.transform.parent.gameObject;
        }
        return null;
    }

    void OnTriggerEnter(Collider other)
    {
        GameObject par = getParent(other);
        // Holding Blue Weapon
        if (gameObject.name == "LeftWeapon" && par != null && par.GetComponent<variables>().state == 0)
        {
            // Correct angle hit +1 score
            if (other.gameObject.name == "SuccessBLUE")
            {
                par.GetComponent<variables>().state = 1;
                Instantiate(successHit, other.gameObject.transform.position, Quaternion.identity);
                Destroy(par);
                HandleScore.scoreValue += 1;
                hapticAction.Execute(0, 0.2f, 150, 75, SteamVR_Input_Sources.LeftHand);
            }
            // Wrong angle hit -3 score
            else if (other.gameObject.name == "FailBLUE")
            {
                par.GetComponent<variables>().state = 1;
                Instantiate(failHit, other.gameObject.transform.position, Quaternion.identity);
                Destroy(par);
                HandleScore.scoreValue -= 3;
            }
            // Correct angle but wrong color -5 score
            else if (other.gameObject.name == "SuccessRED")
            {
                par.GetComponent<variables>().state = 1;
                Instantiate(failHit, other.gameObject.transform.position, Quaternion.identity);
                Destroy(par);
                HandleScore.scoreValue -= 5;
            }
            // Wrong angle and color -8 score
            else if (other.gameObject.name == "FailRED")
            {
                par.GetComponent<variables>().state = 1;
                Instantiate(failHit, other.gameObject.transform.position, Quaternion.identity);
                Destroy(par);
                HandleScore.scoreValue -= 8;
            }
        }
        // Holding Red Weapon
        else if (gameObject.name == "RightWeapon" && par != null && par.GetComponent<variables>().state == 0)
        {
            // Correct angle hit +1 score
            if (other.gameObject.name == "SuccessRED")
            {
                par.GetComponent<variables>().state = 1;
                Instantiate(successHit, other.gameObject.transform.position, Quaternion.identity);
                Destroy(par);
                HandleScore.scoreValue += 1;
                hapticAction.Execute(0, 0.2f, 150, 75, SteamVR_Input_Sources.RightHand);
            }
            // Wrong angle hit -3 score
            else if (other.gameObject.name == "FailRED")
            {
                par.GetComponent<variables>().state = 1;
                Instantiate(failHit, other.gameObject.transform.position, Quaternion.identity);
                Destroy(par);
                HandleScore.scoreValue -= 3;
            }
            // Correct angle but wrong color -5 score
            else if (other.gameObject.name == "SuccessBLUE")
            {
                par.GetComponent<variables>().state = 1;
                Instantiate(failHit, other.gameObject.transform.position, Quaternion.identity);
                Destroy(par);
                HandleScore.scoreValue -= 5;
            }
            // Wrong angle and color -8 score
            else if (other.gameObject.name == "FailBLUE")
            {
                par.GetComponent<variables>().state = 1;
                Instantiate(failHit, other.gameObject.transform.position, Quaternion.identity);
                Destroy(par);
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
                HandleScore.currentScene = 3;
                HandleScore.scoreValue = 5;
                SceneManager.LoadScene("LevelModeScene", LoadSceneMode.Additive);
            }
            
            GameObject[] cleanup = GameObject.FindGameObjectsWithTag("Menu");
            foreach (GameObject cl in cleanup)
            {
                Destroy(cl, 0);
            }
        }
    }
}
