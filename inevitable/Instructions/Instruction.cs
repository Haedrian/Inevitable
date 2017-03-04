using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Llatext.Instructions
{
    public enum InstructionType 
    {
        UNKNOWN,
        LOAD,
        SAVE,
        WIN,
        DEATH,
    }

    public class Instruction
    {
        public InstructionType inst = InstructionType.UNKNOWN;
        public string detail = "";


        public Instruction(InstructionType type, string detail)
        {
            this.inst = type;
            this.detail = detail;

        }

        public Instruction()
        {
            this.inst = InstructionType.UNKNOWN;
            this.detail = "";
        }
    }

   
}
