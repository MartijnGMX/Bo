using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace IvoryLake.Variables
{
	[System.Serializable]
	public class StringChangedEvent : UnityEvent<string>{}

	public class StringVariableListener : ValueVariableListener<StringVariable> {
		/// <summary>
		/// Use this event to call custom functions whenever the variable changes.
		/// </summary>
		public StringChangedEvent onChanged;

		public override void OnValueChanged(){
			onChanged.Invoke(((StringVariable)variable).Value);
		}
	}
}