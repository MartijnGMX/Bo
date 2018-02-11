using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallSpawner : MonoBehaviour {
	public GameObject spawnPrefab;

	public float initialInterval;

	public float currentInterval;

	public BallSpawnPoint[] spawnPoints;
	private BallSpawnPoint lastSpawnPoint;

	public MeshFilter arrowMesh;

	public HitterType[] hitterTypes;

	public bool keepSpawning = false;

	public bool spawnWithVelocity;
	public Vector3 initialVelocity;

	public int ballCounter;
	// Use this for initialization
	void Start () {
		StartCoroutine(KeepSpawning());
		ballCounter = 0;
		lastSpawnPoint = null;
		spawnPoints = GetComponentsInChildren<BallSpawnPoint>(true);
		currentInterval = initialInterval;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	BallSpawnPoint GetRandomSpawnPoint(){
		int i = Random.Range(0, spawnPoints.Length);
		BallSpawnPoint newPos = spawnPoints[i];
		if (lastSpawnPoint!=null){
			// ensure we get a different position than last time (rotation may be different though)
			while (Vector3.SqrMagnitude(newPos.transform.position - lastSpawnPoint.transform.position)<0.1f){
				// too close, take another guess
				i = Random.Range(0, spawnPoints.Length);
				newPos = spawnPoints[i];
			}
		}	
		lastSpawnPoint = newPos;
		return newPos;
	}
	// spawn a prefab at one of the spawn points
	void Spawn(){
		BallSpawnPoint newPos = GetRandomSpawnPoint();

		GameObject newGO = Instantiate(spawnPrefab, newPos.transform.position, newPos.transform.rotation, transform	);
		newGO.name = "Ball_" + (ballCounter++);
		if(spawnWithVelocity) {
			Rigidbody rb = newGO.GetComponent<Rigidbody>();
			rb.useGravity = true;
			rb.velocity = initialVelocity;
		}

		//int hitterId = Random.Range(0, hitterTypes.Length);
		newGO.GetComponent<BallHitHandler>().hitterType = newPos.hitterType; //hitterTypes[hitterId];
		//Debug.Log("Ball spawned: " + newGO.name + " with hitter type: " + hitterTypes[hitterId].name);
	}

	void OnDrawGizmosSelected()
	{
		Gizmos.color = Color.yellow;
		//Gizmos.DrawSphere(transform.position, 1f);
		foreach(BallSpawnPoint sp in spawnPoints) {
			Gizmos.DrawWireMesh(arrowMesh.sharedMesh, sp.transform.position, sp.transform.rotation);
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
