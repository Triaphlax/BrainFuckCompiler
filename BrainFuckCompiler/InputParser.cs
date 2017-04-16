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

        static public void checkParenthesesValidility(string input)
        {
            int parenthesesCounter = 0;
            foreach (char c in input)
            {
                if(c == '[')
                {
                    parenthesesCounter++;
                }
                else if (c == ']')
                {
                    if(parenthesesCounter == 0) { throw new InvalidParenthesesException(); }
                    parenthesesCounter--;
                }
            }

            if(parenthesesCounter != 0) { throw new InvalidParenthesesException(); }
        }

        static public Instruction[] makeInstructionList(string input)
        {
            Instruction[] instructionList = new Instruction[input.Length];
            List<int> gotoLinesLoopBegin = new List<int>();

            for (int i = 0; i < input.Length; i++)
            {
                char c = input[i];
                switch (c)
                {
                    case '<': instructionList[i] = new Instruction(InstructionType.PointerDown); break;
                    case '>': instructionList[i] = new Instruction(InstructionType.PointerUp); break;
                    case '+': instructionList[i] = new Instruction(InstructionType.ValueUp); break;
                    case '-': instructionList[i] = new Instruction(InstructionType.ValueDown); break;
                    case '.': instructionList[i] = new Instruction(InstructionType.ReturnValue); break;
                    case ',': instructionList[i] = new Instruction(InstructionType.GetUserInput); break;
                    case '[':
                        gotoLinesLoopBegin.Add(i);
                        break;
                    case ']':
                        int pointerToLoopBegin = gotoLinesLoopBegin[gotoLinesLoopBegin.Count - 1];
                        gotoLinesLoopBegin.RemoveAt(gotoLinesLoopBegin.Count - 1);
                        instructionList[i] = new Instruction(InstructionType.LoopEnd, pointerToLoopBegin);
                        instructionList[pointerToLoopBegin] = new Instruction(InstructionType.LoopBegin, i);
                        break;

                    default: throw new InvalidCharacterException();
                }
            }

            return instructionList;
        }
    }
}
