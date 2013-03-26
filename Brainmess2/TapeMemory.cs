

using System;
using System.Collections.Generic;
namespace Brainmess
{
    public class TapeMemory
    {
        public TapeMemory()
        {
            CurrentPointer = 0;
            Cells = new List<int> {0};
        }

        private int _currentPointer;
        public int CurrentPointer
        {
            get { return _currentPointer; }
            set
            {
                if (value > _currentPointer)
                {
                    Cells.AddRange(new int[value - _currentPointer]);                   
                }
                if (value > -1)
                {
                    _currentPointer = value;
                }
                else
                {
                    throw new Exception("Invalid memory address");
                }
            }
        }

        public List<int> Cells { 
            get;
            private set;
        }

        public int CurrentCellValue
        {
            get { return Cells[CurrentPointer]; }
            set { Cells[CurrentPointer] = value; }
        }
    }
}
