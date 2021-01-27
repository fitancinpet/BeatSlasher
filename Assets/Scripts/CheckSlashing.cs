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

    void OnTriggerEnter(Collider other)
    {
        // Holding Blue Weapon
        if (gameObject.name == "LeftWeapon")
        {
            // Correct angle hit +1 score
            if (other.gameObject.name == "SuccessBLUE")
            {
                hapticAction.Execute(0, 0.2, 150, 75, SteamVR_Input_Sources.LeftHand);
                Instantiate(successHit, other.gameObject.transform.position, Quaternion.identity);
                Destroy(other.gameObject.transform.parent.gameObject);
                HandleScore.scoreValue += 1;
            }
            // Wrong angle hit -3 score
            else if (other.gameObject.name == "FailBLUE")
            {
                Instantiate(failHit, other.gameObject.transform.position, Quaternion.identity);
                Destroy(other.gameObject.transform.parent.gameObject);
                HandleScore.scoreValue -= 3;
            }
            // Correct angle but wrong color -5 score
            else if (other.gameObject.name == "SuccessRED")
            {
                Instantiate(failHit, other.gameObject.transform.position, Quaternion.identity);
                Destroy(other.gameObject.transform.parent.gameObject);
                HandleScore.scoreValue -= 5;
            }
            // Wrong angle and color -8 score
            else if (other.gameObject.name == "FailRED")
            {
                Instantiate(failHit, other.gameObject.transform.position, Quaternion.identity);
                Destroy(other.gameObject.transform.parent.gameObject);
                HandleScore.scoreValue -= 8;
            }
        }
        // Holding Red Weapon
        else if (gameObject.name == "RightWeapon")
        {
            // Correct angle hit +1 score
            if (other.gameObject.name == "SuccessRED")
            {
                hapticAction.Execute(0, 0.2, 150, 75, SteamVR_Input_Sources.RightHand);
                Instantiate(successHit, other.gameObject.transform.position, Quaternion.identity);
                Destroy(other.gameObject.transform.parent.gameObject);
                HandleScore.scoreValue += 1;
            }
            // Wrong angle hit -3 score
            else if (other.gameObject.name == "FailRED")
            {
                Instantiate(failHit, other.gameObject.transform.position, Quaternion.identity);
                Destroy(other.gameObject.transform.parent.gameObject);
                HandleScore.scoreValue -= 3;
            }
            // Correct angle but wrong color -5 score
            else if (other.gameObject.name == "SuccessBLUE")
            {
                Instantiate(failHit, other.gameObject.transform.position, Quaternion.identity);
                Destroy(other.gameObject.transform.parent.gameObject);
                HandleScore.scoreValue -= 5;
            }
            // Wrong angle and color -8 score
            else if (other.gameObject.name == "FailBLUE")
            {
                Instantiate(failHit, other.gameObject.transform.position, Quaternion.identity);
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
