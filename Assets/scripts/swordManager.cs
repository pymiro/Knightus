using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class swordManager : MonoBehaviour {

//	public GameObject sword;

	void OnBecomeInvisible()
	{
		Destroy (gameObject);
	}
}
