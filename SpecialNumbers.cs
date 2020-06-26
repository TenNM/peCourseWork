using System;

namespace peCourseWork
{
    [Serializable()]
    abstract class SpecialNumbers
    {
        internal const string ERR_DIVISION_BY_ZERO = "Error: division by zero";
        internal const string ERR_MODE_DOES_NOT_EXIST = "Error: mode does not exist";

        internal const double EPS = 0.001;
        internal const double _2_PI = 2*Math.PI;
        internal const double PI = Math.PI;
        internal const double PI_2 = Math.PI / 2;
        internal const double PI_3 = Math.PI / 3;
        internal const double PI_4 = Math.PI / 4;
        internal const double PI_6 = Math.PI / 6;
    }
}
