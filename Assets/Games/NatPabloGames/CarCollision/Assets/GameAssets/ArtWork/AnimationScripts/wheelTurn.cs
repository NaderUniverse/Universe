using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class wheelTurn : MonoBehaviour
{
    public bool carA;
    public bool carB;

    public carMotion car;

    public float timeUnit;

    private Question question;
    public GameObject scriptSource;
  
    void Start() 
    { 
        // Setting question script source from gameObject where question script is #####
        question = scriptSource.GetComponent<Question>();

        // Setting a standard time unit
        timeUnit = 0.1f;
    }

    void Update()
    {
        // Rotation of the wheels
        if (car.collisionFlag == false)
        {
            if(carA)
                transform.Rotate(0, 0, -question.u_a * timeUnit);
            else if(carB)
                transform.Rotate(0, 0, -question.u_b * timeUnit);
        }
        else
        {
            if(carA)
                transform.Rotate(0, 0, -question.v_a * timeUnit);
            else if(carB)
                transform.Rotate(0, 0, -question.v_b * timeUnit);            
        }
    }
}