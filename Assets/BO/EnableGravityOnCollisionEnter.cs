using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnableGravityOnCollisionEnter : MonoBehaviour {
	void OnCollisionEnter(){
		GetComponent<Rigidbody>().useGravity = true;
	}
}
