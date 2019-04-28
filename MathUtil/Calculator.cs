using System;
using MathUtil.Exceptions;

namespace MathUtil
{
    public interface ILogger
    {
        void Log(string text);
    }

    public class Calculator
    {
        private readonly ILogger _logger;

        public Calculator(ILogger logger) => _logger = logger;

        private void MyExceptionResult(int result)
        {
            if (result <= 10) return;
            throw new ExceptionValueMustBeMoreThanTen();
        }

        private void MyExceptionParam(int result)
        {
            if (result >= 0) return;
            throw new ExceptionParamMustBeMoreThanZero();
        }

        public int Sum(int x, int y)
        {
            var result = x + y;
            _logger.Log($"{x} + {y} = {result};");
            MyExceptionResult(result);
            return result;
        }

        public object Subtraction(int x, int y)
        {
            var result = x - y;
            _logger.Log($"{x} - {y} = {result};");
            MyExceptionResult(result);
            return result;
        }

        public int Multiply(int x, int y)
        {
            var result = x * y;
            _logger.Log($"{x} * {y} = {result};");
            MyExceptionResult(result);
            return result;
        }

        public int Divide(int x, int y)
        {
            var result = x / y;
            _logger.Log($"{x} / {y} = {result};");
            MyExceptionResult(result);
            return result;
        }

        public int Pow(int x, int exponent)
        {
            var result = (int) Math.Pow(x, exponent);
            _logger.Log($"{x} ^ {exponent} = {result};");
            MyExceptionResult(result);
            return result;
        }

        public int Sqrt(int x)
        {
            var result = (int) Math.Sqrt(x);
            _logger.Log($" sqrt ({x}) = {result};");
            MyExceptionParam(x);
            MyExceptionResult(result);
            return result;
        }
    }
}