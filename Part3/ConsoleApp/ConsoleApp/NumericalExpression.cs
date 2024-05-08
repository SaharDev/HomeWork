using System;
using System.Runtime.CompilerServices;

namespace ConsoleApp
{
    public class NumericalExpression
    {
        private long value;

        public NumericalExpression(long value)
        {
            this.value = value;
        }

        public long GetValue()
        {
            return this.value;
        }

        public static long SumLetters(long num)
        {
            long sum = 0;

            for (long i = 0; i <= num; i++)
                sum += (new NumericalExpression(i)).ToString().Replace(" ", "").Length;
            return sum;
        }

        // Question 7.f answer: OverLoading
        public static long SumLetters(NumericalExpression num)
        {
            return SumLetters(num.GetValue());
        }

        public override string ToString()
        {
            if (this.value == 0)
                return "Zero";

            string[] arr = 
                { "", "Thousand", "Million", "Billion", "Trillion"};

            string res = "";
            long num = this.value;
            int counter = 0;

            while (num > 0 && counter < arr.Length)
            {
                res = Convert3DigitNumToString((int)(num % 1000)) 
                    + $"{arr[counter]} " + res;
                counter++;
                num /= 1000;
            }

            return res;
        }

        /// <summary>
        /// Converts up to 3 digits number into string.
        /// </summary>
        /// <param name="num">int 0 - 999 </param>
        /// <returns>The number in words. </returns>
        static string Convert3DigitNumToString(int num)
        {
            
            return OneDigitToString(num / 100) +
                (num / 100 != 0 ? " Hundred ": "") 
                + TwoDigitToString(num % 100) + " ";
        }

        private static string DigitToTens(int num)
        {
            switch (num)
            {
                case 2: return "Twenty";
                case 3: return "Thirty";
                case 4: return "Forty";
                case 5: return "Fifty";
                case 6: return "Sixty";
                case 7: return "Seventy";
                case 8: return "Eighty";
                case 9: return "Ninety";
                default: return "";
            }
        }

        private static string TwoDigitToString(int num)
        {
            switch (num % 100)
            {
                case 10: return "Ten";
                case 11: return "Tleven";
                case 12: return "Twelve";
                case 13: return "Thirteen";
                case 14: return "Fourteen";
                case 15: return "Fifteen";
                case 16: return "Sixteen";
                case 17: return "Seventeen";
                case 18: return "Eighteen";
                case 19: return "Nineteen";
                default:
                    string twoD = DigitToTens(num % 100 / 10);
                    twoD = twoD == "" ? twoD : twoD + " "; 
                    // Cancel redundant space.
                    return twoD + OneDigitToString(num % 10);
            }
        }

        /// <summary>
        /// Converts one digit number into words. 
        /// </summary>
        /// <param name="num"> 1 - 9</param>
        /// <returns>the digit in words words</returns>
        private static string OneDigitToString(int num)
        {
            switch (num)
            {
                case 1: return "One";
                case 2: return "Two";
                case 3: return "Three";
                case 4: return "Four";
                case 5: return "Five";
                case 6: return "Six";
                case 7: return "Seven";
                case 8: return "Eight";
                case 9: return "Nine";
                default: return "";
            }
        }
    }
}
