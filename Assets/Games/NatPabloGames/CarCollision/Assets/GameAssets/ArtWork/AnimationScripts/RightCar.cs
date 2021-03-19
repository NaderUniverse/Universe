using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RightCar : MonoBehaviour
{

    public float moveSpeed = 5f;
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
    public static float carVBHold = 0;
    public static float carVB = 0;
    public static float carVBPrime = 0;
    public static float carMassB = 0;

    private Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        randoDist = Random.Range(20, 100);
        randoAcc = Random.Range(3, 15);
        carMassB = Random.Range(1500, 2500);
        rb = GetComponent<Rigidbody2D>();
        trueTime = Mathf.Sqrt((2 * randoDist) / randoAcc);
        simAcc = 40 / Mathf.Pow(trueTime, 2);
        distScale = randoDist / 20;
        prevXPosition = transform.position.x;
        carV = Mathf.Sqrt(2 * randoAcc * randoDist);
    }

    // Update is called once per frame
    void Update()
    {
        moreTime += Time.deltaTime;

        if (Movement2D.isGroundedCheck == true)
        {
            if(flag == 1)
            {
                carVB = carVBHold;
                carVBPrime = Movement2D.e * (Movement2D.carVA + carVB) + Movement2D.carVAPrime;
            }
            
            x = 0;
            flag = 0;
            //transform.Translate(Time.deltaTime * -2f, 0, 0);
            Debug.Log("Car Mass B: " + carMassB);
            Debug.Log("VSubB: " + carVB);
            Debug.Log("VSubB': " + carVBPrime);
            //gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(carVBPrime, 0f), ForceMode2D.Impulse);
        }
        if (flag == 0)
        {
            //x = Time.deltaTime * (carVBPrime - Movement2D.carVAPrime);

            
            if (Mathf.Abs(carVBPrime) > Mathf.Abs(Movement2D.carVAPrime))
            {
                //gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(-2f, 0f), ForceMode2D.Impulse);
                x = Time.deltaTime * (Mathf.Abs(carVBPrime) - Mathf.Abs(Movement2D.carVAPrime)) * -1;
                //flag = 2;
                //Movement2D.flag = 2;
            }
            else
            {
                //gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(2f, 0f), ForceMode2D.Impulse);
                x = Time.deltaTime * (Mathf.Abs(Movement2D.carVAPrime - Mathf.Abs(carVBPrime)));
                //flag = 2;
                //Movement2D.flag = 2;
            }
            
        }
        else
        {
            if (flag == 1)
            {
                x = Time.deltaTime * moreTime * simAcc * -1;
            }
        }

        transform.Translate(x, 0, 0);
    }

    //transform.Translate(Time.deltaTime * -2f, 0, 0);
    //rb.velocity = new Vector2(-2.0f, 0.0f);

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
            carVBHold = (2 * store) / time;
            //if((transform.position.x - prevXPosition) < 0 && )
            if (time != 0 && flag == 1)
            {
                Debug.Log("Alternate velocity of right car: " + carVBHold);
                Debug.Log("Velocity of right car: " + carV);
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

