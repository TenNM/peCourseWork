using System;

namespace peCourseWork
{
    internal abstract class Service
    {
        internal static bool stringIsNumber(string s)
        {
            bool weHaveOneComma = false;
            if (s[0].Equals(',')) { weHaveOneComma = true; }
            else if (!(char.IsDigit(s[0]) || s[0].Equals('-'))) { return false; }

            for (int i = 1; i < s.Length; i++)
            {
                if (s[i].Equals(','))
                {
                    if (weHaveOneComma) { return false; }
                    else weHaveOneComma = true;
                }

                else if (!char.IsDigit(s[i])) { return false; }

            }

            return true;
        }
        internal static string dotsToCommas(string withCommasStr)
        {
            string tempStr = "";
            foreach (char c in withCommasStr)
            {
                if ('.' == c) { tempStr += ','; }
                else tempStr += c;
            }
            return tempStr;
        }
        public static double roundAdvanced(double d, int accuracy)
        {
            accuracy = (int)Math.Pow(10, accuracy);
            d = d * accuracy;
            int i = (int)Math.Round(d);
            return (double)i / accuracy;
        }
        //------------------------------------------------------------------------------end
    }
}
