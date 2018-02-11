using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class BallSpawnPoint : MonoBehaviour {
	public HitterType hitterType;

	void Update(){
		GetComponent<MeshRenderer>().material.color = hitterType.color;
	}
}
