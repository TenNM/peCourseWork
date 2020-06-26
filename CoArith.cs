using System;

namespace peCourseWork
{
    [Serializable()]
    internal class CoArith : Complex
    {
        internal double re { get; set; }
        internal double im { get; set; }

        internal CoArith()
        {
            this.re = 1;
            this.im = 1;
        }
        internal CoArith(double re, double im)
        {
            this.re = re;
            this.im = im;
        }
        internal CoArith(CoArith c)
        {
            this.re = c.re;
            this.im = c.im;
        }
        //-------------------------------------------------------------service
        string signStr(double x)
        {
            if (x >= 0) return "+";
            else return "-";
        }
        internal void printLineComplex()
        {
            Console.WriteLine($"{this.re} {signStr(this.im)} {Math.Abs(this.im)}{'i'}");
        }
        public override string ToString()
        {
            return (String.Format( "{0} {1} {2}i", re, signStr(im), Math.Abs(im) ));
        }
        //---------------------------------------------------------------------------------convert
        internal override CoArith convertToArith()
        {
            return this;
        }
        internal override CoTrigonometric convertToTrigonometric()
        {
            if (this.re > EPS)
            {
                return new CoTrigonometric(
                    this.abs(),
                    Math.Atan2(this.im, this.re)
                    );
            }
            else throw new Exception(ERR_DIVISION_BY_ZERO);
        }
        //------------------------------------------------------------------------------unary obj style
        internal CoArith conjugation(){
            return new CoArith(this.re, -1 * this.im);
        }
        internal CoArith negate()
        {
            return new CoArith(-1 * this.re, -1 * this.im);
        }
        internal double abs()
        {
            return Math.Sqrt(this.re * this.re + this.im * this.im);
        }
        internal double arg()
        {
            if ((this.re != 0) && (this.im != 0)) { return Math.Atan2(this.im, this.re); }
            else throw new Exception("For complex zero, the argument value is undefined");
        }
        internal CoArith sqrtComplex()
        {
            if (this.im != 0)
            {
                return new CoArith(
                    Math.Sqrt((this.abs() + this.re) / 2),
                    Math.Sign(this.im) * Math.Sqrt((this.abs() - this.re) / 2)
                    );
            }
            else return new CoArith(Math.Sqrt(this.re), 0);
        }
        //-----------------------------------------------------------------------------unary static
        internal static CoArith sqrtComplex(double d)
        {
            if(d >= 0){ return new CoArith(Math.Sqrt(d), 0); }
            else return new CoArith(0, Math.Sqrt(Math.Abs(d)) );
        }
        internal static CoArith sqrtComplex(CoArith c)
        {
            if (c.im != 0)
            {
                return new CoArith(
                    Math.Sqrt((c.abs() + c.re) / 2),
                    Math.Sign(c.im) * Math.Sqrt((c.abs() - c.re) / 2)
                    );
            }
            else return new CoArith(Math.Sqrt(c.re), 0);
        }
        //-----------------------------------------------------------------------------binary obj style
        internal void plus(CoArith second)
        {
            this.re += second.re;
            this.im += second.im;
        }

        internal void minus(CoArith second)
        {
            this.re -= second.re;
            this.im -= second.im;
        }

        internal void mul(CoArith second)//?????????
        {
            //this.re = this.re * second.re - this.im * second.im;
            //this.im = this.im * second.re + this.re * second.im;

            double a = this.re * second.re - this.im * second.im;
            double b = this.im * second.re + this.re * second.im;
            this.re = a;
            this.im = b;
        }
        //-------------------------------------------------------------------binary static
        internal static CoArith plus(CoArith first, CoArith second)
        {
            return new CoArith(first.re + second.re, first.im + second.im);
        }
        internal static CoArith plus(CoArith c, double d)
        {
            return new CoArith(c.re + d, c.im);
        }
        //-----
        internal static CoArith minus(CoArith first, CoArith second)
        {
            return new CoArith(first.re - second.re, first.im - second.im);
        }
        internal static CoArith minus(CoArith c, double d)
        {
            return new CoArith(c.re - d, c.im);
        }
        //-----
        internal static CoArith mul(CoArith first, CoArith second)
        {
            return new CoArith(
                first.re * second.re - first.im * second.im,
                first.im * second.re + first.re * second.im
                );
        }
        internal static CoArith mul(CoArith c, double d)
        {
            return new CoArith(c.re * d,c.im * d);
        }
        //-----
        internal static CoArith dev(CoArith first, CoArith second)
        {
            if ((second.re != 0) || (second.im != 0))
            {
                return new CoArith(
                    (first.re * second.re + first.im * second.im) / (second.re * second.re + second.im * second.im),
                    (first.im * second.re - first.re * second.im) / (second.re * second.re + second.im * second.im)
                    );
            }
            else throw new Exception("division by zero");
        }
        internal static CoArith dev(CoArith c, double d)
        {
            if (d != 0)
            {
                return new CoArith(c.re / d, c.im / d);
            }
            else throw new Exception("division by zero");
        }
        internal static CoArith dev(double d, CoArith c)
        {
            if ((c.re != 0) || (c.im != 0))
            {
                CoArith t1 = d * c.conjugation();
                CoArith t2 = c * c.conjugation();
                return new CoArith(t1 / t2);
            }
            else throw new Exception("division by zero");
        }
        internal static bool equals(CoArith c1, CoArith c2)
        {
            return ( (c1.re == c2.re) && (c1.im == c2.im) );
        }
        internal static bool equals(CoArith c, double d)
        {
            return ( (c.re == d) && (0 == c.im) );
        }
        //-------------------------------------------------------------------------operator override
        public static CoArith operator +(CoArith c1, CoArith c2){ return plus(c1, c2); }
        public static CoArith operator +(CoArith c, double d)   { return plus(c, d); }
        public static CoArith operator +(double d, CoArith c)   { return plus(c, d); }
        //-----
        public static CoArith operator -(CoArith c1, CoArith c2){ return minus(c1, c2); }
        public static CoArith operator -(CoArith c, double d)   { return minus(c, d); }
        public static CoArith operator -(double d, CoArith c)   { return plus(-c, d); }
        public static CoArith operator -(CoArith c){ return new CoArith(-1*c.re, -1*c.im); }//unary
        //-----
        public static CoArith operator *(CoArith c1, CoArith c2){ return mul(c1, c2); }
        public static CoArith operator *(CoArith c, double d)   { return mul(c, d); }
        public static CoArith operator *(double d, CoArith c)   { return mul(c, d); }
        //-----
        public static CoArith operator /(CoArith c1, CoArith c2){ return dev(c1, c2); }
        public static CoArith operator /(CoArith c, double d)   { return dev(c, d); }
        public static CoArith operator /(double d, CoArith c)   { return dev(d, c); }
        //-----
        public static bool operator ==(CoArith c1, CoArith c2){ return equals(c1, c2); }
        public static bool operator !=(CoArith c1, CoArith c2){ return !equals(c1, c2); }
        public static bool operator ==(CoArith c, double d)   { return equals(c, d); }
        public static bool operator !=(CoArith c, double d)   { return !equals(c, d); }
        public static bool operator ==(double d, CoArith c)   { return equals(c, d); }
        public static bool operator !=(double d, CoArith c)   { return !equals(c, d); }

        //--------------------------------------------------------------------------end
    }
}
