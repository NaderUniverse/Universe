using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Orbit : MonoBehaviour
{
    public float a;
    public float b;
    private float c;
    public float G;
    public float M;
    public Transform focus1;

    public float alpha;
    private float deltaAlpha;
    private float r;

    private Vector3 difference;
    private Vector3 center;
    private Vector3 Distance;

    public float counter;
    public float rounding = 1e4f;
    private int dooter;

    public int frameCounter;
    public float f1YPosition;
    public float f2YPosition;
    public float productOfFramePosition;


    void Update()
    {
        frameCounter++;
        center = new Vector3(focus1.position.x + c, focus1.position.y, focus1.position.z);
        r = Vector3.Distance(focus1.position, transform.position);

        f1YPosition = transform.position.y;
        transform.position = new Vector3(center.x + a * Mathf.Cos(alpha), center.y + b * Mathf.Sin(alpha), focus1.position.z);
        f2YPosition = transform.position.y;

        productOfFramePosition = f1YPosition * f2YPosition;


        // ################### LONG ANIMATION ###################//
        // if (productOfFramePosition <= 0 && frameCounter > 10)
        // {
        //     counter++;
        //     Debug.Log("productOfFramePosition < 0:\t" + productOfFramePosition);
        //     // Go from small circular orbit to elliptical orbit
        //     if (counter%16 == 3)
        //     {
        //         Debug.Log("Entering elliptical Orbit");
        //         a = 300;
        //         b = 200;
        //     }
        //     // From elliptical orbit to big circular orbit
        //     else if (counter%16 == 6)
        //     {
        //         Debug.Log("Entering Large Circular Orbit");
        //         a = 523;
        //         b = a;
        //     }
        //     // From big circular orbit to elliptical orbit
        //     else if (counter%16 == 12)
        //     {
        //         Debug.Log("Entering Elliptical Orbit");
        //         a = 300;
        //         b = 200;
        //     }
        //     // From elliptical to small circular orbit
        //     else if (counter%16 == 15)
        //     {
        //         Debug.Log("Entering Small Circular Orbit");
        //         a = 76;
        //         b = 76;
        //     }
        //     else if (counter%16 == 0)
        //         counter = 0;

        //     Debug.Log("Counter: " + counter);
        // }


        // ################### MEETING DEMONSTRATION ###################//
        if (productOfFramePosition <= 0 && frameCounter > 10)
        {
            counter++;

            // Go from small circular orbit to elliptical orbit
            if (counter%6 == 1)
            {
                Debug.Log("Entering elliptical Orbit");
                a = 300;
                b = 200;
            }
            // From elliptical orbit to big circular orbit
            else if (counter%6 == 2)
            {
                Debug.Log("Entering Large Circular Orbit");
                a = 523;
                b = a;
            }
            // From big circular orbit to elliptical orbit
            else if (counter%6 == 4)
            {
                Debug.Log("Entering Elliptical Orbit");
                a = 300;
                b = 200;
            }
            // From elliptical to small circular orbit
            else if (counter%6 == 5)
            {
                Debug.Log("Entering Small Circular Orbit");
                a = 76;
                b = 76;
            }
            else if (counter%6 == 0)
            {
                counter = 0;
            }

            // Debug.Log("Counter: " + counter);
        }

        c = Mathf.Sqrt(Mathf.Abs(a * a - b * b));
        deltaAlpha = (Mathf.Sqrt(Mathf.Abs(2 * G * M * (1/r - 1/(2 * a))) * 100 * Time.deltaTime) / Mathf.PI * Mathf.Sqrt((a*a + b*b)/2));
        alpha -= deltaAlpha;

        transform.Rotate(0.0f, 0.0f, deltaAlpha * 180 / Mathf.PI);
    }
}
