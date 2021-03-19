using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TamNickBreakableBox : MonoBehaviour
{
    private ParticleSystem particle;

    private ParticleSystem particle1;
    private ParticleSystem particle2;
    private SpriteRenderer sr;

    private CapsuleCollider2D cc;
    public GameObject CBall;

    

    private void Awake()
    {
        particle = GameObject.Find("EtherealHit 2").GetComponent<ParticleSystem>();
        //particle = GameObject.Find("CFX3_Fire_Explosion").GetComponent<ParticleSystem>();
        particle1 = GameObject.Find("MuzzleFlash").GetComponent<ParticleSystem>();
        particle2 = GameObject.Find("MuzzleFlash1").GetComponent<ParticleSystem>();
        sr = GetComponent<SpriteRenderer>();
        cc = GetComponent<CapsuleCollider2D>();
    }
    private void OnCollisionEnter2D(Collision2D other)
    {
        //if hit from bottom of brick
        if(other.collider.gameObject.GetComponent<Cannonball>())
        {
          //Destroy(other.collider.gameObject); 
          other.collider.gameObject.SetActive(false);   
          StartCoroutine(Break());
        }

        
    }

    public void ResetTarget()
    {  //other.collider.gameObject.SetActive(true);
        CBall.SetActive(true); 
       gameObject.SetActive(true);
        sr.enabled = true;
        cc.enabled = true;
    }


    private IEnumerator Break()
    {
        particle.Play();
        particle1.Play();
        particle2.Play();

        sr.enabled = false;
        cc.enabled = false;
        yield return new WaitForSeconds(particle.main.startLifetime.constantMax);
        //Destroy(gameObject);
        gameObject.SetActive(false);
    }
}
