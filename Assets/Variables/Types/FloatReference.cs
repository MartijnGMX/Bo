// ----------------------------------------------------------------------------
// Inspired by: Unite 2017 - Game Architecture with Scriptable Objects
// 
// Author: Ryan Hipple
// Date:   10/04/17
// ----------------------------------------------------------------------------

using System;

namespace IvoryLake.Variables
{
    [Serializable]
	public class FloatReference : ValueReference
    {
        public float ConstantValue;
        public FloatVariable Variable;

        public FloatReference(float value)
        {
            UseConstant = true;
            ConstantValue = value;
        }

        public float Value
        {
            get { return UseConstant ? ConstantValue : Variable.Value; }
			set { 
				if(UseConstant) {
					ConstantValue = value;
				} else {
					Variable.Value = value;
				}
			}
        }

        public static implicit operator float(FloatReference reference)
        {
            return reference.Value;
        }
    }
}
