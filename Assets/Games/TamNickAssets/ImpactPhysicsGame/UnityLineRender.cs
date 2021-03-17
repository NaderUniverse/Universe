using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UnityLineRender : MonoBehaviour
{
     //SpringInfo.text = "Score: " +  Convert.ToString(score) + "/1"
     // Start is called before the first frame update
    public GameObject go1;
    public GameObject go2;
    public float linestartWidth = 0.1f;
    public float lineendWidth= 0.1f;
    public float extendLenA;
    public float  extendLenB;
    public float originalLen;
    public StageMover SM;
    LineRenderer l;

    public TextMeshProUGUI SpringInfo;
    void Start()
    {
        l = gameObject.AddComponent<LineRenderer>();

    }



    // Update is called once per frame
    void Update()
    {
        /*extendLenA = SM.extendedLengthPointA;
        extendLenB = SM.extendedLengthPointB;
        originalLen = SM.originalLength;
        */
        List<Vector3> pos = new List<Vector3>();
        l.material = new Material(Shader.Find("Sprites/Default"));
        l.startColor = Color.gray;
        l.endColor = Color.gray;
        pos.Add(go1.transform.position);
        pos.Add(go2.transform.position);
        l.startWidth = linestartWidth;
        l.endWidth = lineendWidth;
        l.SetPositions(pos.ToArray());
        l.useWorldSpace = true;
       // SpringInfo.text = "Length: " +originalLen.ToString()+"m";
         //Debug.Log("Original Length ="+originalLen );

        //float length = (go1.transform.position - go2.transform.position).magnitude;
      // length = Mathf.Round(length* 100.0f) * 0.01f;
      /* if(extendLen< 0.5)
       {
         length = (float) (length - 40.00);  
       }
       else if(extendLen >= 0.5)
       {
          length = (float) (length - 50.00);  
       }
        //length = (float) (length - 40.00);
        length = Mathf.Round(length* 100.0f) * 0.01f;
        */
        //SpringInfo.text = "Length: " +  length.ToString()+"m";

    }

   private void OnCollisionEnter2D(Collision2D other)
    {
        
        //if hit from bottom of brick
       /* if(other.gameObject.tag == "Point A")
        {
          SpringInfo.text = "Length: " +extendLenA.ToString()+"m" + "\nOriginal: " +originalLen.ToString()+"m";
          
          Debug.Log("Point A collided, spring length ="+extendLenA );
        }

        else if(other.gameObject.tag == "Point B")
        {
          SpringInfo.text = "Length: " +extendLenB.ToString()+"m" +"\nOriginal: " +originalLen.ToString()+"m";
          
           Debug.Log("Point B collided, extended spring length= "+extendLenB);
        }

        */
    }
}
