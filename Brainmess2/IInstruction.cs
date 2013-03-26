using Brainmess;

namespace Brainmess
{
    public interface IInstruction
    {
        int Execute();
        BrainmessProgram Program { get; set; }
        TapeMemory TapeMemory { get; set; }
    }
}