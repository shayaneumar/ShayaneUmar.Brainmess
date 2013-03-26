using Microsoft.VisualStudio.TestTools.UnitTesting;
using Brainmess;

namespace BrainmessTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestForwardInstruction()
        {
          
            var forwardInstruction = new ForwardInstruction
                (
                    new TapeMemory(),
                    new BrainmessProgram
                    {
                        Instructions = ">"
                    }
                );
            forwardInstruction.Execute();
            Assert.AreEqual(1, forwardInstruction.TapeMemory.CurrentPointer);
        }
        [TestMethod]
        public void TestBackwardInstruction()
        {            
            var backwardInstruction = new BackwardInstruction
                (
                    new TapeMemory(),
                    new BrainmessProgram
                    {
                        Instructions = "<"
                    }
                );
            backwardInstruction.Execute();
            Assert.AreEqual(0, backwardInstruction.TapeMemory.CurrentPointer);
        }

        [TestMethod]
        public void TestIncreamentInstruction()
        {
            var increamentInstruction = new IncreamentInstruction
               (
                   new TapeMemory(),
                   new BrainmessProgram
                   {
                       Instructions = "+"
                   }
               );
            increamentInstruction.Execute();
            Assert.AreEqual(1, increamentInstruction.TapeMemory.CurrentCellValue);
        }

        [TestMethod]
        public void TestDecreamentInstruction()
        {
            var decreamentInstruction = new DecreamentInstruction
               (
                   new TapeMemory(),
                   new BrainmessProgram
                   {
                       Instructions = "+"
                   }
               );
            decreamentInstruction.Execute();
            Assert.AreEqual(-1, decreamentInstruction.TapeMemory.CurrentCellValue);
        }
        [TestMethod]
        public void TestLoopForwardInstruction()
        {

            var loopForwardInstruction = new LoopForwardInstruction
              (
                  new TapeMemory(),
                  new BrainmessProgram
                  {
                      Instructions = "[++++]",                      
                  }
              );
            loopForwardInstruction.Execute();
            
            Assert.AreEqual(5, loopForwardInstruction.Program.InstructionPointer);
        }

        [TestMethod]
        public void TestLoopBackwardInstruction()
        {           
            var loopBackwardInstruction = new LoopBackwardInstruction
              (
                  new TapeMemory(),
                  new BrainmessProgram
                  {
                      Instructions = "--[++++]",
                      InstructionPointer = 5
                  }
              ) {TapeMemory = {CurrentCellValue = 1}};

            loopBackwardInstruction.Execute();
            Assert.AreEqual(2, loopBackwardInstruction.Program.InstructionPointer);
        }

        [TestMethod]
        public void TestInstructionFactoryForwardInstructionCreation()
        {
            var instructionFactory = InstructionFactory.Create
                    (   
                        '>',
                        new TapeMemory(),
                        new BrainmessProgram()                        
                    );

            Assert.AreEqual(typeof(ForwardInstruction), instructionFactory.GetType());
        }

        [TestMethod]
        public void TestInstructionFactoryBackwardInstructionCreation()
        {
            var instructionFactory = InstructionFactory.Create
                    (
                        '<',
                        new TapeMemory(),
                        new BrainmessProgram()
                    );

            Assert.AreEqual(typeof(BackwardInstruction), instructionFactory.GetType());
        }

        [TestMethod]
        public void TestInstructionFactoryIncreamentInstructionCreation()
        {
            var instructionFactory = InstructionFactory.Create
                    (
                        '+',
                        new TapeMemory(),
                        new BrainmessProgram()
                    );

            Assert.AreEqual(typeof(IncreamentInstruction), instructionFactory.GetType());
        }

        [TestMethod]
        public void TestInstructionFactoryDecreamentInstructionCreation()
        {
            var instructionFactory = InstructionFactory.Create
                    (
                        '-',
                        new TapeMemory(),
                        new BrainmessProgram()
                    );

            Assert.AreEqual(typeof(DecreamentInstruction), instructionFactory.GetType());
        }

        [TestMethod]
        public void TestInstructionFactoryInputInstructionCreation()
        {
            var instructionFactory = InstructionFactory.Create
                    (
                        ',',
                        new TapeMemory(),
                        new BrainmessProgram()
                    );

            Assert.AreEqual(typeof(InputInstruction), instructionFactory.GetType());
        }

        [TestMethod]
        public void TestInstructionFactoryOutputInstructionCreation()
        {
            var instructionFactory = InstructionFactory.Create
                    (
                        '.',
                        new TapeMemory(),
                        new BrainmessProgram()
                    );

            Assert.AreEqual(typeof(OutputInstruction), instructionFactory.GetType());
        }
        [TestMethod]
        public void TestInstructionFactoryLoopForwardInstructionCreation()
        {
            var instructionFactory = InstructionFactory.Create
                    (
                        '[',
                        new TapeMemory(),
                        new BrainmessProgram()
                    );

            Assert.AreEqual(typeof(LoopForwardInstruction), instructionFactory.GetType());
        }

        [TestMethod]
        public void TestInstructionFactoryLoopBackwardInstructionCreation()
        {
            var instructionFactory = InstructionFactory.Create
                    (
                        ']',
                        new TapeMemory(),
                        new BrainmessProgram()
                    );

            Assert.AreEqual(typeof(LoopBackwardInstruction), instructionFactory.GetType());
        }


        [TestMethod]
        public void TestExecuteCurrentInstruction()
        {
            var brainmessProcessor = new BrainmessInterpreter
            {
                Program = new BrainmessProgram
                {
                    Instructions = ">"
                }
            };
            brainmessProcessor.Execute();
            Assert.AreEqual(1, brainmessProcessor.TapeMemory.CurrentPointer);
        }

        [TestMethod]
        public void TestExecute()
        {
            var brainmessProcessor = new BrainmessInterpreter
            {
                Program = new BrainmessProgram
                {
                    Instructions = "><+-[]"
                }
            };
            brainmessProcessor.Execute();
            Assert.AreEqual(0, brainmessProcessor.TapeMemory.CurrentCellValue);
        }
    }
}
