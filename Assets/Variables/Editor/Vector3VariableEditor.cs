using UnityEditor;
using UnityEngine;

namespace IvoryLake.Variables
{
	[CustomEditor(typeof(Vector3Variable))]
	public class Vector3VariableEditor : Editor {
		
		public override void OnInspectorGUI() {
			Vector3Variable f = (Vector3Variable)target;
			EditorGUI.BeginChangeCheck();

			EditorGUILayout.LabelField("Description:");
			f.DeveloperDescription = EditorGUILayout.TextArea(f.DeveloperDescription);

			f.Value = EditorGUILayout.Vector3Field("Value", f.Value);

			f.applyDefaultAtStartup = EditorGUILayout.Toggle("Use default value at startup?", f.applyDefaultAtStartup);
			if(f.applyDefaultAtStartup) {
				f.defaultValue = EditorGUILayout.Vector3Field("Default value", f.defaultValue);
			}
			if (EditorGUI.EndChangeCheck()) {
				EditorUtility.SetDirty(f);
			}
		}
	}
}
