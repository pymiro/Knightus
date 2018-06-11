using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class swordManager : MonoBehaviour {

//	public GameObject sword;

	public GameObject dust;

	public Transform point;

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
			//Instantiate (dust, point, dust.transform.rotation);

			Destroy (gameObject);
		}
	}
}
