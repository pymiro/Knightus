using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player_move_proto : MonoBehaviour {

    public int playerSpeed = 10;
    private bool facingRight = true;
    public int playerJumpPower = 1250;
    private float moveX;

            

	
	void Update () {

        playerMove ();

	}

    void playerMove()
    {
        //Player Controls

        moveX = Input.GetAxis("Horizontal");

        if (Input.GetButtonDown("Jump"))
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
        gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(moveX * playerSpeed, gameObject.GetComponent<Rigidbody2D>().velocity.y);

    }

    void playerJump()
    {
        //Jumping Code
        GetComponent<Rigidbody2D>().AddForce(Vector2.up * playerJumpPower);
    }

    void flipPlayer()
    {
        facingRight = !facingRight;

        Vector2 localScale = gameObject.transform.localScale;
        localScale.x *= -1;
        transform.localScale = localScale;

    }
}
