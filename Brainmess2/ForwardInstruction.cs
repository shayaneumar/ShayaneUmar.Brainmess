using System;


namespace Brainmess
{
    public class ForwardInstruction : IInstruction
    {
        public ForwardInstruction(TapeMemory tapeMemory, BrainmessProgram program)
        {
            TapeMemory = tapeMemory;
            Program = program;
        }
  
        public int Execute()
        {
            int oldInstructionPointer = Program.InstructionPointer;
            TapeMemory.CurrentPointer++;
            Program.InstructionPointer++;
            return Math.Abs(Program.InstructionPointer - oldInstructionPointer);
        }

        public BrainmessProgram Program { get; set; }
        public TapeMemory TapeMemory { get; set; }
    }
}
