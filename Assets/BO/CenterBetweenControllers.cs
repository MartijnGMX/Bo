using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VRTK;

public class CenterBetweenControllers : MonoBehaviour {
	public GameObject leftController;
	public GameObject rightController;

	public float leftDistFromCenter;
	public float rightDistFromCenter;

	public bool leftTriggerPressed;

	// Use this for initialization
	void Start () {
		leftController = VRTK_DeviceFinder.GetControllerLeftHand();
		rightController = VRTK_DeviceFinder.GetControllerRightHand();


	}

	void OnEnable(){

	}
	// Update is called once per frame
	void Update () {
		if(leftController != null && rightController != null) {
			Vector3 leftPos = leftController.transform.position;
			Vector3 rightPos = rightController.transform.position;

			/*VRTK_ControllerEvents leftCEvents = (leftController.GetComponent<VRTK_ControllerEvents>() ? leftController.GetComponent<VRTK_ControllerEvents>() : leftController.GetComponentInParent<VRTK_ControllerEvents>());
			if(leftCEvents) {
				leftTriggerPressed = leftCEvents.triggerPressed;
			}*/
			// center position
			//if (leftController.ge
			Vector3 newPos = Vector3.Lerp(leftPos, rightPos, 0.5f);
			transform.position = newPos;

			// orient towards one of the controllers, 
			// use up vector of controller as 'up'
			transform.rotation = Quaternion.LookRotation(leftPos - rightPos);

			// compute hand distances:
			leftDistFromCenter = (newPos - leftPos).magnitude;
			rightDistFromCenter = (newPos - rightPos).magnitude;
		} else {
			leftController = VRTK_DeviceFinder.GetControllerLeftHand();
			rightController = VRTK_DeviceFinder.GetControllerRightHand();
		}
	}
}
