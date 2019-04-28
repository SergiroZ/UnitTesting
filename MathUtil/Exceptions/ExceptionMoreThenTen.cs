using System;

namespace MathUtil.Exceptions
{
    public class ExceptionValueMustBeMoreThanTen : Exception
    {
        public ExceptionValueMustBeMoreThanTen()
        {
            Console.WriteLine("Exception: Value more than ten..");
        }
    }
}