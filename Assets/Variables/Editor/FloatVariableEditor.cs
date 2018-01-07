using UnityEditor;

namespace IvoryLake.Variables
{
	[CustomEditor(typeof(FloatVariable))]
	public class FloatVariableEditor : Editor {
		bool useSlider = false;
		float sliderMin = 0f;
		float sliderMax = 1f;

		public override void OnInspectorGUI() {
			FloatVariable f = (FloatVariable)target;
			EditorGUI.BeginChangeCheck();

			EditorGUILayout.LabelField("Description:");
			f.DeveloperDescription = EditorGUILayout.TextArea(f.DeveloperDescription);

			useSlider = EditorGUILayout.Toggle("Show slider?", useSlider);
			if (useSlider) {
				sliderMin = EditorGUILayout.FloatField("Min", sliderMin);
				sliderMax = EditorGUILayout.FloatField("Max", sliderMax);
				f.Value = EditorGUILayout.Slider("Value", f.Value, sliderMin, sliderMax);
			} else {
				f.Value = EditorGUILayout.FloatField("Value", f.Value);
			}
			f.applyDefaultAtStartup = EditorGUILayout.Toggle("Use default value at startup?", f.applyDefaultAtStartup);
			if(f.applyDefaultAtStartup) {
				f.defaultValue = EditorGUILayout.FloatField("Default value", f.defaultValue);
			}
			if (EditorGUI.EndChangeCheck()) {
				EditorUtility.SetDirty(f);
			}
		}
	}
}
