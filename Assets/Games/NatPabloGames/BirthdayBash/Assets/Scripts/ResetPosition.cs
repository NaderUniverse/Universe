using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetPosition : MonoBehaviour
{
    public GameObject GO;
     Vector3 originalPos;
       public float forceApplied = 5000.0f;
    // Start is called before the first frame update
    void Start()
    {
      originalPos = GO.transform.position;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void resetPos()
    {
         GO.transform.position = originalPos;
          GO.GetComponent<Rigidbody2D>().velocity = Vector3.zero;
          Debug.Log(originalPos);
    }

    public void ApplyForce()
      {
        //GO.GetComponent<Rigidbody2D>().AddForce(Vector2.right * forceApplied);
          GO.transform.position = originalPos;
            GO.GetComponent<Rigidbody2D>().velocity = originalPos;
            Debug.Log(originalPos);
      }
}
