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
	public class EventVariable : ValueVariable
	{
		protected override void ApplyDefaultValue(){
		}
		// no actual data here. It's just an event that can be triggered

		public int raiseCounter=0;

		protected override void OnEnable(){
			raiseCounter = 0;
			base.OnEnable();
		}

		public void Raise(){
			raiseCounter++;
			RaiseChanged(); // from base class ValueVariable
		}
	}
}