using UnityEngine;

namespace IvoryLake.Variables
{
	public class BoolAssigner: MonoBehaviour {
		public BoolReference source;
		public BoolVariable destination;

		public void Assign(){
			destination.Value = source;
		}
	}
}