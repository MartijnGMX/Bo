using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace IvoryLake.Variables
{
	public class BoolBehaviourEnabler : ValueVariableListener<BoolVariable> {
		public bool invert=false;		
		public Behaviour target;

		public override void OnValueChanged(){
			if (invert) {
				target.enabled = !(variable.Value);
			} else {
				target.enabled = variable.Value;
			}
		}
	}
}