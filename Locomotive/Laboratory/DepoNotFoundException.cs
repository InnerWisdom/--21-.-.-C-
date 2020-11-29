using System;

namespace lab4
{
    public class DepoNotFoundException : Exception
    {
        public DepoNotFoundException(int i) : base("Не найден локомотив по месту "+ i)
        { }
    }
}
