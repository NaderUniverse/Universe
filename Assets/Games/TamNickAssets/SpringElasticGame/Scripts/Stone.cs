using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stone : MonoBehaviour
{
    public bool on;
    public Rigidbody2D rb;
    public float distance = 0;
    public float angle = 0;
    public float simAngle = 0;
    public float velocity = 0;
    public float simVelocity = 0;
    public float XV = 0;
    public float YV = 0;
    public Vector2 originalPos;

    // Start is called before the first frame update
    void Start()
    {
        gameObject.GetComponent<Rigidbody2D>().gravityScale = 0.0f;
        originalPos = gameObject.GetComponent<Rigidbody2D>().transform.position;
        on = false;
        /*
        distance = Random.Range(20f, 25f);
        angle = Random.Range(30f, 60f);
        velocity = Mathf.Sqrt((float)(distance * 9.81) / Mathf.Sin(2 * angle));
        simAngle = 0.5f * Mathf.Asin((float)((distance * 9.81) / Mathf.Pow(velocity, 2)));
        simAngle *= (180 / Mathf.PI);

        XV = velocity * Mathf.Cos(simAngle);
        YV = velocity * Mathf.Sin(simAngle);
        */
        
        // rb = GetComponent<Rigidbody2D>();

        
        //velocity = Random.Range(15f, 25f);
        //distance = Random.Range((float)(0.5 * Mathf.Pow(velocity, 2) / 9.81), (float)(Mathf.Pow(velocity, 2) / 9.81));
        //angle = 0.5f * Mathf.Asin((float)((distance * 9.81) / Mathf.Pow(velocity, 2)));
        //simVelocity = Mathf.Sqrt((float)(16 * 9.81 / Mathf.Sin(2 * angle)));
        //angle *= (Mathf.PI / 180);

        //XV = simVelocity * Mathf.Cos(angle);
        //YV = simVelocity * Mathf.Sin(angle);
        XV = 8;
        YV = 9;

        //Debug.Log("XV: " + XV);
        //Debug.Log("YV: " + YV);
        //Debug.Log("Angle: " + angle);
        //Debug.Log("Distance: " + distance);
        //Debug.Log("Velocity: " + velocity);
        //Debug.Log("simVelocity: " + simVelocity);

    }
    public void turnOn()
    {
        on = true;
    }
    public void resetPosition()
    {
        on = false;
        gameObject.GetComponent<Rigidbody2D>().gravityScale = 0.0f;
        gameObject.GetComponent<Rigidbody2D>().position = originalPos;

        // set its position here
    }
    // Update is called once per frame
    void Update()
    {
        
        if(on)
        {
            // transform.Translate(1f, 1f, 0);
            // rb.AddForce(0.02f, 0.02f, 0, ForceMode2D.Impulse);
            //gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(13.96f, 5.62f), ForceMode2D.Impulse);
            gameObject.GetComponent<Rigidbody2D>().gravityScale = 1.0f;
            gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(XV, YV), ForceMode2D.Impulse);
            // rb.AddForce(0.02f, 0.02f, 0, ForceMode2D.Impulse);
            on = false;
        }

    }
}
