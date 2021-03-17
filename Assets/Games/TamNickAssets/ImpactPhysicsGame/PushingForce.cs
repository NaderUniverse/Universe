using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PushingForce : MonoBehaviour
{
    public ParticleSystem Blastparticle;
    public float forceApplied = 5000.0f;

    private SpriteRenderer sr;
    public Vector2 originalPos;

    // Start is called before the first frame update
    void Start()
    {

        //sr = GetComponent<SpriteRenderer>();
        //originalPos = this.GetComponent<Rigidbody2D>().transform.position;\
        originalPos = this.transform.position;

        Debug.Log(originalPos);
        //Blastparticle.Play();
        //this.GetComponent<Rigidbody2D>().AddForce(Vector2.right * forceApplied);
    }
    public void fire()
    {
        Blastparticle.Play();
        this.GetComponent<Rigidbody2D>().AddForce(Vector2.right * forceApplied);
    }

    // Update is called once per frame
    void Update()
    {
        // if(Input.GetMouseButtonDown(0))
        // {
        //Blastparticle.Play();
        //this.GetComponent<Rigidbody2D>().AddForce(Vector2.right * forceApplied);
        // }
    }


    private void OnCollisionEnter2D(Collision2D other)
    {
        //if hit from bottom of brick
        if (other.gameObject.tag == "Target Object" || other.gameObject.tag == "Wall")
        {
            Debug.Log("Target Object Hit!");
            // Destroy(this.gameObject);

            resetPosition();
        }




    }

    public void resetPosition()
    {
        this.GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
        this.GetComponent<Rigidbody2D>().freezeRotation = true;
        this.GetComponent<Rigidbody2D>().gravityScale = 0.0f;
        this.GetComponent<Rigidbody2D>().position = originalPos;

    }
}
