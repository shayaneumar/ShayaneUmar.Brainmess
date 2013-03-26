using System;
using Brainmess;

namespace Brainmess
{
    public  class LoopBackwardInstruction : IInstruction
    {
        public LoopBackwardInstruction(TapeMemory tapeMemory, BrainmessProgram program)
        {
            TapeMemory = tapeMemory;
            Program = program;
        }

        public int Execute()
        {
            int oldInstructionPointer = Program.InstructionPointer;
            if (TapeMemory.CurrentCellValue == 0)
            {
                Program.InstructionPointer++;
                return Math.Abs(Program.InstructionPointer - oldInstructionPointer);
            }
            while (Program.CurrentInstruction != '[')
            {
                Program.InstructionPointer--;
            }
            return Math.Abs(Program.InstructionPointer - oldInstructionPointer);
        }

        public BrainmessProgram Program { get; set; }
        public TapeMemory TapeMemory { get; set; }
    }
}
