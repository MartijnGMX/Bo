using UnityEngine;

public class Follower : MonoBehaviour
{
	public Transform _target;
	public Rigidbody _rigidbody;
	public Vector3 _velocity;

	[Range(0.1f, 3f)]
	public float _sensitivity = 1f;

	private void Awake()
	{
		_rigidbody = GetComponent<Rigidbody>();
	}

	private void FixedUpdate()
	{
		Vector3 destination = _target.position;
		//_rigidbody.transform.rotation = transform.rotation;

		_velocity = (destination - _rigidbody.transform.position) * (1f/Time.fixedDeltaTime) * _sensitivity;

		_rigidbody.velocity = _velocity;
		_rigidbody.MoveRotation(_target.rotation);
		// transform.rotation = _target.rotation;
	}

	public void SetFollowTarget(Transform target)
	{
		_target = target;
	}
}