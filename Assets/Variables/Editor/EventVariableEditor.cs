using UnityEditor;
using UnityEngine;

namespace IvoryLake.Variables
{
	[CustomEditor(typeof(EventVariable))]
	public class EventVariableEditor : Editor {
		
		public override void OnInspectorGUI() {
			EventVariable f = (EventVariable)target;

			EditorGUILayout.LabelField("Description:");
			f.DeveloperDescription = EditorGUILayout.TextArea(f.DeveloperDescription);

			EditorGUILayout.LabelField("Raise counter: " + f.raiseCounter);

			if (Application.isPlaying) {
				if (GUILayout.Button("Raise this event!")) {
					f.Raise();
				}
			} else {
				GUILayout.Button("Enter playmode to be able to raise!");
			}
		}
	}
}
