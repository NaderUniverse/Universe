using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coconut : MonoBehaviour
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
        on = false;
        gameObject.GetComponent<Rigidbody2D>().gravityScale = 0.0f;
        originalPos = gameObject.GetComponent<Rigidbody2D>().transform.position;

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
        
        if( gameObject.GetComponent<Rigidbody2D>().velocity != Vector2.zero)
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
