using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SudokuWFA_Stepankiv
{
    public class Square
    {
        private readonly List<int> _potentialValues = new List<int>() { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
        internal enum Blocks
        {
            UpperLeft,
            UpperMiddle,
            UpperRight,
            MiddleLeft,
            Middle,
            MiddleRight,
            LowerLeft,
            LowerMiddle,
            LowerRight
        }

        public int Row { get; private set; }
        public int Column { get; private set; }

        internal Blocks Block
        {
            get
            {
                if (Row < 4)
                {
                    if (Column < 4)
                    {
                        return Blocks.UpperLeft;
                    }

                    return Column < 7 ? Blocks.UpperMiddle : Blocks.UpperRight;
                }

                if (Row < 7)
                {
                    if (Column < 4)
                    {
                        return Blocks.MiddleLeft;
                    }

                    return Column < 7 ? Blocks.Middle : Blocks.MiddleRight;
                }

                if (Column < 4)
                {
                    return Blocks.LowerLeft;
                }

                return Column < 7 ? Blocks.LowerMiddle : Blocks.LowerRight;
            }
        }

        public bool IsSolved { get { return Value != null; } }

        public int? Value { get; set; }
        internal List<int> PotentialValues { get; private set; }

        internal Square(int row, int column)
        {
            Row = row;
            Column = column;
            PotentialValues = _potentialValues;
        }
    }
}
