using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Satellite : MonoBehaviour
{
    Vector3 earth = new Vector3(0f, 7f, 0f);

    // Start is called before the first frame update
    void Start()
    {
        // transform.RotateAround(earth, Vector3.up, (float)(30 * Time.deltaTime));
    }

    // Update is called once per frame
    void Update()
    {
        transform.RotateAround(earth, Vector3.back, (float)(60 * Time.deltaTime));

    }
}
