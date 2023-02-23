using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace StringCalculator
{
    public class Calculator
    {
        char[] defautDelimiters = { ',', '\n' };
        StringBuilder errorMessages = new StringBuilder();
        string invalidDelimiterError, negativeNumbersError;

        public int Add(string input)
        {
            if (string.IsNullOrEmpty(input))
            {
                return 0;
            }

            if (!input.StartsWith("//"))
            {
                return OperateWithDefaultDelimiters(input);
            }

            return OperateWithCustomDelimiters(input);
        }

        private int OperateWithDefaultDelimiters(string input)
        {
            if (defautDelimiters.Any(input.EndsWith))
            {
                throw new FormatException("Numbers cannot end with a separator!\n");
            }

            string[] numbersArray = input.Split(defautDelimiters);

            negativeNumbersError = CheckNegativeNumbers(numbersArray);
            errorMessages.Append(negativeNumbersError);

            if (errorMessages.Length > 0)
            {
                throw new FormatException(errorMessages.ToString());
            }

            return ComputeSum(numbersArray);
        }

        private int OperateWithCustomDelimiters(string input)
        {
            string[] fields = input.Substring(2).Split('\n');
            string delimiter = fields[0];
            string numbers = fields[1];
            int result = 0;

            if (numbers.EndsWith(delimiter))
            {
                throw new FormatException("Numbers cannot end with a separator!\n");
            }

            string[] numbersArray = numbers.Split(delimiter);

            negativeNumbersError = CheckNegativeNumbers(numbersArray);

            try
            {
                result = ComputeSum(numbersArray);
            }
            catch (FormatException)
            {
                invalidDelimiterError = CheckInvalidDelimiter(numbersArray, delimiter);
            }

            errorMessages.Append(negativeNumbersError);
            errorMessages.Append(invalidDelimiterError);

            if (errorMessages.Length > 0)
            {
                throw new FormatException(errorMessages.ToString());
            }

            return result;
        }

        private int ComputeSum(string[] numbersArray) {
            return numbersArray.Where(x => int.Parse(x) < 1000).Sum(int.Parse);
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

                    return $"'{delimiter}' expected but '{invalidDelimiter}' found at position {invalidPos}.\n";
                }

                invalidPos += number.Length + 1;
            }

            return null;
        }

        private string? CheckNegativeNumbers(string[] numbersArray)
        {
            StringBuilder error = new StringBuilder();
            string[] negativeNumbers = new string[100];
            int negativeNumbersSize = 0;

            foreach(string numbersString in numbersArray)
            {
                foreach (string number in numbersString.Split(defautDelimiters))
                {
                    if (int.Parse(number) < 0)
                    {
                        negativeNumbers[negativeNumbersSize++] = number;
                    }
                }
                    
            }

            if (negativeNumbersSize == 0)
            {
                return null;
            }
            
            error.Append("Negative number(s) not allowed: ");

            for (int i = 0; i < negativeNumbersSize; i++)
            {
                error.Append($"{negativeNumbers[i]}");

                if (i < negativeNumbersSize - 1)
                {
                    error.Append(", ");
                }
            }

            error.Append("\n");

            return error.ToString();
        }
    }
}
