using System;

namespace Brainmess
{
    public  class InputInstruction : IInstruction
    {
        public InputInstruction(TapeMemory tapeMemory, BrainmessProgram program)
        {
            TapeMemory = tapeMemory;
            Program = program;
        }


        public int Execute()
        {
            int oldInstructionPointer = Program.InstructionPointer;
            TapeMemory.CurrentCellValue = Console.Read();
            Program.InstructionPointer++;
            return Math.Abs(Program.InstructionPointer - oldInstructionPointer);
        }

        public BrainmessProgram Program { get; set; }
        public TapeMemory TapeMemory { get; set; }
    }
}
