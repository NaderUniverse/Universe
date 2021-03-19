using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public Animator enemyAnimator;
    public int maxHealth = 100;
    int currentHealth;

    public HealthBar healthBar;

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
    }

    public void TakeDamage(int damage)
    {
        currentHealth -=damage;
        healthBar.SetHealth(currentHealth);

        enemyAnimator.SetTrigger("Hurt");

        if(currentHealth <= 0)
        {
            Die();
        }

        
    }

    void Die()
    {
        Debug.Log("Enemy died!");
         enemyAnimator.SetBool("IsDead",true);
        

       // GetComponent<Collider2D>().enabled= false;
        this.enabled = false;
        

    }


    
}
