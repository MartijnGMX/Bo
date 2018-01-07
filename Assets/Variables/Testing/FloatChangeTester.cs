using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloatChangeTester: MonoBehaviour {
	public float currentVal;
	public int changeCounter=0;
	void Awake(){
		changeCounter = 0;
	}

	public void FloatHasChanged(float newVal){
		currentVal = newVal;
		changeCounter++;
	}
}
