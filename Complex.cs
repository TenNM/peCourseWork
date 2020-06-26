using System;

namespace peCourseWork
{
    [Serializable()]
    abstract class Complex : SpecialNumbers
    {
        internal abstract CoArith convertToArith();
        internal abstract CoTrigonometric convertToTrigonometric();
    }
}
