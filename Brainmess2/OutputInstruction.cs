using System;
using Brainmess;

namespace Brainmess
{
    public class OutputInstruction : IInstruction
    {
        public OutputInstruction(TapeMemory tapeMemory, BrainmessProgram program)
        {
            TapeMemory = tapeMemory;
            Program = program;
        }

        public int Execute()
        {
            int oldInstructionPointer = Program.InstructionPointer;
            Console.Write(Convert.ToChar(TapeMemory.CurrentCellValue));
            Program.InstructionPointer++;
            return Math.Abs(Program.InstructionPointer - oldInstructionPointer);
        }

        public BrainmessProgram Program { get; set; }
        public TapeMemory TapeMemory { get; set; }
    }
}
