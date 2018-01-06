using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowSpawner : MonoBehaviour {

	public GameObject  _prefab;
	public Follower follower;
	private void SpawnFollower()
	{
		follower = Instantiate(_prefab).GetComponent<Follower>();
		follower.transform.position = transform.position;
		follower.transform.rotation = transform.rotation;
		follower.SetFollowTarget(transform);
	}

	private void Start()
	{
		SpawnFollower();
	}
}
