using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hitter : MonoBehaviour {
	public HitterType hitterType;
	public Vector3 velocity;
	private Vector3 lastPosition;

	void OnEnable(){
		MeshRenderer mr = GetComponent<MeshRenderer>();
		if(mr) {
			mr.material.color = hitterType.color;
		} else {
			Debug.LogError("Hitter: no MeshRenderer found to set color to!");
		}
		lastPosition = transform.position;
	}
		
	void Update(){
		// compute velocity over last frame;
		Vector3 currPos = transform.position;
		velocity = (currPos - lastPosition) / Time.deltaTime;
		lastPosition = currPos;
	}
}
