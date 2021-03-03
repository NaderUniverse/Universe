using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Question3Info : MonoBehaviour
{
    private float mass;
    private float ropeLength;
    private float angularVelocity;
    private float tangentialVelocity;
    private float angleWithVertical;
    private float angleWithHorizontal;
    private float centripetalForce;
    private float tension;
    private float xForce;
    private float yForce;
    private float gravity = 9.81f;

    private float massRoundStep = 0.05f;
    private float ropeRoundStep = 0.1f;

    
    // Start is called before the first frame update
    void Start()
    {
        // STILL HAVE TO FIGURE OUT THE RANGE FOR ANGULAR VELOCITY
        mass = Mathf.Round(UnityEngine.Random.Range(0.15f, 0.5f) / massRoundStep) * massRoundStep;
        ropeLength = Mathf.Round(UnityEngine.Random.Range(1f, 3f) / ropeRoundStep) * ropeRoundStep;
        angularVelocity = UnityEngine.Random.Range(0.15f, 0.5f);
        
        tangentialVelocity = ropeLength * angularVelocity;
        centripetalForce = (mass * tangentialVelocity * tangentialVelocity) / ropeLength;
        
        xForce = centripetalForce;
        yForce = mass * gravity;

        // Mathf.Tan IS IN RADIANS
        angleWithVertical = Mathf.Atan(xForce / yForce) * (180 / Mathf.PI);
        angleWithHorizontal = Mathf.Atan(yForce / xForce) * (180 / Mathf.PI);

        tension = Mathf.Sqrt((xForce * xForce) + (yForce * yForce));

        Debug.Log(" ");
        Debug.Log("Question 3");
        Debug.Log("mass: " + mass);
        Debug.Log("ropeLength: " + ropeLength);
        Debug.Log("Angular Velocity: " + angularVelocity);
        Debug.Log("x Force: " + xForce);
        Debug.Log("y Force: " + yForce);
        Debug.Log("Centripetal Force: " + centripetalForce);
        Debug.Log("Tangential Velocity: " + tangentialVelocity);
        Debug.Log("Angle With VERTICAL: " + angleWithVertical);
        Debug.Log("Angle With HORIZONTAL: " + angleWithHorizontal);
        Debug.Log("Tension: " + tension);
        Debug.Log(" ");

        /*
        // ######################### QUESTION 3.1.1 #######################
        
        // "A ball with a mass of " + mass " kg is connected to a " + ropeLength " m rope rotating around " +
        "a vertical pole at an angular velocity of " + angularVelocity + " rad/s.\n" +
        "What is the angle that the rope forms with the pole? Please enter your answer in degrees."

        ANSWER: angleWithVertical
        
        // ######################### QUESTION 3.1.2 #######################
        // CONTINUATION OF THE PREVIOUS QUESTION

        "What is the tension on the rope? Please enter your answer in Newtons."
        
        ANSWER: tension
        */

        /*
        // ######################### QUESTION 3.2.1 #######################
        // SAME AS 3.1 BUT WITH HORIZONTAL ANGLE

        "A ball of mass " + mass + "with a velocity of " + tangentialVelocity + " m/s is rotating around a pole " +
        "connected by a " ropeLength + " m long rope.\n" +
        "What is the angle that the rope makes with the horizontal? Please enter your answer in degrees."

        ANSWER: angleWithHorizontal

        // ######################### QUESTION 3.2.2 #######################
        // CONTINUATION OF THE PREVIOUS QUESTION, EXACTLY THE SAME AS 3.1.2

        "What is the tension on the rope? Please enter your answer in Newtons."
        
        ANSWER: tension
        */

        /*
        // ######################### QUESTION 3.3.1 #######################
        // ALL THE STEPS NEEDED TO SOLVE FOR ALL OF THE UNKNOWNS

        "A ball with a mass of " + mass " kg is connected to a " + ropeLength " m rope rotating around " +
        "a vertical pole at an angular velocity of " + angularVelocity + " rad/s.\n" +
        "What is the horizontal component of the tension? Please enter your answer in Newtons."

        ANSWER: xForce

        // ######################### QUESTION 3.3.2 #######################
        
        "What is the vertical component of the tension? Please enter your answer in Newtons."

        ANSWER: yForce

        // ######################### QUESTION 3.3.3 #######################
        
        "What is the tension on the rope? Please enter your answer in Newtons.

        ANSWER: tension

        // ######################### QUESTION 3.3.4 #######################

        "What is the tangential velocity of the ball? Please enter your answer in m/s"

        ANSWER: tangentialVelocity

        // ######################### QUESTION 3.3.5 #######################

        "What is the angle that the rope makes with the pole? Please enter your answer in degrees."

        ANSWER: angleWithVertical

        // ######################### QUESTION 3.3.6 #######################
        
        "What is the angle that the rope makes with the horizontal? Please enter your answer in degrees."

        ANSWER: angleWithHorizontal

        // ######################### QUESTION 3.3.7 #######################

        "What is the centripetal force acting on the ball? Please enter your answer in Newtons."

        ANSWER: centripetalForce
        */
    }
}
