using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionEffect : MonoBehaviour {
	ParticleSystem ps;
	public bool play;
	public Vector3 velocity;

	// Use this for initialization
	void Awake() {
		ps = GetComponent<ParticleSystem>();	
	}
	
	// Update is called once per frame
	void Update () {
		if(play && !ps.isPlaying) {
			ParticleSystem.VelocityOverLifetimeModule vel = ps.velocityOverLifetime;
			vel.enabled = true;
			vel.space = ParticleSystemSimulationSpace.World;
			vel.x = velocity.x;
			vel.y = velocity.y;
			vel.z = velocity.z;
			ps.Play();
			play = false;
		}
	}
}
