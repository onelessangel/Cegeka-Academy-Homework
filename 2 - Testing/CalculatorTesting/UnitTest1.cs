using NUnit.Framework;
using StringCalculator;

namespace CalculatorTesting
{
    public class Tests
    {
        Calculator calculator;
        int result;

        [SetUp]
        public void Setup()
        {
            calculator = new Calculator();
        }

        [Test]
        public void PassEmptyStringReturn0()
        {
            // arrange
            string numbers = "";
            
            // act
            result = calculator.Add(numbers);

            // assert
            Assert.AreEqual(0, result);
        }

        [Test]
        public void PassOneStringNumberReturnSameNumber()
        {
            string numbers = "1";
            result = calculator.Add(numbers);
            Assert.AreEqual(1, result);
        }

        [Test]
        [TestCase("1,2,3,4,5", 15)]
        [TestCase("1,2,3,4", 10)]
        [TestCase("1,2,3", 6)]
        [TestCase("1,2,3,5", 11)]
        public void PassMultipleNumbersReturnSum(string numbers, int expectedResult)
        {
           result = calculator.Add(numbers);
           Assert.AreEqual(expectedResult, result);
        }

        [Test]
        [TestCase("1,2\n3", 6)]
        public void PassMultipleDelimitersReturnSum(string numbers, int expectedResult)
        {
            result = calculator.Add(numbers);
            Assert.AreEqual(expectedResult, result);
        }
        
        [Test]
        [TestCase("1,2,")]
        public void PassStringEndingWithSeparatorReturnError(string numbers)
        {
            var ex = Assert.Throws<FormatException>(() => calculator.Add(numbers));
            Assert.That(ex.Message, Is.EqualTo("Numbers cannot end with a separator!"));
        }

        [Test]
        [TestCase("//;\n1;3", 4)]
        [TestCase("//|\n1|2|3", 6)]
        [TestCase("//sep\n2sep5", 7)]
        public void PassCustomDelimiterReturnSum(string input, int expectedResult)
        {
            result = calculator.Add(input);
            Assert.AreEqual(expectedResult, result);
        }

        [Test]
        [TestCase("//;\n1;3;")]
        public void PassCustomDelimiterReturnEndingWithSeparatorError(string numbers)
        {
            var ex = Assert.Throws<FormatException>(() => calculator.Add(numbers));
            Assert.That(ex.Message, Is.EqualTo("Numbers cannot end with a separator!"));
        }

        [Test]
        [TestCase("//|\n1|2,3", "'|' expected but ',' found at position 3.")]
        [TestCase("//|\n1|2|3;4", "'|' expected but ';' found at position 5.")]
        public void PassCustomDelimiterReturnInvalidDelimiterError(string numbers, string errorText)
        {
            var ex = Assert.Throws<FormatException>(() => calculator.Add(numbers));
            Assert.That(ex.Message, Is.EqualTo(errorText));
        }
    }
}