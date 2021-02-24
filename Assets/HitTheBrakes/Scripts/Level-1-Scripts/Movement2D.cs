using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement2D : MonoBehaviour
{
    public Rigidbody rb;
    public float moveSpeed = 5f;
    public bool isGrounded = false;
    public bool isRightPressed = false;
    public float time = 0.0f;
    public float moreTime = 0.0f;
    public float prevXPosition = 0;
    public float x = 0;
    public int flag = 1;
    public float randoDist = 100;
    public float trueTime = 0;
    public float randoAcc = 8;
    public float simAcc = 0;
    public float distScale = 0;
    public float randoV = 0;
    public float calculatedV = 0;
    private float halfTime = 0;
    public float randoForce = 0;
    public float randoMass = 0;
    public float randoTime = 0;
    private float breakTime = 0;
    public float decel = 0;
    public float force = 0;
    private float max = -1;

    // Start is called before the first frame update
    public void Start()
    {
        transform.position = new Vector3(-10.19f, -0.49f, -0.01f);
        randoDist = Random.Range(20, 100);
        randoAcc = Random.Range(3, 15);
        randoV = Random.Range(25, 35);
        randoForce = Random.Range(8000, 12000);
        randoMass = Random.Range(1000, 2000);
        //randoTime = Random.Range(1, 5);
        x = 00000000000000000000000000000000000.1f;
       
        //Debug.Log("Randomized acceleration: " + randoAcc);

        //gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(5f, 0f), ForceMode2D.Impulse);
        //force = (randoMass * randoV) / randoTime;
        calculatedV = (randoV * 1000) / 3600;
        halfTime = 1 / (calculatedV / 40);
        trueTime = Mathf.Sqrt((2 * randoDist) / randoAcc);
        time = (randoMass * calculatedV) / randoForce;
        simAcc = 40 / Mathf.Pow(trueTime, 2);
        distScale = randoDist / 20;
        prevXPosition = transform.position.x;
        rb = GetComponent<Rigidbody>();
        decel = calculatedV / time;

        //Debug.Log("Half Time: " + halfTime);
        //Debug.Log("Deceleration: " + decel);
        //Debug.Log("Time: " + time);
    }

    // Update is called once per frame
    public void Update()
    {
        //Jump();
        //Vector3 movement = new Vector3(Input.GetAxis("Horizontal"), 0f, 0f);
        //transform.position += movement * Time.deltaTime * moveSpeed;
        //gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(0.5f, 0f), ForceMode2D.Impulse);
        //isRightPressed = (Input.GetKey("right") ? true : false);
        //Debug.Log(transform.position.x);
        //Debug.Log(prevXPosition);
        moreTime += Time.deltaTime;

        /*
        if (isGrounded == true)
        {
            x = 0;
            flag = 0;
            //gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(-1f, 0f), ForceMode2D.Impulse);
        }
        */
        
        if(moreTime > 0.5)
        {
            if(x >= 0)
            {
                breakTime += Time.deltaTime;
                x = (Time.deltaTime * calculatedV) - (Time.deltaTime * breakTime * (calculatedV / time));
                //x = 0;
            }
        }
        else
        {
            if (flag == 1)
            {
                x = calculatedV * Time.deltaTime;
            }
        }

        if (x > max)
        {
            //Debug.Log("Accelerating");
            max = x;
        }
        else
        {
            //Debug.Log("Deaccelerating");
        }

        if (x <= 0)
        {
            x = 0;
            //enabled = false;
        }
        //Debug.Log("x: " + x);
        transform.Translate(-x, 0, 0);
        // Debug.Log("Time: " + time);
    }

    void Jump()
    {
        if(Input.GetButtonDown("Jump") && isGrounded == true)
        {
            gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(0f, 5f), ForceMode2D.Impulse);
        }
    }

    /*
    private void FixedUpdate()
    {
        float store;
        //Debug.Log(prevXPosition);
        //Debug.Log(transform.position.x);
        //Debug.Log("Velocity?: " + (x * time));
        //Debug.Log("x: " + x);
        if (true)
        {
            time = time + Time.fixedDeltaTime;
            
            if (prevXPosition == transform.position.x)
            {
                // Debug.Log(transform.position.x + " : " + time);
                time = 0.0f;
                prevXPosition = transform.position.x;

            }
            store = (transform.position.x - prevXPosition) * distScale;
            //if((transform.position.x - prevXPosition) < 0 && )
            if (time != 0 && flag == 1)
            {
                Debug.Log("Velocity: " + ((2 * store) / time));
                Debug.Log("Time: " + time);
                Debug.Log("Actual acceleration: " + randoAcc);
                Debug.Log("Simulated acceleration: " + simAcc);
                //Debug.Log(rb.velocity);
            }
        }
        //prevXPosition = transform.position.x;
    }
    */
}
