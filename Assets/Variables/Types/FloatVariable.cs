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
    [CreateAssetMenu]
	public class FloatVariable : ValueVariable
    {
		public float Value {
			get{
				return _value; 
			}
			set{
				if (value != _value) {
					_value = value;
					RaiseChanged();
				}
			}
		}
		[SerializeField]
		private float _value;

		public float defaultValue;

		protected override void ApplyDefaultValue(){
			Value = defaultValue;
		}

		public void SetValue(int val){
			Value = (float) val;
		}
		public void SetValue(string val){
			try{
				Value = System.Convert.ToSingle(val);
			} catch (System.Exception e) {
				Debug.Log("FloatVariable: could not set value from string '" + val + "'!");
			}
		}
	}
}