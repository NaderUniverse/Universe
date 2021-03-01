using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwingMovement : MonoBehaviour
{
    public Vector3 pivot;
    public Vector3 Rotation;

    public float loopTime;
    public float seconds;
    private float factor = 11.25f;

    void Start() 
    {
        pivot = GameObject.Find("Pivot").transform.position;    
        seconds = Time.fixedDeltaTime;
    }


    void Update()
    {
        loopTime += seconds;

        if (loopTime <= 4f)
        {
            transform.RotateAround(pivot, Vector3.forward, factor * seconds);
        }
        else if(loopTime <= 12f)
        {
            transform.RotateAround(pivot, Vector3.back, factor * seconds);
        }
        else if(loopTime <= 16f)
        {
            transform.RotateAround(pivot, Vector3.forward, factor * seconds);
        }
        else
        {
            loopTime = 0;
        }
    }
}
