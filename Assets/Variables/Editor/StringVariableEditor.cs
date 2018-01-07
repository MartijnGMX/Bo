using UnityEditor;

namespace IvoryLake.Variables
{
	[CustomEditor(typeof(StringVariable))]
	public class StringVariableEditor : Editor {
		public override void OnInspectorGUI() {
			StringVariable f = (StringVariable)target;
			EditorGUI.BeginChangeCheck();

			EditorGUILayout.LabelField("Description:");
			f.DeveloperDescription = EditorGUILayout.TextArea(f.DeveloperDescription);

			EditorGUILayout.PrefixLabel("Value");
			f.Value = EditorGUILayout.TextArea(f.Value);

			f.applyDefaultAtStartup = EditorGUILayout.Toggle("Use default value at startup?", f.applyDefaultAtStartup);
			if(f.applyDefaultAtStartup) {
				EditorGUILayout.PrefixLabel("Default value");
				f.defaultValue = EditorGUILayout.TextArea(f.defaultValue);
			}
			if (EditorGUI.EndChangeCheck()) {
				EditorUtility.SetDirty(f);
			}
		}
	}
}
