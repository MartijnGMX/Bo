using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace IvoryLake.Variables
{
	public abstract class VariableListener : MonoBehaviour 
	{
		[Tooltip("Call 'OnValueChanged' on start?")]
		public bool callFirstTime = true;
		bool _callFirstTime=false;

		// implement in subclass
		protected abstract void RegisterMe();
		protected abstract void UnRegisterMe();
		public abstract void OnValueChanged();

		protected virtual void OnEnable(){
			RegisterMe();
			_callFirstTime = callFirstTime;
		}

		protected virtual void Update() {
			if (_callFirstTime){
				OnValueChanged();
				_callFirstTime = false;
			}
		}

		protected virtual void OnDisable(){
			UnRegisterMe();
		}
	}

	public abstract class ValueVariableListener<T> : VariableListener 
		where T:ValueVariable 
	{
		[Tooltip("Variable to listen to, for changes.")]
		public T variable;

		protected override void RegisterMe(){
			variable.RegisterListener(this);
		}
		protected override void UnRegisterMe(){
			variable.UnregisterListener(this);
		}
	}
}