using UnityEngine;

namespace IvoryLake.Variables
{
	public class IntBinaryOperator: MonoBehaviour {
		public IntReference arg1;
		public IntReference arg2;
		public IntReference res;

		public void Add(){
			res.Value = arg1 + arg2;
		}
		public void Sub(){
			res.Value = arg1 - arg2;
		}
		public void Mul(){
			res.Value = arg1 * arg2;
		}
		public void Div(){
			if(arg2.Value != 0) {
				res.Value = arg1 / arg2;
			}
		}
	}
}