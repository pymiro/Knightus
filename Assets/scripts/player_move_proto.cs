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

        //Player Physics

    }


	void PlayerMove()
	{
		rb.velocity = new Vector2(moveX * playerSpeed, rb.velocity.y);
	}

	void AnimPlayer()
	{
		if (moveX != 0f) {
			if (!walking) {
				if (grounded)
				{
					walking = true;

					anim.SetTrigger ("Run");
				}

			}
		} 
		else {
			if (walking) {
				if (grounded)
				{
					walking = false;

					anim.SetTrigger ("Idle");
				}
			}
		}


	}

    void PlayerJump()
    {
        //Jumping Code
		if (JumpCount < 2)
		{
			rb.AddForce(Vector2.up * playerJumpPower);

			JumpCount += 1;


		}

		if (JumpCount == 1) 
		{
			anim.SetTrigger ("Jump");
		}

		if (JumpCount == 2)
		{
			anim.SetTrigger ("Jump2");
		}

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
			grounded = true;
			JumpCount = 0;

			Land ();
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
		if (moveX != 0f)
		{
			walking = true;

			anim.SetTrigger ("Run");

		} 
		else
		{
			
			walking = false;

			anim.SetTrigger ("Idle");

		}
	}
}
