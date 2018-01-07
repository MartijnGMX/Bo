// ----------------------------------------------------------------------------
// Inspired by: Unite 2017 - Game Architecture with Scriptable Objects
// 
// Author: Ryan Hipple
// Date:   10/04/17
// ----------------------------------------------------------------------------

using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace IvoryLake.Variables
{
	public abstract class ValueVariable : ScriptableObject
	{
#if UNITY_EDITOR
		[Multiline]
		public string DeveloperDescription = "";
#endif
		private List<VariableListener> listeners = new List<VariableListener>();

		public bool applyDefaultAtStartup=false;

		protected virtual void OnEnable(){
			if(applyDefaultAtStartup) {
				ApplyDefaultValue();
				// we might not have all listeners yet,
				// but they can use callFirstTime to use the value that is set 
				// when we start with the Update() routines
			}
		}

		protected abstract void ApplyDefaultValue();

		protected void RaiseChanged(){
			foreach (var listener in listeners) {
				listener.OnValueChanged();
			}
		}

		public void RegisterListener(VariableListener listener)
		{
			listeners.Add(listener);
		}

		public void UnregisterListener(VariableListener listener)
		{
			listeners.Remove(listener);
		}
	}
}