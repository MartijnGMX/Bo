using UnityEngine;
using UnityEngine.UI;
using System;

[ExecuteInEditMode]
public class TextSetter : MonoBehaviour {
	private Text text;

	private string content="";

	public string prefix="";
	public string postfix="";

	void Awake(){
		text = GetComponent<Text>();
		UpdateText();
	}
	public void SetFromString(string s){
		content = s;
		UpdateText();
	}
	public void SetFromFloat(float f){
		content = String.Format("{0:0.###}",f);
		UpdateText();
	}
	public void SetFromInt(int f){
		content = f.ToString();
		UpdateText();
	}
	public void SetFromVector3(Vector3 f){
		content = String.Format("({0:0.###}, {1:0.###}, {2:0.###})",f.x, f.y, f.z);
		UpdateText();
	}
	protected void UpdateText(){
		text.text = prefix + content + postfix;
	}
#if UNITY_EDITOR
	// just to allow you to set the label texts in the editor.
	void Update(){
		UpdateText();
	}
#endif
}
