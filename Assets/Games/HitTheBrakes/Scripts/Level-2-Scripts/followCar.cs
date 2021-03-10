using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class followCar : MonoBehaviour
{
    public Transform car;
    public Vector3 offset;
    public GameObject scene;
    public Vector3 defaultPosition;

    void Start()
    {
        // set default position of camera so we know where to put it back when we aren't using it
        defaultPosition = transform.position;
    }
    // Update is called once per frame
    void Update()
    {
        if (scene.activeSelf)
        {
            transform.position = car.position + offset;
        }
        else
        {
            transform.position = defaultPosition;
        }
        
    }
}
