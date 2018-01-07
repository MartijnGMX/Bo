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
	public class IntVariable : ValueVariable
	{
		public int Value {
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
		private int _value;

		public int defaultValue;

		protected override void ApplyDefaultValue(){
			Value = defaultValue;
		}

		public void SetValue(float val){
			Value = (int) val;
		}
	}
}