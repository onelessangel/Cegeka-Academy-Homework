using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using static StringCalculator.Constants;

namespace StringCalculator
{
    public class Calculator
    {
        char[] defautSeparators = { ',', '\n' };
        //string[] defautSeparators = { ",", "\n" };
        char[] delimiters = new char[10];
        //string[] delimiters = new string[2];
        string numbers;

        public int Add(string input)
        {
            if (string.IsNullOrEmpty(input))
            {
                return 0;
            }

            if (input.StartsWith("//"))
            {
                delimiters[0] = input[2];
                numbers = input.Substring(4);
            }
            else
            {
                delimiters = defautSeparators;
                numbers = input;
            }

            if (delimiters.Any(numbers.EndsWith))
            {
                throw new ArgumentException("Numbers cannot end with a separator!");
            }

            return numbers.Split(delimiters).Sum(int.Parse);
        }
    }
}
