using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace IvoryLake.Variables
{
	[System.Serializable]
	public class Vector3ChangedEvent : UnityEvent<Vector3>{}

	public class Vector3VariableListener : ValueVariableListener<Vector3Variable> {
		
		/// <summary>
		/// Use this event to call custom functions whenever the variable changes.
		/// </summary>
		public Vector3ChangedEvent onChanged;
		public FloatChangedEvent onXChanged;
		public FloatChangedEvent onYChanged;
		public FloatChangedEvent onZChanged;

		public override void OnValueChanged(){
			Vector3Variable v3var = (Vector3Variable)variable;
			onChanged.Invoke(v3var.Value);
			onXChanged.Invoke(v3var.Value.x);
			onYChanged.Invoke(v3var.Value.y);
			onZChanged.Invoke(v3var.Value.z);
		}
	}
}