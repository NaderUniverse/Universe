using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomNumberGenerator : MonoBehaviour
{
    private float mu;
    private float distance;
    private float theta;

    public void Generate()
    {
        mu = Random.Range(0.2f, 0.5f);
        distance = Random.Range(20.0f, 50.0f);
        theta = Random.Range(30.0f, 45.0f);
    }

    public float getMU()
    {
        return mu;
    }

    public float getDistance()
    {
        return distance;
    }

    public float getTheta()
    {
        return theta;
    }

}
