﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallSpawner : MonoBehaviour {
	public GameObject spawnPrefab;

	public float initialInterval;

	public float currentInterval;

	public Vector3[] spawnPoints;

	public bool keepSpawning = false;

	public bool spawnWithVelocity;
	public Vector3 initialVelocity;

	// Use this for initialization
	void Start () {
		StartCoroutine(KeepSpawning());
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	// spawn a prefab at one of the spawn points
	void Spawn(){
		int i = Random.Range(0, spawnPoints.Length);
		Vector3 pos = transform.TransformPoint(spawnPoints[i]);

		GameObject newGO = Instantiate(spawnPrefab, pos, Quaternion.identity);
		if(spawnWithVelocity) {
			Rigidbody rb = newGO.GetComponent<Rigidbody>();
			rb.useGravity = true;
			rb.velocity = initialVelocity;
		}
	}

	void OnDrawGizmos()
	{
		Gizmos.color = Color.yellow;
		//Gizmos.DrawSphere(transform.position, 1f);
		foreach(Vector3 pos in spawnPoints) {
			Gizmos.DrawWireSphere(transform.TransformPoint(pos), 0.3f);
		}
	}
	void SpawnAfterInterval(){
		StartCoroutine(SpawnOnceAfterInterval());
	}
	IEnumerator SpawnOnceAfterInterval(){
		yield return new WaitForSecondsRealtime(currentInterval);
		Spawn();
	}
	IEnumerator KeepSpawning(){
		while(true) {
			if(keepSpawning) {
				Spawn();
			}
			yield return new WaitForSecondsRealtime(currentInterval);
		}
	}
}