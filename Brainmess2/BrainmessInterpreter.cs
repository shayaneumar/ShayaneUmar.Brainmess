
using Brainmess;

namespace Brainmess
{
    public class BrainmessInterpreter
    {
        
        public BrainmessInterpreter()
        {            
            TapeMemory = new TapeMemory();
        }
                
        public BrainmessProgram Program { get; set; }
        public TapeMemory TapeMemory { get; set; }

        public void Execute()
        {
            while (!Program.EndOfProgram)
            {
                ExecuteCurrentInstruction();               
            }
        }
               
        private void ExecuteCurrentInstruction()
        {
            var instruction = InstructionFactory.Create(Program.CurrentInstruction, TapeMemory, Program);
            instruction.Execute();
        }
    }
}
