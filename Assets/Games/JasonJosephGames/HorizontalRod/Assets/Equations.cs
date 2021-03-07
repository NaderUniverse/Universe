using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Equations : MonoBehaviour
{
    float alpha;
    float g = 9.81f;
    float L;
    float a_B;
    float a_C;
    float A_y;
    float mass;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void Initialize()
    {
        L = Random.Range(0.5f, 2.0f);
        mass = Random.Range(2f, 5f);
        
        alpha = 1.5f * (g / L);
        a_B = L * alpha;
        a_C = (L / 2f) * alpha;
        A_y = mass * a_C; // a = (L * alpha) / 2 according to problem
    }
}
