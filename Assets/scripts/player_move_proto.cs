using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class player_move_proto : MonoBehaviour {

	public Rigidbody2D rb;

    public float playerSpeed = 1;
    private bool facingRight = true;
    public int playerJumpPower = 1250;
    private float moveX;

	public Animator anim;
            
	public bool walking;

	public int JumpCount = 0;
	public bool grounded;

	public CircleCollider2D collid;

	public Rigidbody2D weapon;
	public int weaponSpeed = 10;


	public Transform swordSpawnTransform;

	void Update () {

		ResetScene ();

        PlayerControls ();

	}

	void FixedUpdate()
	{
		AnimPlayer ();

		PlayerMove ();
	}

    void PlayerControls()
    {
        //Player Controls

        moveX = Input.GetAxisRaw("Horizontal");



		if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            
            PlayerJump();

        }

        //Player Animations
        //Player Direction

        if (moveX < 0.0f && facingRight == false)
        {
            FlipPlayer();
        }

        else if (moveX > 0.0f && facingRight == true)
        {
            FlipPlayer();
        }


		if (Input.GetKeyDown (KeyCode.X))
		{
			
			ThrowWeapon ();
		}
        

    }


	void PlayerMove()
	{
		rb.velocity = new Vector2(moveX * playerSpeed, rb.velocity.y);
	}

	void AnimPlayer()
	{
        /*
        if (moveX != 0f) {
			if (!walking) {
				if (grounded)
				{
					walking = true;

					anim.SetTrigger ("Run");
				}

			}
		} 
      

        else
        {
            if (walking)
            {
                if (grounded)
                {
                    walking = false;

                    anim.SetTrigger("Idle");
                }
            }
        }
        */
        
        if (grounded)
        {
            if (moveX != 0f)
            {
                walking = true;

                anim.SetTrigger("Run");
            }

            else
            {
                walking = false;

                anim.SetTrigger("Idle");
            }
        }
        
	}

    void PlayerJump()
    {
        //Jumping Code
		if (JumpCount < 2)
		{
//			rb.AddForce(Vector2.up * playerJumpPower, ForceMode2D.Impulse);

			rb.velocity = new Vector2 (rb.velocity.x, playerJumpPower);

            if (JumpCount == 0)
            {
                anim.SetTrigger("Jump");
            }

            if (JumpCount == 1 && !grounded)
            {
                anim.SetTrigger("Jump2");
            }


            JumpCount += 1;


		}

        /*
		if (JumpCount == 1) 
		{
			anim.SetTrigger ("Jump");
		}

		if (JumpCount == 2 && !grounded)
		{
			anim.SetTrigger ("Jump2");
		}
        */
    }

    void FlipPlayer()
    {
        facingRight = !facingRight;

        Vector2 localScale = gameObject.transform.localScale;
        localScale.x *= -1;
        transform.localScale = localScale;

    }

	void ResetScene()
	{

		if (Input.GetKeyDown (KeyCode.Escape))
		{
			SceneManager.LoadScene (SceneManager.GetActiveScene().buildIndex);
		}
	}

	 
	void OnTriggerStay2D (Collider2D collider)
	{
		if (!grounded)
		{
			
			if(collider.gameObject.layer == LayerMask.NameToLayer ("Platforms"))
			{
				

				Land ();
			}
			/*
			grounded = true;
			JumpCount = 0;

			Land ();
			*/
		}



	}

	void OnTriggerExit2D (Collider2D collider)
	{
		if (grounded)
		{
			grounded = false;
		}
	}

	void Land ()
	{
        grounded = true;
        JumpCount = 0;
        
        if (moveX != 0f)
		{
			walking = true;

			anim.SetTrigger ("Run");

            //Debug.Log("landrun");

		} 
		else
		{
			
			walking = false;

			anim.SetTrigger ("Idle");

            //Debug.Log("Landidle");
		}
	}

	void ThrowWeapon()
	{
		Rigidbody2D weaponInstance = Instantiate (weapon, swordSpawnTransform.position, weapon.transform.rotation) as Rigidbody2D;

		Vector2 swordScale = weaponInstance.transform.localScale;

		if (facingRight)
		{
			swordScale.x *= 1;
			weaponInstance.transform.localScale = swordScale;

			weaponInstance.velocity = -transform.right * weaponSpeed;
		}

		else
		{
			swordScale.x *= -1;
			weaponInstance.transform.localScale = swordScale;

			weaponInstance.velocity = transform.right * weaponSpeed;
		}

		if (grounded)
		{
			anim.SetTrigger ("Throw");
		}

		if (!grounded)
		{
			anim.SetTrigger ("Airthrow");
		}

		Physics2D.IgnoreCollision (weaponInstance.GetComponent<Collider2D>(), GetComponent <Collider2D>());

	}
}
