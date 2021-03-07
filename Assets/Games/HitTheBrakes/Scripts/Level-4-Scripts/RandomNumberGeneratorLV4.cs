using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using Random = UnityEngine.Random;


public class RandomNumberGeneratorLV4 : MonoBehaviour
{
    public float randomCarDistance;
    public float randomCarAccel;
    public float randomVanDistance;
    public float randomVanAccel;

    public void Generate()
    {
        randomCarDistance = (float)Math.Round(Random.Range(20.0f, 40.0f), 2);
        randomVanDistance = (float)Math.Round(Random.Range(20.0f, 40.0f), 2);

        randomCarAccel = (float)Math.Round(Random.Range(0.2f, 0.5f), 2);
        randomVanAccel = (float)Math.Round(Random.Range(0.2f, 0.5f), 2);
    }

}
