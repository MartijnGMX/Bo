using UnityEditor;

namespace IvoryLake.Variables
{
	[CustomEditor(typeof(BoolVariable))]
	public class BoolVariableEditor : Editor {
		public override void OnInspectorGUI() {
			BoolVariable f = (BoolVariable)target;
			EditorGUI.BeginChangeCheck();

			EditorGUILayout.LabelField("Description:");
			f.DeveloperDescription = EditorGUILayout.TextArea(f.DeveloperDescription);

			f.Value = EditorGUILayout.Toggle("Value", f.Value);

			f.applyDefaultAtStartup = EditorGUILayout.Toggle("Use default value at startup?", f.applyDefaultAtStartup);
			if(f.applyDefaultAtStartup) {
				f.defaultValue = EditorGUILayout.Toggle("Default value", f.defaultValue);
			}
			if (EditorGUI.EndChangeCheck()) {
				EditorUtility.SetDirty(f);
			}
		}
	}
}
