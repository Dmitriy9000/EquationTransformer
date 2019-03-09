using System;

namespace EquationTransformer.EquationProcessor
{
    public class EquationException : Exception
    {
        public EquationException(string msg) : base(msg) { }
    }
}
