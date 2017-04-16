using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrainFuckCompiler
{
    static class InputParser
    {
        static public string removeAllInvalidCharacters(string input)
        {
            StringBuilder sb = new StringBuilder();
            
            foreach(char c in input)
            {
                if ("<>,.+-[]".Contains(c))
                {
                    sb.Append(c);
                }
            }

            return sb.ToString();
        }

        static public Instruction[] makeInstructionList(string input)
        {
            Instruction[] instructionList = new Instruction[input.Length];

            for(int i = 0; i < input.Length; i++)
            {
                char c = input[i];
                InstructionType iType;
                switch (c)
                {
                    case '<': iType = InstructionType.PointerDown; break;
                    case '>': iType = InstructionType.PointerUp; break;
                    case '+': iType = InstructionType.ValueUp; break;
                    case '-': iType = InstructionType.ValueDown; break;
                    case '.': iType = InstructionType.ReturnValue; break;
                    case ',': iType = InstructionType.GetUserInput; break;
                    case '[': iType = InstructionType.LoopBegin; break;
                    case ']': iType = InstructionType.LoopEnd; break;
                    default: iType = InstructionType.ERROR; break; //TODO Exception
                }

                instructionList[i] = new Instruction(iType);
            }

            return instructionList;
        }
    }
}
