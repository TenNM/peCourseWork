using System;

namespace peCourseWork
{
    [Serializable()]
    class Fraction : SpecialNumbers
    {
        internal int num { get; set; }
        internal int den { get; set; }//!!!!!! cant be zero

        internal Fraction()
        {
            this.num = 1;
            this.den = 1;
        }
        internal Fraction(int numerator, int denominator)
        {
            this.num = numerator;
            this.den = denominator;
        }
        internal Fraction(int num)
        {
            this.num = num;
            this.den = 1;
        }
        //-----------------------------------------------------------------------------
        public override string ToString()
        {
            return (String.Format("({0} / {1})", this.num, this.den));
        }
        //-----------------------------------------------------------------------------unary obj style
        internal void fractionReduction()
        {
            if (this.num == this.den || this.num % this.den == 0)
            {
                //return String.valueOf(top / bot);
                this.num /= this.den;
                this.den = 1;
            }
            else
            {
                int newNum = this.num;
                int newDen = this.den;
                for (int i = 2; i <= this.num; i++)
                {
                    if (this.num % i == 0 && this.den % i == 0)
                    {
                        newNum = this.num / i;
                        newDen = this.den / i;
                    }
                }          
            }
        }
        internal double fractionToDouble()
        {
            if (den != 0) return num / den;
            else throw new Exception(ERR_DIVISION_BY_ZERO);
        }
        //-----------------------------------------------------------------------------unary static
        //-----------------------------------------------------------------------------binary obj style
        //-----------------------------------------------------------------------------binary static
        internal static Fraction arith(Fraction fr1, Fraction fr2, char mode)
        {
            Fraction frRes = null;
            fr1.fractionReduction();
            fr2.fractionReduction();
            switch (mode)
            {
                case '+':
                    {
                        frRes = new Fraction(
                        fr1.num * fr2.den + fr2.num * fr1.den,
                        fr1.den * fr2.den
                        );
                    }break;
                case '-':
                    {
                        frRes = new Fraction(
                        fr1.num * fr2.den - fr2.num * fr1.den,
                        fr1.den * fr2.den
                        );
                    }
                    break;
                case '*':
                    {
                        frRes = new Fraction(
                        fr1.num * fr2.num,
                        fr1.den * fr2.den
                        );
                    }
                    break;
                case '/':
                    {
                        frRes = new Fraction(
                        fr1.num * fr2.den,
                        fr1.den * fr2.num
                        );
                    }
                    break;
                default: throw new Exception(ERR_MODE_DOES_NOT_EXIST);
            }
            frRes.fractionReduction();
            return frRes;
        }
        //-----------------------------------------------------------------------------operator override
        //-----------------------------------------------------------------------------end
    }
}
