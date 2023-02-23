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
        char[] defautDelimiters = { ',', '\n' };
        int result = 0;
        StringBuilder errorMessages = new StringBuilder();

        public int Add(string input)
        {
            if (string.IsNullOrEmpty(input))
            {
                return 0;
            }

            if (!input.StartsWith("//"))
            {
                if (defautDelimiters.Any(input.EndsWith))
                {
                    errorMessages.Append("Numbers cannot end with a separator!");
                }

                if (errorMessages.Length > 0)
                {
                    throw new FormatException(errorMessages.ToString());
                }

                return input.Split(defautDelimiters).Sum(int.Parse);
            }

            string[] fields = input.Substring(2).Split('\n');
            string delimiter = fields[0];
            string numbers = fields[1];

            if (numbers.EndsWith(delimiter))
            {
                errorMessages.Append("Numbers cannot end with a separator!");
            }

            string[] numbersArray = numbers.Split(delimiter);

            try
            {
                result = numbersArray.Sum(int.Parse);
            }
            catch (FormatException e)
            {
                string invalidDelimiterError = CheckInvalidDelimiter(numbersArray, delimiter);
                errorMessages.Append(invalidDelimiterError);

            }

            if (errorMessages.Length > 0)
            {
                throw new FormatException(errorMessages.ToString());
            }

            return result;
        }

        private string? CheckInvalidDelimiter(string[] numbersArray, string delimiter)
        {
            char invalidDelimiter;
            int invalidPos = 0;

            foreach (string number in numbersArray)
            {
                bool isNumber = number.All(char.IsNumber);

                // contains invalid delimeter
                if (!isNumber)
                {
                    // first character that is not a number
                    invalidDelimiter = number.First(x => !char.IsNumber(x));

                    // index of non digit character
                    invalidPos += number.IndexOf(invalidDelimiter);

                    return $"'{delimiter}' expected but '{invalidDelimiter}' found at position {invalidPos}.";
                }

                invalidPos += number.Length + 1;
            }

            return null;
        }
    }
}
