using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using IvoryLake.Variables;

public class EnergyDecrementer : MonoBehaviour {
	public FloatReference energyLevel;
	public FloatReference energyDecSpeedPerSec;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		energyLevel.Value += -Time.deltaTime * energyDecSpeedPerSec.Value;	
	}
}
