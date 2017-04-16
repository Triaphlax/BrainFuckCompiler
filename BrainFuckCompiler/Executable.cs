using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrainFuckCompiler
{
    class Executable
    {
        private const int NUMBER_STRIP_LENGTH = 100;

        private short[] numberStrip = Enumerable.Repeat((short)0, NUMBER_STRIP_LENGTH).ToArray();
        private int pointer = 0;

        public void ValueUp()
        {
            numberStrip[pointer]++;
        }

        public void ValueDown()
        {
            numberStrip[pointer]--;
        }

        public void PointerUp()
        {
            pointer++;
        }

        public void PointerDown()
        {
            pointer--;
        }

        public void SetUserInput(char userInput)
        {
            numberStrip[pointer] = (short)userInput;
        }

        public char ReturnValue()
        {
            return (char)numberStrip[pointer];
        }
    }
}
