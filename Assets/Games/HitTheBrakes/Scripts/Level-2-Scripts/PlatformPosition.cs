using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformPosition : MonoBehaviour
{
    public Transform offset;
    public Transform spawnPoint;
    public RandomNumberGenerator rng;
    // Start is called before the first frame update
    public void setPlatform()
    {
        //transform.rotation = new Quaternion(0, 0, rng.getTheta(), 0);
        transform.position = spawnPoint.position;
    }
}
