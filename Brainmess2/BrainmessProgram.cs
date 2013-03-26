
using System;

namespace Brainmess
{
    public class BrainmessProgram
    {
        private string _instructions;

        public string Instructions
        {
            get { return _instructions; }
            set
            {
                if (!string.IsNullOrEmpty(value))
                {
                    _instructions = value;
                    InstructionPointer = 0;
                    LoopDepth = 0;
                }
                else
                {
                    throw new Exception("Program cannot be emptly of null");
                }
            }
        }

        private int _instructionPointer;
        public int InstructionPointer
        {
            get { return _instructionPointer; }
            set
            {
                if (value > -1 && value <= Instructions.Length)
                {
                    _instructionPointer = value;
                }
                else
                {
                    throw new Exception("Invalid instruction pointer.");
                }
            }
        }

        public char CurrentInstruction
        {
            get { return Instructions[InstructionPointer]; }            
        }

        public bool EndOfProgram
        {
            get { return InstructionPointer == Instructions.Length; }
            
        }

        public int LoopDepth { get; set; }
    }
}
