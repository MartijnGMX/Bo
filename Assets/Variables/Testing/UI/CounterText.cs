using UnityEngine;
using UnityEngine.UI;
using System;

[ExecuteInEditMode]
public class CounterText: MonoBehaviour {
	private Text text;

	public int count;

	private string content="";

	public string prefix="";

	void Awake(){
		text = GetComponent<Text>();
		count = 0;
		UpdateText();
	}
	public void IncrementCounter(){
		count++;
		content = count.ToString();
		UpdateText();
	}
	protected void UpdateText(){
		text.text = prefix + content;
	}
}
