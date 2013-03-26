
namespace Brainmess
{
    public class InstructionFactory
    {

        public static IInstruction Create(char instruction, TapeMemory tapeMemory, BrainmessProgram program)
        {
            IInstruction iInstruction = null;
            switch (instruction)
            {
                case '>':
                    iInstruction = new ForwardInstruction(tapeMemory, program);
                    break;
                case '<':
                    iInstruction = new BackwardInstruction(tapeMemory, program);
                    break;
                case '+':
                    iInstruction = new IncreamentInstruction(tapeMemory, program);
                    break;
                case '-':
                    iInstruction = new DecreamentInstruction(tapeMemory, program);
                    break;
                case '.':
                    iInstruction = new OutputInstruction(tapeMemory, program);
                    break;
                case ',':
                    iInstruction = new InputInstruction(tapeMemory, program);
                    break;
                case '[':
                    iInstruction = new LoopForwardInstruction(tapeMemory, program);
                    break;
                case ']':
                    iInstruction = new LoopBackwardInstruction(tapeMemory, program);
                    break;
            }
            return iInstruction;
        }

    }
}

