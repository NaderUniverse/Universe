using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PushBack : MonoBehaviour
{
   public float pushForce = 10;
    public Rigidbody2D rb;
 
    // Use this for initialization
    void Start() {
        rb = GetComponent<Rigidbody2D>();
    }
 
    // Update is called once per frame
    void Update() {
 
    }
 
    void OnCollisionEnter2D(Collision2D other) {
        if(other.gameObject.tag == "Target Objects") {
            Debug.Log("pushLeft");
            rb.AddForce(Vector2.left * pushForce, ForceMode2D.Impulse);
        }
        else if(other.gameObject.tag == "Target Object") {
            Debug.Log("pushRight");
            rb.AddForce(Vector2.right * pushForce, ForceMode2D.Impulse);
        }
    }
}
