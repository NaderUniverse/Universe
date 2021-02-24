using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class followCar : MonoBehaviour
{
    public Transform car;
    public Vector3 offset;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = car.position + offset;
    }
}
