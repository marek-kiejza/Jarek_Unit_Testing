using NUnit.Framework;

namespace ClassLibrary2
{
    [TestFixture]
    public class Introduction
    {
        [Test]
        public void Calculator_When_Adding_Two_Numbers_Should_Return_Sum()
        {
            // arrange
            var calculator = new Calculator();

            // act
            var result = calculator.Add(1, 2);

            // assert
            Assert.AreEqual(3, result);
        }

        [TestCase(0, 0, 0)]
        [TestCase(1, 0, 1)]
        [TestCase(0, 1, 1)]
        [TestCase(-1, 1, 0)]
        [TestCase(100, 200, 300)]
        public void Calculator_When_Adding_Two_Numbers_Should_Return_Sum_Cases(int a, int b, int expected)
        {
            // arrange
            var calculator = new Calculator();

            // act
            var actual = calculator.Add(a, b);

            // assert
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void Calculator_When_Adding_Two_Numbers_Should_Return_Sum_Broken_Test()
        {
            // arrange
            var calculator = new Calculator();

            // act
            var result = calculator.Add(1, 1);

            // assert
            Assert.AreEqual(3, result);
        }
    }

    public class Calculator
    {
        public int Add(int a, int b)
        {
            return a + b;
        }
    }
}