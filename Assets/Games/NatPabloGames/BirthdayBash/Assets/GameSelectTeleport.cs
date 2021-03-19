using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameSelectTeleport : MonoBehaviour
{
     public string gameLevel;
     private ParticleSystem PS;
    private SpriteRenderer SR;

    private BoxCollider2D BC;
    // Start is called before the first frame update
    private void Awake()
    {
        PS = GetComponentInChildren<ParticleSystem>();
        SR = GetComponent<SpriteRenderer>();
       BC = GetComponent<BoxCollider2D>();
    }
    private void OnCollisionEnter2D(Collision2D other1)
    {
        //if hit from bottom of brick
        if(other1.collider.gameObject.GetComponent<Character2DController>() && other1.contacts[0].normal.y > 0.5f)
        {
          //Destroy(gameObject);  
          StartCoroutine(Break());
        }
        
    }


    private IEnumerator Break()
    {
        PS.Play();

        SR.enabled = false;
        BC.enabled = false;
        yield return new WaitForSeconds(PS.main.startLifetime.constantMax);
        GameTeleport();
        Destroy(gameObject);
    }
    public void GameTeleport()
    {
       // Time.timeScale = 1f;
        SceneManager.LoadScene(gameLevel);
    }
}
