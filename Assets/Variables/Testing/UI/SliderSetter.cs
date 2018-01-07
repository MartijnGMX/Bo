using UnityEngine;
using UnityEngine.UI;

[ExecuteInEditMode]
public class SliderSetter : MonoBehaviour {
	private Slider slider;

	void Awake(){
		slider = GetComponent<Slider>();
	}
	public void SetFromInt(int val){
		slider.value = (float) val;
	}
}
