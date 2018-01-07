using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hitter : MonoBehaviour {
	public HitterType hitterType;

	void OnEnable(){
		MeshRenderer mr = GetComponent<MeshRenderer>();
		if(mr) {
			mr.material.color = hitterType.color;
		} else {
			Debug.LogError("Hitter: no MeshRenderer found to set color to!");
		}
	}
}
