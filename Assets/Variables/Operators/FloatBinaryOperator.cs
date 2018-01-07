using UnityEngine;

namespace IvoryLake.Variables
{
	public class FloatBinaryOperator: MonoBehaviour {
		public FloatReference arg1;
		public FloatReference arg2;
		public FloatReference res;

		public void Increment(){
			arg1.Value = arg1 + 1;
		}
		public void Decrement(){
			arg1.Value = arg1 - 1;
		}
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
			if(arg2.Value != 0f) {
				res.Value = arg1 / arg2;
			}
		}
	}
}