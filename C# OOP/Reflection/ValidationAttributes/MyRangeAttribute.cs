using System;
using System.Collections.Generic;
using System.Text;

namespace ValidationAttributes
{
    public class MyRangeAttribute : MyValidationAttribute
    {
        private readonly int _min;
        private readonly int _max;
        public MyRangeAttribute(int min, int max)
        {
            this._max = max;
            this._min = min;
        }
        public override bool IsValid(object obj)
        {
            if(!(obj is int))
            {
                throw new ArgumentException();
            }

            int valueAsInt = (int)obj;

            if(valueAsInt >= _min && valueAsInt <= _max)
            {
                return true;
            }

            return false;
        }
    }
}
