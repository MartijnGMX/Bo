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
	public FloatVariable particleVelocityScale;
	public ParticleSystem ps;

	public TextMesh debugText;
	public TextMesh scoreText;

	public BoolVariable removeAfterHit;
	public FloatReference allowedAngleError;

	public bool isAlreadyHit;

	public Renderer[] renderersToDisableWhenStartingPS;

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
		ps = GetComponent<ParticleSystem>();
		isAlreadyHit = false;
	}

	void OnTriggerEnter(Collider collider)
	{
		if(this.enabled && !isAlreadyHit) {
			if(IsInLayerMask(collider.gameObject.layer, hitFilter)) {
				Hitter hitter = collider.gameObject.GetComponent<Hitter>();
				if(hitter != null) {
					isAlreadyHit = true;
					// check hit direction:
				
					Vector3 worldHitDir = hitter.velocity.normalized;
					Vector3 relHitDir = transform.InverseTransformDirection(worldHitDir);

					// only care about xy for now:
					relHitDir.z = 0f;
					relHitDir = relHitDir.normalized;

					float angle = Mathf.Rad2Deg * Mathf.Acos(Vector3.Dot(relHitDir, Vector3.up));

					debugText.text = angle.ToString("F");
					if(angle < allowedAngleError.Value) {
						// check hitterType:
						if(hitter.hitterType == this.hitterType) {
						//	Debug.Log("Ball (" + this.name + ") has been hit! hitter:" + collider.gameObject.name);

							scoreText.text = points.Value.ToString("F");
							newScore.SetValue(points.Value, true); // always generate events, even if value is the same as the existing value
							// 
							if(removeAfterHit.Value) {
								hitEvent.Raise();

								// Emit particles
								if(ps) {
									ParticleSystem.VelocityOverLifetimeModule vel = ps.velocityOverLifetime;
									vel.enabled = true;
									vel.space = ParticleSystemSimulationSpace.World;
									Vector3 velocity = worldHitDir;
									//Rigidbody rb = hitter.GetComponent<Rigidbody>();
									velocity *= particleVelocityScale.Value;
									
									vel.x = velocity.x;
									vel.y = velocity.y;
									vel.z = velocity.z;
									ps.Play();
								} 
								DisableAfterParticleSystem();

								//gameObject.SetActive(false);
								//this.enabled = false; // otherwise we still get events?
								foreach(Renderer ren in renderersToDisableWhenStartingPS) {
									ren.enabled = false;
								}

							}
						} else {
							debugText.text += "\nwrong hitter type!";
							// wrong hit type!
							missEvent.Raise();
						}
					} else {
						// wrong hit direction!
						debugText.text += "\noff direction!";
						missEvent.Raise();
					}
				} else {
					// hit by something without a 'Hitter' component
				}
			}
		}
	}
	void OnTriggerExit(Collider collider)
	{
		if(IsInLayerMask(collider.gameObject.layer, hitFilter)) {
			Hitter hitter = collider.gameObject.GetComponent<Hitter>();
			if(hitter != null) {
	//			debugText.text = "released";
				isAlreadyHit = false;
			}
		}
	}

	void DisableAfterParticleSystem(){
		StartCoroutine(DisableAfterPS());
	}

	IEnumerator DisableAfterPS(){
		while(ps!=null && ps.isPlaying) {
			yield return new WaitForEndOfFrame();
		}
		gameObject.SetActive(false);
		this.enabled = false; // otherwise we still get events?
	}
}
