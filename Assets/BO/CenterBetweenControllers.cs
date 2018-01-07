using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VRTK;

public class CenterBetweenControllers : MonoBehaviour {
	public GameObject leftController;
	public GameObject rightController;

	VRTK_ControllerEvents leftCEvents;
	VRTK_ControllerEvents rightCEvents;

	public float leftDistFromCenter;
	public float rightDistFromCenter;

	public bool leftTriggerPressed;
	public bool rightTriggerPressed;

	public bool inited;

	[Range(0,1f)]
	public float lerpVal=0.5f;
	// Use this for initialization
	void Start () {
		inited = false;
	}

	void Setup(){
		leftController = VRTK_DeviceFinder.GetControllerLeftHand();
		rightController = VRTK_DeviceFinder.GetControllerRightHand();
		if(leftController != null && rightController != null) {
			leftCEvents = (leftController.GetComponent<VRTK_ControllerEvents>() ? leftController.GetComponent<VRTK_ControllerEvents>() : leftController.GetComponentInParent<VRTK_ControllerEvents>());
			rightCEvents = (rightController.GetComponent<VRTK_ControllerEvents>() ? rightController.GetComponent<VRTK_ControllerEvents>() : rightController.GetComponentInParent<VRTK_ControllerEvents>());
			if(leftCEvents != null && rightCEvents != null) {
				inited = true;
			}
		}
	}

	void OnEnable(){

	}
	// Update is called once per frame
	void Update () {
		if(inited) {
			Vector3 leftPos = leftController.transform.position;
			Vector3 rightPos = rightController.transform.position;
			Vector3 newPos;

			if(leftCEvents != null && rightCEvents != null) {
				leftTriggerPressed = leftCEvents.triggerPressed;
				rightTriggerPressed = rightCEvents.triggerPressed;
			} else {
				Setup();
			}

			// compute hand distances:
			if(!leftTriggerPressed && rightTriggerPressed) {
				// hold in right hand, recompute left distance
				leftDistFromCenter = (rightPos - leftPos).magnitude - rightDistFromCenter;
				lerpVal = leftDistFromCenter / (leftDistFromCenter + rightDistFromCenter);
			} else if(leftTriggerPressed && !rightTriggerPressed) {
				// hold in left hand, recompute right distance
				rightDistFromCenter = (rightPos - leftPos).magnitude - leftDistFromCenter;
				lerpVal = leftDistFromCenter / (leftDistFromCenter + rightDistFromCenter);
			} else {
				// recompute both
				lerpVal = 0.5f;
				leftDistFromCenter = (rightPos - leftPos).magnitude * 0.5f;
				rightDistFromCenter = leftDistFromCenter;
			}

			/*if(leftTriggerPressed && !rightTriggerPressed) {
				// keep distance to left hand
				lerpVal = leftDistFromCenter / (leftDistFromCenter + rightDistFromCenter);
			}
			if(rightTriggerPressed && !leftTriggerPressed) {
				// keep distance to right hand
				lerpVal = rightDistFromCenter / (leftDistFromCenter + rightDistFromCenter);
			}*/

			// center position
			newPos = Vector3.Lerp(leftPos, rightPos, lerpVal);
			transform.position = newPos;

			// orient towards one of the controllers, 
			// use up vector of controller as 'up'
			transform.rotation = Quaternion.LookRotation(leftPos - rightPos);


		} else {
			Setup();
		}
	}
}
