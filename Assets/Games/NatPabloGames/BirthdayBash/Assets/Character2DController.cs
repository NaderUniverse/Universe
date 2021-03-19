using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character2DController : MonoBehaviour
{
   
	public Animator animator;
   
    public bool isGrounded = false;

	


	bool jump = false;
	bool crouch = false;
    public float MovementSpeed =1;
    public float JumpForce = 1;
    private float m_CrouchSpeed = .36f;

     private Rigidbody2D _rigidBody;

     private void Start()
    {
        _rigidBody = GetComponent<Rigidbody2D>();
    }

	// Update is called once per frame
	void Update () {

		var movement = Input.GetAxis("Horizontal");
        var rot = transform.rotation;
        transform.position += new Vector3(movement, 0,0) * Time.deltaTime * MovementSpeed;


		animator.SetFloat("Speed", Mathf.Abs(movement));

        Vector3 characterScale = transform.localScale;

        if(Input.GetAxis("Horizontal")<0)
        {
            characterScale.x = -5;
        }
        if(Input.GetAxis("Horizontal")>0)
        {
            characterScale.x = 5;
        }

        transform.localScale = characterScale;

		if (Input.GetButtonDown("Jump")&& isGrounded==true)
		{
			 _rigidBody.AddForce(new Vector2(0,JumpForce), ForceMode2D.Impulse);
			animator.SetBool("IsJumping", true);
		}
         if (Input.GetButtonUp("Jump"))
		{
			// _rigidBody.AddForce(new Vector2(0,JumpForce), ForceMode2D.Impulse);
			animator.SetBool("IsJumping", false);
		}

		if (Input.GetKeyDown(KeyCode.DownArrow))
		{
			animator.SetBool("IsCrouching", true);
             MovementSpeed *= m_CrouchSpeed;
		} 
         if (Input.GetKeyUp(KeyCode.DownArrow))
		{
			animator.SetBool("IsCrouching", false);
             MovementSpeed /= m_CrouchSpeed;
		}

	}

	

}
