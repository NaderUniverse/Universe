using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class CarMechanics : MonoBehaviour
{
    public Rigidbody2D rigidBody;
    public Transform leftWheel;
    public Transform rightWheel;
    public Transform spawnPoint;
    public Transform slope;
    public Transform car;
    public TMP_Text velocityText;
    public AudioSource gravelSound;
    public float pitchScale = 0.001f;
    private float lateVelocity = 0;
    public void setCar()
    {
        rigidBody.velocity = new Vector2(0,0);
        Debug.Log(spawnPoint.position);
        car.position = spawnPoint.position;
        transform.rotation = slope.rotation;
        //velocityText.rectTransform.rotation = transform.rotation;
    }

    void FixedUpdate()
    {
        float x = rigidBody.velocity.x;
        float y = rigidBody.velocity.y;
        float velocity = Mathf.Sqrt(x * x + y * y);
        //float accelaration = (velocity - lateVelocity) / Time.fixedDeltaTime;
        //lateVelocity = velocity;
        //velocityText.text = "" + Math.Round(velocity, 2) + " m/s";

        //rotate left and right wheel
        leftWheel.Rotate(0, 0, -0.8f * velocity);
        rightWheel.Rotate(0, 0, -0.8f * velocity);

        // increase or decrease pitch of rolling sound depending on velocity of car. .05 was found from tweaking
        gravelSound.pitch = velocity * pitchScale;
    }
}
