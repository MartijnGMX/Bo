using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace IvoryLake.Variables
{
	[System.Serializable]
	public class FloatChangedEvent : UnityEvent<float>{}

	public class FloatVariableListener : ValueVariableListener<FloatVariable> {
		/// <summary>
		/// Use this event to call custom functions whenever the variable changes.
		/// </summary>
		public FloatChangedEvent onChanged;

		public override void OnValueChanged(){
			onChanged.Invoke(((FloatVariable)variable).Value);
		}
	}
}