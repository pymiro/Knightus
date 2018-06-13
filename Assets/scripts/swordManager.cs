using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class swordManager : MonoBehaviour {

	public Animator anim;

	public Collider2D swordCollider;

	public Rigidbody2D swordRB;

	private int randomAnim;

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
		randomAnim = Random.Range (0, 3);

		if (randomAnim == 0)
		{
			anim.SetTrigger ("swordHit");
		}
		else if (randomAnim == 1)
		{
			anim.SetTrigger ("swordHit1");
		}
		else if (randomAnim == 2)
		{
			anim.SetTrigger ("swordHit2");
		}

		swordCollider.enabled = false;

		swordRB.velocity = new Vector2 (0,0);

		yield return new WaitForSeconds (anim.GetCurrentAnimatorClipInfo (0).Length);
		Destroy (gameObject);
	}
}
