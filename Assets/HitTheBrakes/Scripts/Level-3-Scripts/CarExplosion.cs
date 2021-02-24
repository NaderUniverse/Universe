using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class CarExplosion : MonoBehaviour
{
    public GameObject car;
    public GameObject[] carParts;
    public GameObject explosion;
    public float maxX = 1000;
    public float maxY;
    
    public IEnumerator Explode() {

        GameObject g = Instantiate(explosion);
        g.transform.position = GameObject.FindWithTag("ExplosionSpawn").transform.position;

        // loop through all components
        foreach (GameObject part in carParts)
        {
            // add a rigidbody to each component
            part.AddComponent<Rigidbody2D>();
            // add force to the car components to act as the car exploding apart.
            part.GetComponent<Rigidbody2D>().AddForce(new Vector2(Random.Range(-maxX, 0), Random.Range(1, maxY)));
        }

        // wait 3.5 seconds for animation
        yield return new WaitForSeconds(6f);

        // loop odd number of times to play animation
        for (int i = 0; i < 11; i++) {
            // if off number
            if (i % 2 == 1) {
                // for each part in car
                foreach (GameObject part in carParts) {
                    // make car disapeer for 0.2 seconds
                    part.GetComponent<Renderer>().enabled = false;
                }
            }
            else {
                // for each part make car come back for 0.2 seconds
                foreach (GameObject part in carParts) {
                    part.GetComponent<Renderer>().enabled = true;
                }
            }

            // wait 0.2 seconds
            yield return new WaitForSeconds(0.2f);
        }

        // destroy the object entirely
        Destroy(car);

        GameObject[] explosions = GameObject.FindGameObjectsWithTag("explosion");

        foreach(var explosion in explosions)
        {
            Destroy(explosion);
        }

    }

}


