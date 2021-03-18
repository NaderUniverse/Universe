using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnityLineRender : MonoBehaviour
{

     // Start is called before the first frame update
    public GameObject go1;
    public GameObject go2;
    public float linestartWidth = 0.1f;
    public float lineendWidth= 0.1f;
    LineRenderer l;
    void Start()
    {
        l = gameObject.AddComponent<LineRenderer>();

    }



    // Update is called once per frame
    void Update()
    {
        List<Vector3> pos = new List<Vector3>();
        l.material = new Material(Shader.Find("Sprites/Default"));
        l.startColor = new Color(165, 42, 42);
        l.endColor = new Color(165, 42, 42);
        pos.Add(go1.transform.position);
        pos.Add(go2.transform.position);
        l.startWidth = linestartWidth;
        l.endWidth = lineendWidth;
        l.SetPositions(pos.ToArray());
        l.useWorldSpace = true;
    }
}
