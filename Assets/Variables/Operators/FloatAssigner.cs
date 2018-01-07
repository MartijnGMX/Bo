using UnityEngine;

namespace IvoryLake.Variables
{
	public class FloatAssigner: MonoBehaviour {
		public FloatReference source;
		public FloatVariable destination;

		public void Assign(){
			destination.Value = source;
		}
	}
}