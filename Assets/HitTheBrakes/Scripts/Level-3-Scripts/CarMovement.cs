using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarMovement : MonoBehaviour
{
    public float carAccel = 0;
    public float accelScale = 0.05f;
    public float rotationScale = 1000;
    public float posX;
    public float posY;
    public float carPush;

    public bool hitWall = false;

    public Transform leftWheel;
    public Transform rightWheel;
    public Rigidbody2D carRB;

    public AudioSource carSound;
    // Start is called before the first frame update
    void Start()
    {
        //starting pos for car
        transform.position = new Vector3(posX, posY, 0f);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //increase acceleration over time
        carAccel += Time.fixedDeltaTime * accelScale;

        // move the car depending on acceleration
        transform.position += new Vector3(carAccel, 0f, 0f);

        //rotate both wheels for visual effect
        leftWheel.Rotate(0, 0, -carAccel * rotationScale);
        rightWheel.Rotate(0, 0, -carAccel * rotationScale);

    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        // if red car hits the top wall 
        if((collision.gameObject.tag == "BrickWall") && !hitWall)
        {
            // attempt to stop multiple explosions
            hitWall = true;
            
            // stop the engine noise
            carSound.Stop();

            // trigger the explosion
            StartCoroutine(FindObjectOfType<CarExplosion>().Explode());

            // stop the car from moving
            enabled = false;
        }

        // if bus hits the bottom wall
        else if(collision.gameObject.tag == "BottomBrickWall")
        {
            //stop bus from moving
            enabled = false;

            // push the bus back a bit.
            carRB.AddForce(new Vector2(-carPush,150));
        }
    }
}
