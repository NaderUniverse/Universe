using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement2D : MonoBehaviour
{
    public Rigidbody rb;
    public float moveSpeed = 5f;
    public bool isGrounded = false;
    public static bool isGroundedCheck = false;
    public bool isRightPressed = false;
    public float time = 0.0f;
    public float moreTime = 0.0f;
    public float prevXPosition = 0;
    public float x = 0;
    public static int flag = 1;
    public float randoDist = 100;
    public float trueTime = 0;
    public float randoAcc = 8;
    public float simAcc = 0;
    public float distScale = 0;
    public static float carV = 0;
    public static float carVAHold = 0;
    public static float carVA = 0;
    public static float carVAPrime = 0;
    public static float carMassA = 0;
    public static float e = 0;

    // Start is called before the first frame update
    void Start()
    {
        randoDist = Random.Range(20, 100);
        randoAcc = Random.Range(3, 15);
        e = Random.Range(0.1f, 0.9f);
        carMassA = Random.Range(1500, 2500);
        Debug.Log("Randomized distance: " + randoDist);
        Debug.Log("Randomized acceleration: " + randoAcc);
        //gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(5f, 0f), ForceMode2D.Impulse);
        trueTime = Mathf.Sqrt((2 * randoDist) / randoAcc);
        simAcc = 40 / Mathf.Pow(trueTime, 2);
        distScale = randoDist / 20;
        prevXPosition = transform.position.x;
        rb = GetComponent<Rigidbody>();
        carV = Mathf.Sqrt(2 * randoAcc * randoDist);
    }

    // Update is called once per frame
    void Update()
    {
        //Jump();
        //Vector3 movement = new Vector3(Input.GetAxis("Horizontal"), 0f, 0f);
        //transform.position += movement * Time.deltaTime * moveSpeed;
        //gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(0.5f, 0f), ForceMode2D.Impulse);
        //isRightPressed = (Input.GetKey("right") ? true : false);
        //Debug.Log(transform.position.x);
        //Debug.Log(prevXPosition);
        moreTime += Time.deltaTime;

        if (isGrounded == true)
        {
            if(flag == 1)
            {
                carVA = carVAHold;
                carVAPrime = (((carVA * carMassA) + (RightCar.carVB * RightCar.carMassB)) / (carMassA + (RightCar.carMassB * ((e * carVA) + (e * RightCar.carVB) + 1))));
            }
            carVA = carVAHold;
            isGroundedCheck = true;
            x = 0;
            flag = 0;
            Debug.Log("Car Mass A: " + carMassA);
            Debug.Log("VSubA: " + carVA);
            Debug.Log("VSubA': " + carVAPrime);
            Debug.Log("e: " + e);
            
        }
        if (flag == 0)
        {
            //x = Time.deltaTime * (RightCar.carVBPrime - carVAPrime);
            
            if(Mathf.Abs(RightCar.carVBPrime) > Mathf.Abs(carVAPrime))
            {
                //gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(-2f, 0f), ForceMode2D.Impulse);
                x = Time.deltaTime * (Mathf.Abs(RightCar.carVBPrime) - Mathf.Abs(carVAPrime)) * -1;
                //flag = 2;
                //RightCar.flag = 2;
            }
            else
            {
                //gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(2f, 0f), ForceMode2D.Impulse);
                x = Time.deltaTime * (Mathf.Abs(carVAPrime) - Mathf.Abs(RightCar.carVBPrime));
                //flag = 2;
                //RightCar.flag = 2;
            }
            
        }
        else
        {
            if (flag == 1)
            {
                x = Time.deltaTime * moreTime * simAcc;
            }
        }

        transform.Translate(x, 0, 0);
    }

    void Jump()
    {
        if(Input.GetButtonDown("Jump") && isGrounded == true)
        {
            //gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(0f, 5f), ForceMode2D.Impulse);
        }
    }

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
            carVAHold = (2 * store) / time;
            //if((transform.position.x - prevXPosition) < 0 && )
            if (time != 0 && flag == 1)
            { 
                Debug.Log("Alternate velocity of car: " + carVAHold);
                Debug.Log("Velocity of car: " + carV);
                /*
                Debug.Log("Velocity: " + ((2 * store) / time));
                Debug.Log("Time: " + time);
                Debug.Log("Actual acceleration: " + randoAcc);
                Debug.Log("Simulated acceleration: " + simAcc);
                //Debug.Log(rb.velocity);
                */
            }
        }
        //prevXPosition = transform.position.x;
    }
}
