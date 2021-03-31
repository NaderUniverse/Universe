using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VinePhysics : MonoBehaviour
{
    public Transform Center;
    public GameObject leftVine;
    public GameObject rightVine;
    public float speed;
    public HingeJoint2D leftMonkey;
    public HingeJoint2D rightMonkey;
    public bool canSpin;
    private Vector3 zAxis = new Vector3(0, 0, 1);

    // Start is called before the first frame update
    void Start()
    {
        canSpin = true;
    }

    // Update is called once per frame
    void Update()
    {
        /*
        if (canSpin)
        {
            //Debug.Log("Spinning commence!");
            transform.RotateAround(leftVine.transform.Position, Vector3.up, 20*Time.deltaTime);
        }
        */
        
    }
}
