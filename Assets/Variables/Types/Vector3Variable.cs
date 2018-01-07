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
	public class Vector3Variable : ValueVariable
    {
		public Vector3 Value {
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
		private Vector3 _value;

		public Vector3 defaultValue;

		protected override void ApplyDefaultValue(){
			Value = defaultValue;
		}

		public void SetX(float val){
			Vector3 newVec = Value;
			newVec.x = val;
			Value = newVec;
		}
		public void SetY(float val){
			Vector3 newVec = Value;
			newVec.y = val;
			Value = newVec;
		}
		public void SetZ(float val){
			Vector3 newVec = Value;
			newVec.z = val;
			Value = newVec;
		}
	}
}