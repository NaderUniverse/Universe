using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomNumberGeneratorLevel3 : MonoBehaviour
{
    private float distance;
    private float acceleration;

    public void Generate()
    {
        distance = Random.Range(20.0f, 100.0f);
        acceleration = Random.Range(3.0f, 15.0f);
    }

    public float getDistance()
    {
        return distance;
    }

    public float getAcceleration()
    {
        return acceleration;
    } 
}
