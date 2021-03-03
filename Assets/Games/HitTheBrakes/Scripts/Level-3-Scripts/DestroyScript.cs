using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyScript : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        if (!GetComponent<Animation>().isPlaying) {
             Destroy (this);
        }
    }
}
