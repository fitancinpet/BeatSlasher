using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlashableBlockMove : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Constant movement each time frame
        transform.position += Time.deltaTime * transform.forward * 2;
        // If block reaches out of bounds, despawn it
        if (transform.position.z > 0)
        {
            HandleScore.scoreValue -= 1;
            Destroy(gameObject);
        }
    }
}
