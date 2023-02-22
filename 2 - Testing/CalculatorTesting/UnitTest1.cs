using NUnit.Framework;
using StringCalculator;

namespace CalculatorTesting
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void PassEmptyStringReturn0()
        {
            // arrange
            string numbers = "";
            Calculator calculator = new Calculator();
            
            // act
            int result = calculator.Add(numbers);

            // assert
            Assert.AreEqual(0, result);
        }

        [Test]
        public void PassOneStringNumberReturnSameNumber()
        {
            string numbers = "1";
            Calculator calculator = new Calculator();

            int result = calculator.Add(numbers);

            Assert.AreEqual(1, result);
        }

        [Test]
        [TestCase("1,2,3,4,5", 15)]
        [TestCase("1,2,3,4", 10)]
        [TestCase("1,2,3", 6)]
        [TestCase("1,2,3,5", 11)]
        public void PassMultipleNumbersReturnSum(string numbers, int expectedResult)
        {
           Calculator calculator = new Calculator();
           int result = calculator.Add(numbers);
           Assert.AreEqual(expectedResult, result);
        }

        [Test]
        [TestCase("1,2\n3", 6)]
        public void PassMultipleDelimitersReturnSum(string numbers, int expectedResult)
        {
            Calculator calculator = new Calculator();
            int result = calculator.Add(numbers);
            Assert.AreEqual(expectedResult, result);
        }
        
        [Test]
        [TestCase("1,2,")]
        public void PassStringEndingWithDelimiterReturnError(string numbers)
        {
            Calculator calculator = new Calculator();
            Assert.Throws<ArgumentException>(() => calculator.Add(numbers));
        }

        [Test]
        [TestCase("//;\n1;3", 4)]
        [TestCase("//|\n1|2|3", 6)]
        public void PassOneCharacterDelimiterReturnSum(string input, int expectedResult)
        {
            Calculator calculator = new Calculator();
            int result = calculator.Add(input);
            Assert.AreEqual(expectedResult, result);
        }

        [Test]
        [TestCase("//;\n1;3;")]
        public void PassOneCharacterDelimiterReturnError(string numbers)
        {
            Calculator calculator = new Calculator();
            Assert.Throws<ArgumentException>(() => calculator.Add(numbers));
        }

        //[Test]
        //[TestCase("//sep\n2sep5", 7)]
        //public void PassMultipleCharactersDelimiterReturnSum(string input, int expectedResult)
        //{
        //    Calculator calculator = new Calculator();
        //    int result = calculator.Add(input);
        //    Assert.AreEqual(expectedResult, result);
        //}
    }
}