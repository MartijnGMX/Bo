using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
//using UnityEditor.Events;

namespace IvoryLake.Variables
{
	/// <summary>
	/// Add this component to a UI input field, to connect it to a FloatVariable.
	/// </summary>
	[ExecuteInEditMode]
	public class FloatInputField : ValueVariableListener<FloatVariable> {
		InputField inputField;
		public int decimalPlaces = 2;
		string stringFormat = "{0:0.###}";

		protected virtual void Awake(){
			inputField = GetComponent<InputField>();
			inputField.contentType = InputField.ContentType.DecimalNumber;
			// Link the event handles. 
			// note: this will NOT show up in the inspector!
			// you can do that with UnityEventTools.AddPersistentListener, but that's a PITA also
			inputField.onValueChanged.AddListener(OnInputUpdated); 
			UpdateFormatString();
		}

		void UpdateFormatString(){
			if (decimalPlaces <= 0) {
				stringFormat = "{0:0}";
			} else {
				stringFormat = "{0:0." + new string('#', decimalPlaces) + "}";
			}
		}

		void SetFromFloat(float f){
			inputField.text = string.Format(stringFormat, f);
		}	

		// be sure to call this when the text in the input field is changed!
		public void OnInputUpdated(string val){
			try{
				variable.Value = System.Convert.ToSingle(val);
			} catch {
				Debug.Log("FloatInputField: unable to parse string '" + val + "'!");
			}
		}
			
		public override void OnValueChanged(){
			SetFromFloat(((FloatVariable)variable).Value);
		}

#if UNITY_EDITOR
		// just to allow you to tweak stuff in the editor. Should not be called in a standalone build.
		protected override void Update(){
			UpdateFormatString();
			base.Update();
		}
#endif
	}
}
