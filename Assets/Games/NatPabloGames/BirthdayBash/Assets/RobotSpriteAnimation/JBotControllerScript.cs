using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JBotControllerScript : MonoBehaviour
{
    // Start is called before the first frame update
     [SerializeField] float      m_speed = 4.0f;
    [SerializeField] float      m_jumpForce = 7.5f;

    private Animator            m_animator;
    private Rigidbody2D         m_body2d;
    private Sensor_Bandit       m_groundSensor;
    private bool                m_grounded = false;
    private bool                m_combatIdle = false;
    private bool                m_isDead = false;

    public LayerMask enemyLayers;

    public Transform attackPoint;
    public float attackRange = 0.5f;
    public int attackDamage = 20;

    public float attackRate = 2f;
    float nextAttackTime = 0f;

    public int maxHealth1 = 100;
    int currentHealth1;

    public HealthBar healthBar1;
    public HealthBar fillableBar;

    public int maxFB = 100;
    int currentFB;

    public Transform firePoint;
	public GameObject bulletPrefab;
   


    // Use this for initialization
    void Start () {
        m_animator = GetComponent<Animator>();
        m_body2d = GetComponent<Rigidbody2D>();
        m_groundSensor = transform.Find("GroundSensor").GetComponent<Sensor_Bandit>();

        currentHealth1 = maxHealth1;
        healthBar1.SetMaxHealth(maxHealth1);

        currentFB = 0;
        fillableBar.SetHealth(currentFB);




    }
	
	// Update is called once per frame
	void Update () {
        // //Check if character just landed on the ground
        // if (!m_grounded && m_groundSensor.State()) {
        //     m_grounded = true;
        //     m_animator.SetBool("Grounded", m_grounded);
        // }

        // //Check if character just started falling
        // if(m_grounded && !m_groundSensor.State()) {
        //     m_grounded = false;
        //     m_animator.SetBool("Grounded", m_grounded);
        // }

        // // -- Handle input and movement --
        // float inputX = Input.GetAxis("Horizontal");

        // // Swap direction of sprite depending on walk direction
        // if (inputX > 0)
        //     //transform.localScale = new Vector3(-1.0f, 1.0f, 1.0f);
        //     transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);
        // else if (inputX < 0)
        //     //transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);
        //      transform.localScale = new Vector3(-1.0f, 1.0f, 1.0f);

        // // Move
        // m_body2d.velocity = new Vector2(inputX * m_speed, m_body2d.velocity.y);

        // //Set AirSpeed in animator
        // m_animator.SetFloat("AirSpeed", m_body2d.velocity.y);

        // // -- Handle Animations --
        // //Death
        // if (Input.GetKeyDown("e")) {
        //     if(!m_isDead)
        //         m_animator.SetTrigger("Death");
        //     else
        //         m_animator.SetTrigger("Recover");

        //     m_isDead = !m_isDead;
        // }
            
        // //Hurt
        // else if (Input.GetKeyDown("q"))
        //     {
        //     m_animator.SetTrigger("Hurt");
        //     TakeDamage(30);
        //     }

        //Attack
        if(Input.GetKeyDown(KeyCode.Return)) {
           // m_animator.SetTrigger("Attack");
           if(Time.time >= nextAttackTime)
        {
            
           Attack();
           Shoot();
           nextAttackTime = Time.time + 1f / attackRate;
        }
        
        }

        // //Change between idle and combat idle
        // else if (Input.GetKeyDown("f"))
        //    // m_combatIdle = !m_combatIdle;
        //    {
        //        ReleaseFullBar();
        //        Debug.Log("Bar was depleted!");
        //    }

        // //Jump
        // else if (Input.GetKeyDown("space") && m_grounded) {
        //     m_animator.SetTrigger("Jump");
        //     m_grounded = false;
        //     m_animator.SetBool("Grounded", m_grounded);
        //     m_body2d.velocity = new Vector2(m_body2d.velocity.x, m_jumpForce);
        //     m_groundSensor.Disable(0.2f);
        // }

        // //Run
        // else if (Mathf.Abs(inputX) > Mathf.Epsilon)
        //     m_animator.SetInteger("AnimState", 2);

        // //Combat Idle
        // else if (m_combatIdle)
        //     m_animator.SetInteger("AnimState", 1);

        //Idle
        else
            m_animator.SetInteger("AnimState", 0);
    }

    public void TakeDamage(int damage)
    {
        currentHealth1 -=damage;
        healthBar1.SetHealth(currentHealth1);

        m_animator.SetTrigger("Hurt");

        if(currentHealth1 <= 0)
        {
            Die();
        }

        
    }

    void Shoot ()
	{
		Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
	}

    void ReleaseFullBar()
    {
        fillableBar.SetHealth(0);
    }

    void Die()
    {
         Debug.Log("You died!");
         
        m_animator.SetTrigger("Death");
        
        

    }

    void Attack()
    {
        m_animator.SetTrigger("Attack");
       Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange,enemyLayers);

       foreach(Collider2D enemy in hitEnemies)
       {
           enemy.GetComponent<Enemy>().TakeDamage(attackDamage);
           FillBar(attackDamage);
       }
    }

    void FillBar(int damage1)
    {
         currentFB += damage1;
        fillableBar.SetHealth(currentFB);

        

        if(currentFB == maxFB)
        {
            Debug.Log("Fillable Bar is full!");
        }
    }

    void OnDrawGizmosSelected()
    {
        if(attackPoint == null)
        return;
        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }
}
