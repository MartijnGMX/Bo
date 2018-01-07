using UnityEngine;

namespace IvoryLake.Variables
{
	public class BoolBinaryOperator: MonoBehaviour {
		public BoolReference arg1;
		public BoolReference arg2;
		public BoolReference res;

		public void And(){
			res.Value = arg1 & arg2;
		}
		public void Or(){
			res.Value = arg1 | arg2;
		}
		public void Xor(){
			res.Value = arg1 ^ arg2;
		}
	}
}