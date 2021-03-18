using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreakableBox : MonoBehaviour
{
    private ParticleSystem particle;
    
    private SpriteRenderer sr;

    private BoxCollider2D bc;

    private void Awake()
    {
        particle = GetComponentInChildren<ParticleSystem>();
        sr = GetComponent<SpriteRenderer>();
        bc = GetComponent<BoxCollider2D>();
    }
    private void OnCollisionEnter2D(Collision2D other)
    {
        //if hit from bottom of brick
        if(other.collider.gameObject.GetComponent<Character2DController>() && other.contacts[0].normal.y >0.5f)
        {
          
          StartCoroutine(Break());
        }
        
    }

  

    private IEnumerator Break()
    {
        particle.Play();

        sr.enabled = false;
        bc.enabled = false;
        yield return new WaitForSeconds(particle.main.startLifetime.constantMax);
        Destroy(gameObject);
        //gameObject.SetActive = false;
    }
}
