using UnityEditor;

namespace IvoryLake.Variables
{
	[CustomEditor(typeof(IntVariable))]
	public class IntVariableEditor : Editor {
		bool useSlider = false;
		int sliderMin = 0;
		int sliderMax = 1;

		public override void OnInspectorGUI() {
			IntVariable f = (IntVariable)target;
			EditorGUI.BeginChangeCheck();

			EditorGUILayout.LabelField("Description:");
			f.DeveloperDescription = EditorGUILayout.TextArea(f.DeveloperDescription);

			useSlider = EditorGUILayout.Toggle("Show slider?", useSlider);
			if (useSlider) {
				sliderMin = EditorGUILayout.IntField("Min", sliderMin);
				sliderMax = EditorGUILayout.IntField("Max", sliderMax);
				f.Value = EditorGUILayout.IntSlider("Value", f.Value, sliderMin, sliderMax);
			} else {
				f.Value = EditorGUILayout.IntField("Value", f.Value);
			}

			f.applyDefaultAtStartup = EditorGUILayout.Toggle("Use default value at startup?", f.applyDefaultAtStartup);
			if(f.applyDefaultAtStartup) {
				f.defaultValue = EditorGUILayout.IntField("Default value", f.defaultValue);
			}
			if (EditorGUI.EndChangeCheck()) {
				EditorUtility.SetDirty(f);
			}
		}
	}
}
