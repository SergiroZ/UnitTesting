using System;

namespace MathUtil.Exceptions {
    public class ExceptionParamMustBeMoreThanZero : Exception
    {
        public ExceptionParamMustBeMoreThanZero()
        {
            Console.WriteLine("Exception: parameter is less than zero..");
        }
    }
}