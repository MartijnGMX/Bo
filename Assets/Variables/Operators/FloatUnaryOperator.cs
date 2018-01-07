using UnityEngine;

namespace IvoryLake.Variables
{
	public class FloatUnaryOperator: MonoBehaviour {
		public FloatVariable target;

		public void Increment(){
			target.Value = target.Value + 1f;
		}
		public void Decrement(){
			target.Value = target.Value - 1f;
		}
		public void Assign(float val){
			target.Value = val;
		}
		public void Add(float val){
			target.Value = target.Value + val;
		}
		public void Subtract(float val){
			target.Value = target.Value - val;
		}
		public void Multiply(float val){
			target.Value = target.Value * val;
		}
		public void Divide(float val){
			if(val != 0f) {
				target.Value = target.Value / val;
			}
		}
	}
}