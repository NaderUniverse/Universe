using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrbitSatellite : MonoBehaviour
{
    Vector3 earth = new Vector3(0, 0, 0);
    public float Speed = 0f;
    
    void Update()
    {
        transform.RotateAround(earth, Vector3.back, (float)(Speed * Time.deltaTime));
    }
}
