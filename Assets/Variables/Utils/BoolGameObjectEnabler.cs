using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace IvoryLake.Variables
{
	public class BoolGameObjectEnabler : ValueVariableListener<BoolVariable> {
		public bool invert=false;		
		public GameObject target;

		public override void OnValueChanged(){
			if (invert) {
				target.SetActive(!(variable.Value));
			} else {
				target.SetActive(variable.Value);
			}
		}
	}
}