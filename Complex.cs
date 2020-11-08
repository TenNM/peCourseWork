using System;

namespace peCourseWork
{
    [Serializable()]
    abstract class Complex : SpecialNumbers
    {
        internal abstract CoArith convertToArith();
        internal abstract CoTrigonometric convertToTrigonometric();
        internal abstract string ToStringLowPrecision(byte pres);
    }
}
