using System;

namespace peCourseWork
{
    [Serializable()]
    internal class CoTrigonometric : Complex
    {
        internal double abs { get; set; }
        internal double fi { get; set; }

        internal CoTrigonometric()
        {
            this.abs = 1;
            this.fi = SpecialNumbers.PI_4;
        }
        internal CoTrigonometric(double abs, double fi)
        {
            this.abs = abs;
            this.fi = fi;
        }
        internal CoTrigonometric(CoTrigonometric ct)
        {
            this.abs = ct.abs;
            this.fi = ct.fi;
        }
        //-------------------------------------------------------------service
        string signStr(double x)
        {
            if (x >= 0) return "+";
            else return "-";
        }
        internal void printLineComplex()
        {
            Console.WriteLine("{0}*(cos({1})+isin({1}))", abs, fi);
        }
        public override string ToString()
        {
            return (string.Format("{0}*(cos({1})+isin({1}))", abs, fi));
        }
        internal override string ToStringLowPrecision(byte pres)
        {
            double newAbs = Service.roundAdvanced(abs, pres);
            double newFi = Service.roundAdvanced(fi, pres);

            return (string.Format("{0}*(cos({1})+isin({1}))", newAbs, newFi));
        }
        internal bool equals(CoTrigonometric second)
        {
            return ( (Math.Abs(this.abs - second.abs)<EPS) && (Math.Abs(this.fi - second.fi)<EPS) );
        }
        internal static bool equals(CoTrigonometric ct1, CoTrigonometric ct2)
        {
            return ((Math.Abs(ct1.abs - ct2.abs) < EPS) && (Math.Abs(ct1.fi - ct2.fi) < EPS));
        }
        //---------------------------------------------------------------------------------convert
        internal override CoArith convertToArith()
        {
            this.fiNormalize();
            return new CoArith(
                this.abs * Math.Cos(this.fi),
                this.abs * Math.Sin(this.fi)
                );
        }
        internal override CoTrigonometric convertToTrigonometric()
        {
            return this;
        }
        //------------------------------------------------------------------------unary obj style
        internal void fiNormalize()
        {
            this.fi %= (2 * Math.PI);
        }
        //------------------------------------------------------------------------binary ststic
        internal static CoTrigonometric mul(CoTrigonometric ct1, CoTrigonometric ct2)
        {
            return new CoTrigonometric(ct1.abs * ct2.abs, ct1.fi + ct2.fi);
        }
        internal static CoTrigonometric dev(CoTrigonometric ct1, CoTrigonometric ct2)
        {
            if (ct2.abs != 0) { return new CoTrigonometric(ct1.abs / ct2.abs, ct1.fi - ct2.fi); }
            else throw new Exception("division by zero - divider modulus is zero");
        }
        internal static CoTrigonometric pow(CoTrigonometric ct, uint n)
        {
            return new CoTrigonometric(Math.Pow(ct.abs, n), ct.fi * n);
        }
        internal static CoTrigonometric rootN(CoTrigonometric ct, uint n, uint k)
        {
            if(0 == n) { throw new Exception("division by zero - n can't be 0"); }
            if (k < n) {
                return new CoTrigonometric(
                    Math.Pow(ct.abs, 1.0 / n),
                    (ct.fi + 2 * Math.PI * k) / n
                    ); ;
            } else throw new Exception("k can't be more then n - 1");

        }
        //-------------------------------------------------------------------------operator override
        public static CoTrigonometric operator *(CoTrigonometric ct1, CoTrigonometric ct2) { return mul(ct1, ct2); }
        public static CoTrigonometric operator /(CoTrigonometric ct1, CoTrigonometric ct2) { return dev(ct1, ct2); }
        public static CoTrigonometric operator ^(CoTrigonometric ct, uint n) { return pow(ct, n); }
        public static bool operator ==(CoTrigonometric ct1, CoTrigonometric ct2) { return equals(ct1, ct2); }
        public static bool operator !=(CoTrigonometric ct1, CoTrigonometric ct2) { return !equals(ct1, ct2); }
        //--------------------------------------------------------------------------end
    }
}
