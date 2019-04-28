using System;

namespace MathUtil.Exceptions
{
    public class ExceptionValueMustBeMoreThanTen : Exception
    {
        public ExceptionValueMustBeMoreThanTen()
        {
            Console.WriteLine("Value more than ten..");
        }
    }
}