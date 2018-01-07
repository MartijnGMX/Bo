using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace IvoryLake.Variables
{
	[System.Serializable]
	public class IntChangedEvent : UnityEvent<int>{}

	public class IntVariableListener : ValueVariableListener<IntVariable> {
		/// <summary>
		/// Use this event to call custom functions whenever the variable changes.
		/// </summary>
		public IntChangedEvent onChanged;

		public override void OnValueChanged(){
			onChanged.Invoke(((IntVariable)variable).Value);
		}
	}
}