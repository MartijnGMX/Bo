using UnityEngine;

namespace IvoryLake.Variables
{
	public class IntAssigner: MonoBehaviour {
		public IntReference source;
		public IntVariable destination;

		public void Assign(){
			destination.Value = source;
		}
	}
}