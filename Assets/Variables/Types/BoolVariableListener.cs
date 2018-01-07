using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace IvoryLake.Variables
{
	[System.Serializable]
	public class BoolChangedEvent : UnityEvent<bool>{}

	public class BoolVariableListener : ValueVariableListener<BoolVariable> {
		/// <summary>
		/// Use this event to call custom functions whenever the variable changes.
		/// </summary>
		public BoolChangedEvent onChanged;

		public bool invert = false;

		public override void OnValueChanged(){
			bool newVal = ((BoolVariable)variable).Value;
			if (invert) {
				newVal = !newVal;
			}
			onChanged.Invoke(newVal);
		}
	}
}