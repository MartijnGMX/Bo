using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class OnCollisionEnterListener : MonoBehaviour {

	public UnityEvent OnCollision;

	void OnCollisionEnter(){
		if(isActiveAndEnabled) {
			if(OnCollision != null) {
				OnCollision.Invoke();
			}
		} else {
		//	Debug.LogError("OnCollisionEnterListener: called on inactive component!");
		}
	}
}
