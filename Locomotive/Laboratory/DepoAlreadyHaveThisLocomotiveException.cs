using System;
namespace lab4
{
    class DepoAlreadyHaveThisLocomotiveException : Exception
    {
        public DepoAlreadyHaveThisLocomotiveException() : base(
            "В депо уже есть такой локомотив")
        { }
    }
}
