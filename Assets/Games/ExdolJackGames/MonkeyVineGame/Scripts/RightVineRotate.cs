using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RightVineRotate : MonoBehaviour
{
   public GameObject target;
    public float speed;
    public SpriteRenderer monkey;
    public SpriteRenderer hangingMonkey;
    private Vector3 zAxis = new Vector3(0, 0, 1);
    private bool canSpin;
    public SpriteRenderer thisVine;
    
    // Start is called before the first frame update
    void Start()
    {
        canSpin = true;
    }
    
    // Update is called once per frame
    void Update()
    {
        if (canSpin)
        {
            transform.RotateAround(target.transform.position, zAxis, speed);
            Debug.Log(transform.rotation.z);
            if (transform.rotation.z < -0.3)
            {
                speed = -1*speed;
                monkey.enabled = false;
                hangingMonkey.enabled = true;
            }
            else if(transform.rotation.z > 0.25 && hangingMonkey.enabled == true)
            {
                canSpin = false;
                thisVine.enabled = false;
            }

        }
        
        
    }
}
