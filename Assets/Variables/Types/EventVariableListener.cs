using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace IvoryLake.Variables
{
	public class EventVariableListener : ValueVariableListener<EventVariable>	{
		[Tooltip("Response to invoke when Event is raised.")]
		public UnityEvent onChanged;

		public override void OnValueChanged(){
			onChanged.Invoke();
		}
	}
}