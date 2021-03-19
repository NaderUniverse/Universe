using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class carMotion : MonoBehaviour
{
    public bool carA;
    public bool carB;

    // Higher number, faster movement
    // oading from GameScene = 0.02
    // Loading from MainMenu =
    public float timeUnit;

    private Question question;
    public GameObject scriptSource;

    public GameObject car;

    public bool collisionFlag = false;

    // Lower number means faster translation animation
    private float translationFactor = 1.5f;
    Vector3 originalPos;



    public void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Car")
        {
            collisionFlag = true;
        }
    }

    public void changeCollisionFlag()
    {
        collisionFlag = !collisionFlag;
    }

    void setVelocities(float vel_A, float vel_B)
    {
        if(carA)
            car.transform.Translate(timeUnit * vel_A / translationFactor, 0, 0);
        else if(carB)
            car.transform.Translate(timeUnit * vel_B / translationFactor, 0, 0);
    }

    public void setMovement()
    {
      // Setting question script source from gameObject where question script is #####
      question = scriptSource.GetComponent<Question>();

      // Setting a standard time unit
      timeUnit = 0.1f;
      originalPos = car.transform.position;
      // Car translation
      if (!collisionFlag)
            setVelocities(question.u_a, question.u_b);
      else if(collisionFlag)
            setVelocities(question.v_a, question.v_b);
    }

    public void restartMovement()
    {
        changeCollisionFlag();
        car.transform.position = originalPos;
        setMovement();
    }


    void Start()
    {

        // Setting question script source from gameObject where question script is #####
        question = scriptSource.GetComponent<Question>();

        // Setting a standard time unit
        timeUnit = 0.1f;
        originalPos = car.transform.position;
    }

    void Update()
    {
        if (Question.stage > 3)
        {
          car.transform.position = originalPos;
          Debug.Log("Test");
          Start();
        }

        // Car translation
        if (!collisionFlag)
            setVelocities(question.u_a, question.u_b);
        else if(collisionFlag)
            setVelocities(question.v_a, question.v_b);
    }
}
