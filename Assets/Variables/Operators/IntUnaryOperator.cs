using UnityEngine;

namespace IvoryLake.Variables
{
	public class IntUnaryOperator: MonoBehaviour {
		public IntVariable target;

		public void Increment(){
			target.Value = target.Value + 1;
		}
		public void Decrement(){
			target.Value = target.Value - 1;
		}
		public void Assign(int val){
			target.Value = val;
		}
		public void Add(int val){
			target.Value = target.Value + val;
		}
		public void Subtract(int val){
			target.Value = target.Value - val;
		}
		public void Multiply(int val){
			target.Value = target.Value * val;
		}
		public void Divide(int val){
			if(val != 0) {
				target.Value = target.Value / val;
			}
		}
	}
}