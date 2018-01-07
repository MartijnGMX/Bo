using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using IvoryLake.Variables;

public class BallHitHandler : MonoBehaviour {
	public LayerMask hitFilter;
	public HitterType hitterType;
	public EventVariable hitEvent;
	public EventVariable missEvent; // trigger this if a wrong hit is detected, e.g. by the wrong hitterType
	public FloatVariable points;
	public FloatVariable newScore;

	// extra stuff for hitDirection and hitterType
//	public enum side;
	// TODO: add minimum velocity?

	public static bool IsInLayerMask(int layer, LayerMask layermask)
	{
		return layermask == (layermask | (1 << layer));
	}

	void Start(){
		MeshRenderer mr = GetComponent<MeshRenderer>();
		if(mr) {
			mr.material.color = hitterType.color;
		} else {
			Debug.LogError("BallHitHandler: no MeshRenderer found to set color to!");
		}
	}

	void OnCollisionEnter(Collision collision)
	{
		if(this.enabled) {
			if(IsInLayerMask(collision.gameObject.layer, hitFilter)) {
				Hitter hitter = collision.gameObject.GetComponent<Hitter>();
				if(hitter != null) {
					if(hitter.hitterType == this.hitterType) {
						Debug.Log("Ball (" + this.name + ") has been hit! hitter:" + collision.gameObject.name);
						hitEvent.Raise();

						newScore.SetValue(points.Value, true); // always generate events, even if value is the same as the existing value
						// TODO: start animation
						gameObject.SetActive(false);
						this.enabled = false; // otherwise we still get events?
					} else {
						// wrong hit type!
						missEvent.Raise();
					}
				} else {
					// hit by something without a 'Hitter' component
				}
			}
		}
	}

}
