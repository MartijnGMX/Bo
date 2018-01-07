using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallSpawner : MonoBehaviour {
	public GameObject spawnPrefab;

	public float initialInterval;

	public float currentInterval;

	public Vector3[] spawnPoints;
	public HitterType[] hitterTypes;

	public bool keepSpawning = false;

	public bool spawnWithVelocity;
	public Vector3 initialVelocity;

	public int ballCounter;
	// Use this for initialization
	void Start () {
		StartCoroutine(KeepSpawning());
		ballCounter = 0;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	// spawn a prefab at one of the spawn points
	void Spawn(){
		int i = Random.Range(0, spawnPoints.Length);
		Vector3 pos = transform.TransformPoint(spawnPoints[i]);

		GameObject newGO = Instantiate(spawnPrefab, pos, Quaternion.identity);
		newGO.name = "Ball_" + (ballCounter++);
		if(spawnWithVelocity) {
			Rigidbody rb = newGO.GetComponent<Rigidbody>();
			rb.useGravity = true;
			rb.velocity = initialVelocity;
		}

		int hitterId = Random.Range(0, hitterTypes.Length);
		newGO.GetComponent<BallHitHandler>().hitterType = hitterTypes[hitterId];
		Debug.Log("Ball spawned: " + newGO.name + " with hitter type: " + hitterTypes[hitterId].name);
	}

	void OnDrawGizmos()
	{
		Gizmos.color = Color.yellow;
		//Gizmos.DrawSphere(transform.position, 1f);
		foreach(Vector3 pos in spawnPoints) {
			Gizmos.DrawWireSphere(transform.TransformPoint(pos), 0.3f);
		}
	}
	public void SpawnAfterInterval(){
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
