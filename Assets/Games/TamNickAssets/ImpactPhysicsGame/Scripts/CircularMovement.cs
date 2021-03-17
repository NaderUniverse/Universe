using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CircularMovement : MonoBehaviour
{
   /* [SerializeField]
    Transform rotationCenter;

    [SerializeField]
    float rotationRadius = 2f, angularspeed = 2f, resetAngle = 360f;
    float posX, posY, angle = 0f;
    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
       posX = rotationCenter.position.x + Mathf.Cos(angle) * rotationRadius;
       posY = rotationCenter.position.x + Mathf.Sin(angle) * rotationRadius;
       transform.position = new Vector2 (posX, posY);
       angle = angle + Time.deltaTime * angularspeed;

       if(angle >= resetAngle)
        {
            angle= -angle;
            posX = rotationCenter.position.x - Mathf.Cos(angle) * rotationRadius;
            posY = rotationCenter.position.x - Mathf.Sin(angle) * rotationRadius;
            transform.position = new Vector2 (posX, posY);
        }
    }
    */

 


	/*float timer = 0f;
    float speed = 1f;
    int phase = 0;

    void FixedUpdate()
    {
        timer += Time.fixedDeltaTime;
        if(timer>1f)
        {
            phase ++;
            phase %=4;
            timer =0f;
        }

        switch(phase)
        {

            case 0:
                transform.Rotate(0f,0f, speed * (1-timer));
                break;
            case 1:
                transform.Rotate(0f,0f,  -speed * timer);
                break;
            case 2:
                transform.Rotate(0f, 0f, -speed * (1-timer));
                break;
            case 3:
                transform.Rotate(0f, 0f, speed * timer);
                break;
        }

    }

*/

Rigidbody2D rb2d;

    public float moveSpeed;
    public float leftAngle;
    public float rightAngle;

    bool movingClockwise;
    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        movingClockwise = true;
    }

    // Update is called once per frame
    void Update()
    {

        Move();
    }

    public void ChangeMoveDir()
    {
        if (transform.rotation.z > rightAngle)
        {
            movingClockwise = false;
        }
        if (transform.rotation.z < leftAngle)
        {
            movingClockwise = true;
        }

    }

    public void Move()
    {
        ChangeMoveDir();

        if (movingClockwise)
        {
            rb2d.angularVelocity = moveSpeed;
        }

        if (!movingClockwise)
        {
            rb2d.angularVelocity = -1*moveSpeed;
        }
    }

    

}
