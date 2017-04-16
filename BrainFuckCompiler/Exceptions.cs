using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrainFuckCompiler
{
    public class PointerOutOfBoundsException : Exception
    {
        public PointerOutOfBoundsException(string message) : base(message) { }
    }

    public class InvalidParenthesesException : Exception
    {
        public InvalidParenthesesException() { }
    }

    public class InvalidCharacterException : Exception
    {
        public InvalidCharacterException() { }
    }

    public class GotoForNonLoopCalledException : Exception
    {
        public GotoForNonLoopCalledException() { }
    }
}
