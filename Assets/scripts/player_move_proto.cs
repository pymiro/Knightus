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


	void Update () {

		if (Input.GetKeyDown (KeyCode.Escape)) {
			SceneManager.LoadScene (SceneManager.GetActiveScene().buildIndex);
		}

        playerMove ();

	}

	void FixedUpdate()
	{
		if (moveX != 0f) {
			if (!walking) {
				walking = true;

				anim.SetTrigger ("Run");
			}
		} 
		else {
			if (walking) {
				walking = false;

				anim.SetTrigger ("Idle");
			}
		}


		rb.velocity = new Vector2(moveX * playerSpeed, rb.velocity.y);
	}

    void playerMove()
    {
        //Player Controls

        moveX = Input.GetAxisRaw("Horizontal");



		if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            playerJump();

        }

        //Player Animations
        //Player Direction

        if (moveX < 0.0f && facingRight == false)
        {
            flipPlayer();
        }

        else if (moveX > 0.0f && facingRight == true)
        {
            flipPlayer();
        }

        //Player Physics

    }



    void playerJump()
    {
        //Jumping Code
        rb.AddForce(Vector2.up * playerJumpPower);
    }

    void flipPlayer()
    {
        facingRight = !facingRight;

        Vector2 localScale = gameObject.transform.localScale;
        localScale.x *= -1;
        transform.localScale = localScale;

    }
}
