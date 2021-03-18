using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxState : MonoBehaviour
{
    [SerializeField]
    private SpriteRenderer enabledBox;
    [SerializeField]
    private SpriteRenderer disabledBox;
    [SerializeField]
    private SpriteRenderer coin;

    [SerializeField]
    private int totalCoins = 3;
    private int coinsLeft;

    private Animator anim;


   private void Awake()
   {
       enabledBox.enabled = true;
       disabledBox.enabled = false;
       coin.enabled = true;
       coinsLeft = totalCoins;
       anim = GetComponent<Animator>();

       if(coinsLeft<=0)
       {
           EmptyBox();
        }
   }

   private void OnCollisionEnter2D(Collision2D other)
   {
       if(coinsLeft>0)
       {
            if(other.collider.gameObject.GetComponent<Character2DController>() && other.contacts[0].normal.y > 0.5f)
            {
               GetCoin(); 
               if(coinsLeft <=0)
               {
                   EmptyBox();
               }
            }
        //coin.enabled = false;
       }
   }

   private void GetCoin()
   {
       coinsLeft--;
       GameManager.instance.AddCoin();

       anim.SetTrigger("getCoin");
   }

   private void EmptyBox()
   {
      enabledBox.enabled = false;
       disabledBox.enabled = true; 
      // coin.enabled = false;
   }
}
