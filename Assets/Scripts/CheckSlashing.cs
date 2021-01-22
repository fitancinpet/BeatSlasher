using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckSlashing : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == gameObject.layer)
        {
            Destroy(other.gameObject);
        }
    }
}
