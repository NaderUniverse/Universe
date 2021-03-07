using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SMGear : MonoBehaviour
{
    public static float randoAV;

    // Start is called before the first frame update
    void Start()
    {
        randoAV = ((float)SmallGear.randoAV / 2) * -1;
    }

    // Update is called once per frame
    void Update()
    {
        // randoAV = ((float)SmallGear.randoAV / 2) * -1;
        transform.Rotate(0f, 0f, (float)randoAV * Time.deltaTime, Space.Self);
       // Debug.Log(randoAV);
    }
}
