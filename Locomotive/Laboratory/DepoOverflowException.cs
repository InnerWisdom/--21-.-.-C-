using System;

namespace lab4
{
    class DepoOverflowException : Exception
    {
        public DepoOverflowException() : base("На парковке нет свободных мест")
        { }
    }
}
