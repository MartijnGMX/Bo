using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleRotator : MonoBehaviour {
	public float scale = 1f;
	public void RotateX(float val){
		Vector3 rot = transform.localEulerAngles;
		rot.x = val*scale;
		transform.localEulerAngles = rot;
	}
	public void RotateY(float val){
		Vector3 rot = transform.localEulerAngles;
		rot.y = val*scale;
		transform.localEulerAngles = rot;
	}
	public void RotateZ(float val){
		Vector3 rot = transform.localEulerAngles;
		rot.z = val*scale;
		transform.localEulerAngles = rot;
	}
}
