using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class swordManager : MonoBehaviour {

	public Animator anim;

	public Collider2D swordCollider;

	public Rigidbody2D swordRB;

	void Update()
	{
		
	}


	void OnBecameInvisible()
	{
		Destroy (gameObject);
	}


	void OnTriggerEnter2D(Collider2D collider)
	{
		if (collider.gameObject.layer == LayerMask.NameToLayer ("Platforms"))
		{

			StartCoroutine (swordDestroy());

		}
	}


	private IEnumerator swordDestroy()
	{
		anim.SetTrigger ("swordHit");

		swordCollider.enabled = false;

		swordRB.velocity = new Vector2 (0,0);

		yield return new WaitForSeconds (anim.GetCurrentAnimatorClipInfo (0).Length);
		Destroy (gameObject);
	}
}
