using UnityEngine;

namespace IvoryLake.Variables
{
	public class Vector3Assigner: MonoBehaviour {
		public Vector3Reference source;
		public Vector3Variable destination;

		public void Assign(){
			destination.Value = source;
		}
	}
}