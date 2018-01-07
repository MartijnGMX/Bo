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
	public class IntReference : ValueReference
    {
        public int ConstantValue;
        public IntVariable Variable;

        public IntReference(int value)
        {
            UseConstant = true;
            ConstantValue = value;
        }

        public int Value
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

        public static implicit operator int(IntReference reference)
        {
            return reference.Value;
        }
    }
}
