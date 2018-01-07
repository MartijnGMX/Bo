using UnityEngine;

namespace IvoryLake.Variables
{
	public class BoolUnaryOperator: MonoBehaviour {
		public BoolVariable target;

		public void Negate(){
			target.Value = !target.Value;
		}
		public void And(bool val){
			target.Value = target.Value & val;
		}
		public void Or(bool val){
			target.Value = target.Value | val;
		}
		public void Xor(bool val){
			target.Value = target.Value ^ val;
		}
	}
}