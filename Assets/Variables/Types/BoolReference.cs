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
	public class BoolReference : ValueReference
    {
        public bool ConstantValue;
		public BoolVariable Variable;

		public BoolReference(bool value)
        {
            UseConstant = true;
            ConstantValue = value;
        }

        public bool Value
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

        public static implicit operator bool(BoolReference reference)
        {
            return reference.Value;
        }
    }
}
