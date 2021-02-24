using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarMovementLV4 : MonoBehaviour
{
   public float carVelocity = 0;
    public float accelScale = 0.05f;
    public float rotationScale = 1000;
    public float carOffset = 57.1256f;
    public float posX;
    public float posY;
    public float carPush;

    public bool hitWall = false;

    public Transform leftWheel;
    public Transform rightWheel;
    public Transform endPoint;
    public Rigidbody2D carRB;

    public AudioSource carSound;
    public RandomNumberGeneratorLV4 rng;
    public AudioSource hitSound;
    // Start is called before the first frame update
    void Start()
    {
        RandomNumberGeneratorLV4 carRNG = GameObject.FindWithTag("RNG").GetComponent<RandomNumberGeneratorLV4>();
        Transform carEndPoint = GameObject.FindWithTag("endpoint").GetComponent<Transform>();
        if (tag == "car")
        {
            // THIS IS BAD FIND A BETTER SOLUTION
            transform.position = new Vector3(carEndPoint.position.x - carOffset - (carRNG.randomCarDistance), posY, 0f);
            accelScale = carRNG.randomCarAccel * 0.02f;
        }
        
        else if(tag == "Bus")
        {
            transform.position = new Vector3(carEndPoint.position.x - carRNG.randomVanDistance, posY, 0f);
            accelScale = carRNG.randomVanAccel * 0.02f;
        }
    }

    // Update is called once per frame [50 times per second]
    void FixedUpdate()
    {
        carVelocity += accelScale;
        transform.position += new Vector3(carVelocity, 0f, 0f);
        leftWheel.Rotate(0, 0, -carVelocity * rotationScale);
        rightWheel.Rotate(0, 0, -carVelocity * rotationScale);

    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if((collision.gameObject.tag == "BrickWall") && !hitWall)
        {
            hitWall = true;
            carSound.Stop();
            StartCoroutine(FindObjectOfType<CarExplosion>().Explode());
            enabled = false;
        }
        else if(collision.gameObject.tag == "BottomBrickWall")
        {
            Debug.Log("TEST");
            carSound.Stop();
            enabled = false;
            carRB.AddForce(new Vector2(-carPush,150));
            hitSound.Play();
        }
    }
}
