using UnityEngine;

namespace IvoryLake.Variables
{
	public class StringAssigner: MonoBehaviour {
		public StringReference source;
		public StringVariable destination;

		public void Assign(){
			destination.Value = source;
		}
	}
}