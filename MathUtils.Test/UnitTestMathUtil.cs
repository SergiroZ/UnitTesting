using System;
using MathUtil;
using MathUtil.Exceptions;
using Moq;
using NUnit.Framework;

namespace MathUtils.Test
{
    [TestFixture]
    public class CalculatorUnitTest
    {
        private ILogger _logger;

        [SetUp]
        public void MockInitialize()
        {
            var mock = new Mock<ILogger>();

            mock.Setup(p => p.Log(It.IsAny<string>())).Callback<string>(Console.WriteLine);


            _logger = mock.Object;
        }

        [Test]
        [TestCase(5, 3, ExpectedResult = 8)]
        [TestCase(2, 1, ExpectedResult = 3)]
        public int TestSumWithInIntRange(int x, int y)
        {
            var calc = new Calculator(_logger);

            Assert.Throws<ExceptionValueMustBeMoreThanTen>(() => calc.Sum(10, 10));
            return calc.Sum(x, y);
        }

        [Test]
        public void TestDivByZero()
        {
            //Arrange
            var calc = new Calculator(_logger);

            //Act / Assert
            Assert.Throws<DivideByZeroException>(() => calc.Divide(2, 0));
        }

        [Test]
        public void TestDivWithOneIntNegative()
        {
            //Arrange
            var calc = new Calculator(_logger);

            //Act
            var result = calc.Divide(2, -1);
            var result1 = calc.Divide(-2, 1);

            //Assert
            Assert.AreEqual(-2, result);
            Assert.AreEqual(-2, result1);
        }

        [Test]
        public void TestDivWithTwoIntNegative()
        {
            //Arrange
            var calc = new Calculator(_logger);

            //Act
            var result = calc.Divide(-2, -2);

            //Assert
            Assert.AreEqual(1, result);
        }

        [Test]
        public void TestSubstructWithPositiveValue()
        {
            //Arrange
            var calc = new Calculator(_logger);

            //Act
            var result = calc.Subtraction(5, 3);

            //Assert
            Assert.AreEqual(2, result);

            //Act
            result = calc.Subtraction(7, 3);
            //Assert
            Assert.AreEqual(4, result);
        }

        [Test]
        [TestCase(2, 3, ExpectedResult = 6)]
        [TestCase(0, 1, ExpectedResult = 0)]
        public int TestMultiplyWithPositiveValue(int x, int y)
        {
            //Arrange
            var calc = new Calculator(_logger);

            //Act
            //Assert
            Assert.Throws<ExceptionValueMustBeMoreThanTen>(() => calc.Multiply(2, 6));
            return calc.Multiply(x, y);
        }

        [Test]
        [TestCase(-2, -3, ExpectedResult = 6)]
        [TestCase(-1, 1, ExpectedResult = -1)]
        public int TestMultiplyWithNegativeValue(int x, int y)
        {
            //Arrange
            var calc = new Calculator(_logger);

            //Act
            //Assert
            Assert.Throws<ExceptionValueMustBeMoreThanTen>(() => calc.Multiply(-2, -6));
            return calc.Multiply(x, y);
        }

        [Test]
        [TestCase(4,  ExpectedResult = 2)]
        [TestCase(0,  ExpectedResult = 0)]
        public int TestSqrtWithPositiveValue(int x)
        {
            //Arrange
            var calc = new Calculator(_logger);

            //Act
            //Assert
            Assert.Throws<ExceptionParamMustBeMoreThanZero>(() => calc.Sqrt(-2));
            Assert.Throws<ExceptionValueMustBeMoreThanTen>(() => calc.Sqrt(121));
            return calc.Sqrt(x);
        }


    }
}