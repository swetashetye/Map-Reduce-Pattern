using System;
using System.Collections.Generic;

namespace ControlDigit
{
    class Program
    {
        static int CalculateControlDigit(long number)
        {
            IEnumerable<int> digits = GetDigitsFromLeastSignificant(number);
            IEnumerable<int> factor = GetMultiplicativeFactors();
            IEnumerable<int> weightedValues = AddWeight(digits, factor);

            int sum = 0;

            foreach (int weightedValue in weightedValues)
            {
                sum += weightedValue;

            }

            int result = sum % 11;
            if (result == 10)
                result = 1;

            return result;

        }

        private static IEnumerable<int> AddWeight(IEnumerable<int> values, IEnumerable<int> factors)
        {
            List<int> weightedValues = new List<int>();
            IEnumerator<int> factor = factors.GetEnumerator();

            foreach (int value in values)
            {
                factor.MoveNext();
                weightedValues.Add(factor.Current * value);

            }
            return weightedValues;
        }

        private static IEnumerable<int> GetMultiplicativeFactors()
        {
            return new int[] { 1, 3, 1, 3, 1, 3, 1, 3, 1, 3, 1, 3, 1, 3, 1, 3, 1, 3 };
        }

        public static IEnumerable<int> GetDigitsFromLeastSignificant(long number)
        {

            List<int> digits = new List<int>();

            do
            {
                int digit = (int)(number % 10);
                digits.Add(digit);
                number /= 10;
            }
            while (number > 0);

            return digits;

        }

        static void Main(string[] args)
        {
            Console.WriteLine("The control digit : {0}", CalculateControlDigit(82712476));
            Console.ReadLine();
        }
    }
}
