using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cannonball : MonoBehaviour
{
    public bool on;
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

        XV = 10;
        YV = 3;
    }
    public void turnOn()
    {
        on = true;
    }
    public void resetPosition()
    {
        gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
        gameObject.GetComponent<Rigidbody2D>().freezeRotation = true;
        gameObject.GetComponent<Rigidbody2D>().gravityScale = 0.0f;
        gameObject.GetComponent<Rigidbody2D>().position = originalPos;
    }
    // Update is called once per frame
    void Update()
    {
           
        if(on)
        {
            gameObject.GetComponent<Rigidbody2D>().freezeRotation = false;
            gameObject.GetComponent<Rigidbody2D>().gravityScale = 5.0f;
            gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(XV, YV), ForceMode2D.Impulse);
            on = false;
        }

    }

     void OnCollisionEnter2D(Collision2D coll) {
         if (coll.gameObject.tag == "cannon") //Change tag
             Destroy(coll.gameObject);
     }
}
