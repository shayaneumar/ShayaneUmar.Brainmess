using System;


namespace Brainmess
{
    class Program
    {

        static void Main(string[] args)
        {
            var brainmessProcessor = new BrainmessInterpreter();
            brainmessProcessor.Program =
                new BrainmessProgram
                    {
                        Instructions =
                            "++++++++[>+++++++++<-]>.<+++++[>++++++<-]>-.+++++++..+++.<++++++++[>>++++<<-]>>.<<++++[>------<-]>.<++++[>++++++<-]>.+++.------.--------.>+."
                    };

            //brainmessProcessor.Program.Instructions = "+++>+++..[.-]..";
            //string program = "<<<<++++++++[>+++++++++<-]>.";
            brainmessProcessor.Execute();
            Console.ReadLine();

        }
    }
}
