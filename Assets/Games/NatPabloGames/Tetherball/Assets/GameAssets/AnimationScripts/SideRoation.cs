using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SideRoation : MonoBehaviour
{
    private Vector3 pole;

    void Start()
    {
        pole = GameObject.Find("Pole").transform.position;
    }

    void Update()
    {
       transform.RotateAround(pole, Vector3.up, 180 * Time.deltaTime);
    }
}
