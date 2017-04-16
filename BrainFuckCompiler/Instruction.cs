using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrainFuckCompiler
{
    public enum InstructionType { ValueUp, ValueDown, PointerUp, PointerDown, GetUserInput, ReturnValue, LoopBegin, LoopEnd, ERROR };

    class Instruction
    {
        private InstructionType iType;
        private int gotoLine = -1;

        public Instruction(InstructionType iType, int gotoLine=-1)
        {
            this.iType = iType;
            if (iType == InstructionType.LoopBegin || iType == InstructionType.LoopEnd)
            {
                this.gotoLine = gotoLine;
            }
        }

        public int getGotoLine()
        { 
            //TODO Exception if called by non Loop type
            return gotoLine;
        }

        public InstructionType getIType()
        {
            return iType;
        }
    }
}
