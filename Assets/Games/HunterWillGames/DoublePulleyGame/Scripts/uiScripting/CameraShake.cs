using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShake : MonoBehaviour
{

    public Camera mainCamera;

    float shakeAmount = 0;
    public Vector3 cameraPOS;
    private void Awake()
    {
        if(mainCamera == null)
        {
            mainCamera = Camera.main;
        }
       
    }
    public void Shake(float amt, float length)
    {
        shakeAmount = amt;
        InvokeRepeating("BeginShake", 0 , 0.01f);
        Invoke("StopShake", length);

    }
    void BeginShake()
    {
        cameraPOS = mainCamera.transform.position;

        if(shakeAmount > 0)
        {
            //gets camera pos before the shake
            Vector3 camPos = mainCamera.transform.position;


            float OffsetamtX = Random.value * shakeAmount * 2 - shakeAmount;
            float OffsetamtY = Random.value * shakeAmount * 2 - shakeAmount;

            camPos.x += OffsetamtX;
            camPos.y += OffsetamtY;

            mainCamera.transform.position = camPos;

        }
    }
    void StopShake()
    {
        CancelInvoke("BeginShake");
        mainCamera.transform.localPosition = cameraPOS;
    }
}
