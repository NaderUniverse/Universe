using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallRotation : MonoBehaviour
{
    Vector3 center = new Vector3(0, 0, 0);
    public float randoRopeLength = 0;
    public float randoAngle = 0;
    public float randoMass = 0;
    public float g = 9.81f;
    public float tension = 0;
    public float normalAcc = 0;
    public float velocity = 0;
    public float time = 0;
    public float simVelocity = 0;
    public static float simAngle = 0;
    public float timeActual = 0;

    // Start is called before the first frame update
    void Start()
    {
        randoAngle = Random.Range(15, 35);
        randoMass = Random.Range(0.1f, 0.3f);
        randoRopeLength = Random.Range(1, 3);

        tension = (randoMass * g) / Mathf.Cos(randoAngle * (Mathf.PI / 180));
        velocity = Mathf.Sqrt((tension * randoRopeLength * Mathf.Pow(Mathf.Sin(randoAngle * (Mathf.PI / 180)), 2)) / randoMass);
        normalAcc = (randoMass * Mathf.Pow(velocity, 2)) / (randoRopeLength * Mathf.Sin(randoAngle * (Mathf.PI / 180)));

        time = (randoRopeLength * 1) / velocity;
        simVelocity = (4 * randoAngle) / time;
        simAngle = (simVelocity * time);
        simAngle = (velocity / randoRopeLength) * (180 / Mathf.PI);

        // Debug.Log("Angle: " + randoAngle);
        // Debug.Log("Mass: " + randoMass);
        // Debug.Log("Rope Length: " + randoRopeLength);

        // Debug.Log("Tension: " + tension);
        // Debug.Log("Velocity: " + velocity);
        // Debug.Log("Normal Acceleration: " + normalAcc);


    }

    // Update is called once per frame
    void Update()
    {
        transform.RotateAround(center, Vector3.back, ((velocity / randoRopeLength) * (180 / Mathf.PI)) * Time.deltaTime);
        timeActual += Time.deltaTime;
        // Debug.Log(timeActual);
    }
}
